using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using QRCoder;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TRU.Employee.WebAPI.Helpers;
using TRU.Employee.WebAPI.Models;
using TRU.Employee.WebAPI.Models.Employee;
using TRU.Employee.WebAPI.Models.ImageModel;
using TRU.Realty.BusinessCommon.Client;
using TRU.Realty.BusinessCommon.Helper;
using TRU.Realty.Common;
using TRU.Realty.Common.Email;
using TRU.Realty.Common.EncryptDecrypt;
using TRU.Realty.Common.Images;


namespace TRU.Employee.WebAPI.BAL;
public class Common : BaseEmployee
{
    IConfiguration config;
    ImageUploder imageUploder = null;
    Common common = null;

    public Common(IConfiguration _config, IOptions<ConnectionStrings> _connectionString)
      : base(_connectionString)
    {
        this.config = _config;
        this.connectionString = _connectionString;
    }

    public List<FileAttachmentModel> UploadFiles(List<FileAttachmentModel> fileList, string folderName, string module, bool isGuid, bool AzureFileName = false)
    {
        if (null != fileList && 0 < fileList.Count)
        {
            fileList.ForEach(file =>
            {
                file = UploadFile(file, folderName, module, isGuid, AzureFileName);
            });
        }
        return fileList;
    }
    public FileAttachmentModel UploadFile(FileAttachmentModel file, string folderName, string module, bool isGuid, bool AzureFileName = false)
    {
        string storageConnectionString = config["ImageUploader:storageConnectionString"];
        string containerName = config["ImageUploader:containerName"];
        string FileName;
        if (isGuid)
        {
            FileName = Guid.NewGuid() + file.Name;
        }
        else
        {
            FileName = file.Name;
        }
        AzureBlobRepository blobRepository = new AzureBlobRepository(module, folderName, FileName, containerName, storageConnectionString);
        byte[] bytes = Convert.FromBase64String(file.Content);
        file.FilePath = blobRepository.UploadFromByteArray(bytes, file.Type);
        if (AzureFileName)
        {
            file.DocumentName = FileName;
        }
        return file;
    }
    /// <summary>
    /// Delete ImageUrl from Azure
    /// </summary>
    /// <param name="fileURLList"></param>
    public void DeleteFileFromAzure(string fileURLList)
    {
        string errorString = string.Empty;
        try
        {
            string storageConnectionString = config["ImageUploader:storageConnectionString"];
            string containerName = config["ImageUploader:containerName"];
            AzureBlobRepository blobRepository = new AzureBlobRepository(fileURLList, containerName, storageConnectionString);
            blobRepository.Delete();
        }
        catch (Exception ex)
        {
            errorString = ex.Message;
        }
    }
    /// <summary>
    /// Add ImageUrl through ProjectName,BuildingType,ImageType,IssueId,ReceiptNo,OrderId,EntityId,InVoiceNo
    /// here we use 'Employee_Tru_Images_Insert' SP
    /// </summary>
    /// <param name="imageParameter and fileList"></param>
    public JsonResult AddImageUrl(List<FileAttachmentModel> fileList, ImageParameter imageParameter)
    {
        if (null != fileList && 0 < fileList.Count)
        {
            List<string> imageUrls = new List<string>();

            if (imageParameter.ImageType == "Brochure")
            {
                foreach (var file in fileList)
                {
                    imageUrls.Add(file.Name);
                }
            }
            else
            {
                foreach (var file in fileList)
                {
                    imageUrls.Add(file.FilePath);
                }
            }

            imageParameter.ImageUrl = string.Join(",", imageUrls);
            requestModel = CreateRequestModel(this.userParameter, imageParameter, StoredProcedureNames.Select_ProjectImageUrl);
            responseResult = clientResponse.SaveItems(requestModel);
        }
        return new JsonResult(responseResult);
    }

    /// <summary>
    /// here we get Upload Image Url 
    /// </summary>
    /// <param name="imageParameter" and Image Files></param>
    public async Task<JsonResult> UploadImage(ImageParameter imageParameter, ICollection<IFormFile> files)
    {
        JsonResult jsonResult = null;
        try
        {
            string storageConnectionString = config["ImageUploader:storageConnectionString"];
            string containerName = config["ImageUploader:containerName"];
            imageUploder = new ImageUploder(storageConnectionString);

            foreach (var formFile in files)
            {
                if (IsImage(formFile) && formFile.Length > 0)
                {
                    using (Stream stream = formFile.OpenReadStream())
                    {
                        string result = await imageUploder.UploadImageAsync(containerName, Guid.NewGuid() + formFile.FileName, stream, formFile.ContentType);

                        if (result != null)
                        {
                            jsonResult = AddImageUrl(result, imageParameter);
                        }
                    }
                }
                else
                {
                    return new JsonResult("Unsupported Media Type");
                }
            }
        }
        catch (Exception)
        {
            return new JsonResult("Image is not uploaded on azure storage");
        }
        return jsonResult;
    }
    /// <summary>
    /// Add ImageUrl through ProjectName,BuildingType,ImageType,IssueId,ReceiptNo,OrderId,EntityId,InVoiceNo
    /// here we use 'Employee_Tru_Images_Insert' SP
    /// </summary>
    /// <param name="imageParameter and imageUrl"></param>
    public JsonResult AddImageUrl(string imageUrl, ImageParameter imageParameter)
    {
        imageParameter.ImageUrl = imageUrl;
        requestModel = CreateRequestModel(this.userParameter, imageParameter, StoredProcedureNames.Select_ProjectImageUrl);
        responseResult = clientResponse.SaveItems(requestModel);
        return new JsonResult(responseResult);
    }
    public static bool IsImage(IFormFile file)
    {
        if (file.ContentType.Contains("image"))
        {
            return true;
        }
        string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };
        return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
    }
    /// <summary>
    /// here we get Change Image Url 
    /// </summary>
    /// <param name="imageParameter" and Image Files></param>
    public async Task<JsonResult> UpdateImage(ImageParameter imageParameter, ICollection<IFormFile> files)
    {
        JsonResult jsonResult = null;
        try
        {
            string storageConnectionString = config["ImageUploader:storageConnectionString"];
            string containerName = config["ImageUploader:containerName"];
            imageUploder = new ImageUploder(storageConnectionString);
            foreach (var formFile in files)
            {
                if (IsImage(formFile) && formFile.Length > 0)
                {
                    using (Stream stream = formFile.OpenReadStream())
                    {
                        string result = await imageUploder.UploadImageAsync(containerName, Guid.NewGuid() + formFile.FileName, stream, formFile.ContentType);

                        if (result != null)
                        {
                            jsonResult = UpdateImageUrl(result, imageParameter);
                        }
                    }
                }
                else
                {
                    return new JsonResult("Unsupported Media Type");
                }
            }
        }
        catch (Exception)
        {
            return new JsonResult("Image is not uploaded on azure storage");
        }
        return jsonResult;
    }

    /// <summary>
    /// Update ImageUrl ProjectName,BuildingType,ImageType,IssueId,ReceiptNo,OrderId
    /// here we use 'Employee_Tru_Images_Update' SP
    /// </summary>
    /// <param name="imageParameter and Image Files"></param>
    public JsonResult UpdateImageUrl(string imageUrl, ImageParameter imageParameter)
    {
        imageParameter.ImageUrl = imageUrl;
        requestModel = CreateRequestModel(this.userParameter, imageParameter, StoredProcedureNames.Update_ProjectImageUrl);
        responseResult = clientResponse.SaveItems(requestModel);
        return new JsonResult(responseResult);
    }

    public JsonResult GetAllEmployeesNames()
    {
        requestModel = CreateRequestModel(this.userParameter, null, StoredProcedureNames.SelectAll_EmployeeNames);
        responseResult = clientResponse.GetItems(requestModel);
        if (responseResult.Data.Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
            return new JsonResult(responseResult);
        }
        else
        {
            return new JsonResult(responseResult);
        }
    }

    // employee get details

    public JsonResult GetlEmployeesDetail(String mail,string Password)
    {
        Employee_getDataModel emp=new Employee_getDataModel();
        emp.Email = mail;
        //    EmployeeResposne connection String 
        //  Console.WriteLine("Password : "+Password);
        EncryptionDecryption decrypt = new EncryptionDecryption();

        requestModel = CreateRequestModel(this.userParameter,emp, StoredProcedureNames.SELECT_GetEmployeeDetail);
        responseResult = EmployeeResposne.GetItems(requestModel);

          if (responseResult.Data.Count == 0 || responseResult.Data == null)
        {
             
                responseResult.Exception = "No Data Found";
           //  responseResult.Exception = ePass;
            return new JsonResult(responseResult);
        }
        
        else
        {
            var employeeData = responseResult.Data[0];

            //  remove data from response .
            responseResult.Data[0] = null;
            if ( decrypt.Decrypt(employeeData.Password)== Password)
            {
                
                return new JsonResult(responseResult);
            }
            else
            {
                
                responseResult.Exception = "Password does not match";
                return new JsonResult(responseResult);
            }
        }
    }

    // Employee post details 

    public IActionResult SetEmployeesDetails(Employee_postDataModel emp_PostDataModel)
    {
        try
        {
            // string jsonString = Convert.ToString(postDataModel);
            //= new Employee_postDataModel();


            // emp_PostDataModel.Name = Name;
            // emp_PostDataModel.Email = EmployeeEmail;
            // emp_PostDataModel.password = Password;

            EncryptionDecryption encryptt=new EncryptionDecryption();
            String pass = emp_PostDataModel.password;
            emp_PostDataModel.password = encryptt.Encrypt(pass);

            requestModel = CreateRequestModel(null, emp_PostDataModel, StoredProcedureNames.sp_InsertEmployeeLogin);
            responseResult = EmployeeResposne.SaveItems(requestModel);
            if (responseResult.Successful)
            {
                      return new JsonResult(responseResult);
            }
            else
            {
                return new EmptyResult();
            }
        }
        catch (Exception ex)
        {
            return new EmptyResult();
        }
    }

    // Post Assset data
    public IActionResult PostAssetDetails(Asset_PostDataModel asset_PostDataModel)
    {
        try
        {
            // string jsonString = Convert.ToString(postDataModel);
            //= new Employee_postDataModel();


            // emp_PostDataModel.Name = Name;
            // emp_PostDataModel.Email = EmployeeEmail;
            // emp_PostDataModel.password = Password;

            asset_PostDataModel.Action ="Insert";


            requestModel = CreateRequestModel(null,asset_PostDataModel,StoredProcedureNames.sp_InsertAssetData);
            responseResult = EmployeeResposne.SaveItems(requestModel);
            if (responseResult.Successful)
            {
                return new JsonResult(responseResult);
            }
            else
            {
                return new EmptyResult();
            }
        }
        catch (Exception ex)
        {
            return new EmptyResult();
        }
    }

    // Get Asset details

    public JsonResult GetAssetDetails()
    {
       

        requestModel = CreateRequestModel(this.userParameter,null, StoredProcedureNames.sp_SelectAssetData);
        responseResult = EmployeeResposne.GetSetItems(requestModel);

        if (responseResult.Data.Count == 0 || responseResult.Data == null)
        {

            responseResult.Exception = "No Data Found";
            //  responseResult.Exception = ePass;
            return new JsonResult(responseResult);
        }

        else
        {
           
             return new JsonResult(responseResult);

        }
    }

    // Update Asset Details
    public JsonResult UpdateAssetDetail(Asset_PostDataModel asset_PostDataModel)
    {
        asset_PostDataModel.Action = "Update";
        asset_PostDataModel.Name = "";
        asset_PostDataModel.Category = "";
        asset_PostDataModel.Cost = 0;

        requestModel = CreateRequestModel(this.userParameter, asset_PostDataModel,StoredProcedureNames.sp_InsertAssetData);
        responseResult = EmployeeResposne.SaveItems(requestModel);
        return new JsonResult(responseResult);
    }
    


    // Update Asset Details
    public JsonResult DeleteAssetDetail(Asset_PostDataModel asset_PostDataModel)
    {

        asset_PostDataModel.Action = "Delete";
        asset_PostDataModel.Name = "";
        asset_PostDataModel.Category = "";
        asset_PostDataModel.Condition = "";
        asset_PostDataModel.Cost = 0;
        asset_PostDataModel.Location = "";
        asset_PostDataModel.Status = "";


        requestModel = CreateRequestModel(this.userParameter, asset_PostDataModel, StoredProcedureNames.sp_InsertAssetData);
        responseResult = EmployeeResposne.SaveItems(requestModel);
        return new JsonResult(responseResult);

    }
    // student post details

    public IActionResult SetStudentDetailData(Student_PostDataModel student_PostDataModel)
    {

        try
        {
            requestModel = CreateRequestModel(null, student_PostDataModel,StoredProcedureNames.sp_InsertStudetD);
            responseResult = EmployeeResposne.SaveItems(requestModel);

            
            if (responseResult.Successful)
            {
                return new JsonResult(responseResult);
            }
            else {
                return new EmptyResult();
            }
        }
        catch { 
            return new EmptyResult();
        }
}
    public JsonResult GetAllEmployeesRoles()
    {
        requestModel = CreateRequestModel(this.userParameter, null, StoredProcedureNames.SelectAll_EmployeesRoles);
        responseResult = clientResponse.GetItems(requestModel);
        if (responseResult.Data.Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
            return new JsonResult(responseResult);
        }
        else
        {
            return new JsonResult(responseResult);
        }
    }

    public JsonResult GetAllEmployeesNames_ByRole(EmployeeRole employeeRole)
    {
        requestModel = CreateRequestModel(this.userParameter, employeeRole, StoredProcedureNames.SelectAll_EmployeeNames_ByRole);
        responseResult = clientResponse.GetItems(requestModel);
        if (responseResult.Data.Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
        }
        return new JsonResult(responseResult);
    }

    public JsonResult GetAllFileNames()
    {
        requestModel = CreateRequestModel(this.userParameter, null, StoredProcedureNames.SelectAll_Keys);
        responseResult = clientResponse.GetItems(requestModel);
        if (responseResult.Data.Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
        }
        return new JsonResult(responseResult);
    }
    public JsonResult GetContentByFileName(FileNameParam fileNameParam)
    {
        requestModel = CreateRequestModel(this.userParameter, fileNameParam, StoredProcedureNames.Select_Contents);
        responseResult = clientResponse.GetItems(requestModel);
        if (responseResult.Data.Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
        }
        return new JsonResult(responseResult);
    }
    /// <summary>
    /// here we get true or false flag for utility
    /// </summary>
    public APIResponse GetFlag(string UtilityFlag)
    {
        KeyModel keyModel = new KeyModel();
        keyModel.Key = UtilityFlag;
        requestModel = CreateRequestModel(this.userParameter, keyModel, StoredProcedureNames.Select_UtilityFlag);
        responseResult = clientResponse.GetItems(requestModel);
        return responseResult;
    }
    /// <summary>
    /// here we update true or false flag for utility
    /// </summary>
    /// <param name="setFlagModel"></param>
    public JsonResult setFlag(SetFlagModel setFlagModel)
    {
        requestModel = CreateRequestModel(this.userParameter, setFlagModel, StoredProcedureNames.Update_UtilityFlag);
        responseResult = clientResponse.SaveItems(requestModel);
        return new JsonResult(responseResult);
    }
    /// <summary>
    /// here we get all flag's status
    /// </summary>
    public JsonResult getAllFlag()
    {
        requestModel = CreateRequestModel(this.userParameter, null, StoredProcedureNames.SelectAll_UtilityFlag);
        responseResult = clientResponse.GetItems(requestModel);
        return new JsonResult(responseResult);
    }
    /// <summary>
    /// Select All Organization names
    /// </summary>
    /// <returns></returns>
    public JsonResult GetAllOrganization()
    {
        requestModel = CreateRequestModel(this.userParameter, null, StoredProcedureNames.SelectAll_Organization);
        responseResult = clientResponse.GetSetItems(requestModel);
        if (responseResult.Data[0].Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
        }
        return new JsonResult(responseResult);
    }

    /// <summary>
    /// Check customer allready exists
    /// </summary>
    /// <param name="isAllReadyExistsParameter"></param>
    /// <returns></returns>
    public JsonResult IsAllReadyExists(ExistsParameter existsParameter)
    {
        requestModel = CreateRequestModel(this.userParameter, existsParameter, StoredProcedureNames.Check_Duplicate);
        responseResult = clientResponse.GetSetItems(requestModel);
        if (responseResult.Data[0].Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
        }
        return new JsonResult(responseResult);
    }
    public void ExceptionSave(JObject data, String Message, string APIname = null)
    {
        APIResponse aPIResponse = new APIResponse();
        aPIResponse.Data = APIname + " " + System.Reflection.MethodBase.GetCurrentMethod().Name;
        aPIResponse.Successful = false;
        aPIResponse.Exception = Message;
        clientResponse.SaveExceptionLogs(data, aPIResponse);
    }
    public JObject CreateRequestModel(UserParameter userParameter, dynamic Model = null, String SpName = null)
    {
        JObject request = Model != null ? WebAPICommon.GetJSONObject(Model) : WebAPICommon.GetJSONObject(null);
        if (userParameter != null && string.IsNullOrEmpty(userParameter.UserType))
        {
            userParameter.UserId = 0;
            userParameter.UserType = "Schedulers / Unauthorized API Call";
            userParameter.TenantId = 0;
        }
         JObject userRrequestModel = WebAPICommon.GetUserJSONObject(userParameter);
        request.Add("User", userRrequestModel);
        request.Add(SPKey, SpName);
        return request;
    }
    public string DataTableToJSONWithStringBuilder(DataTable resultTbl)
    {
        var JSONString = new System.Text.StringBuilder();
        if (resultTbl.Rows.Count > 0)
        {

            for (int i = 0; i < resultTbl.Rows.Count; i++)
            {
                JSONString.Append("{");
                for (int j = 0; j < resultTbl.Columns.Count; j++)
                {
                    if (j < resultTbl.Columns.Count - 1)
                    {
                        JSONString.Append("\"" + resultTbl.Columns[j].ColumnName.ToString() + "\":" + "\"" + resultTbl.Rows[i][j].ToString() + "\",");
                    }
                    else if (j == resultTbl.Columns.Count - 1)
                    {
                        JSONString.Append("\"" + resultTbl.Columns[j].ColumnName.ToString() + "\":" + "\"" + resultTbl.Rows[i][j].ToString() + "\"");
                    }
                }
                if (i == resultTbl.Rows.Count - 1)
                {
                    JSONString.Append("}");
                }
                else
                {
                    JSONString.Append("},");
                }
            }

        }
        return JSONString.ToString();
    }
    // QRCode genration code       
    public string QRCodeGenration(string txtQRCode, JObject requestModel)
    {
        var SigBase64 = "";
        if (!(string.IsNullOrEmpty(txtQRCode)))
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                var bitmapBytes = BitmapToBytes(qrCodeImage); //Convert bitmap into a byte array
                SigBase64 = Convert.ToBase64String(bitmapBytes);
            }
            catch (Exception ex)
            {
                String Exception = "Exception occurred in api method : QRCodeGenration() ," + ex.Message;
                ExceptionSave(requestModel, Exception, "QRCodeGenration");
            }
        }
        return SigBase64;
    }
    private static byte[] BitmapToBytes(Bitmap img)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }

    public FileAttachmentModel QRImageupload(string QRCode)
    {
        FileAttachmentModel fileAttachmentParameter = new FileAttachmentModel();
        fileAttachmentParameter.FilePath = null;
        fileAttachmentParameter.Name = "QR.png";
        fileAttachmentParameter.Type = "image / png";
        fileAttachmentParameter.Size = 10024;
        fileAttachmentParameter.Content = QRCode;
        fileAttachmentParameter = UploadFile(fileAttachmentParameter, "QRCodeDocs", "QRCode", true);

        return fileAttachmentParameter;
    }

    public JsonResult EncryptionString(String ActionSP)
    {
        EncryptionDecryption encryptionDecryption = new EncryptionDecryption();
        return new JsonResult(encryptionDecryption.Encrypt(ActionSP));
    }

    public JsonResult TruCrmPostData(dynamic dynamicModel, String AgencyId, String AgencyPass)
    {
        EncryptionDecryption encryptionDecryption = new EncryptionDecryption();
        if (AgencyId == encryptionDecryption.Decrypt(AgencyPass))
        {
            AgencyMasterModel agencyMasterModel = new AgencyMasterModel();
            responseResult = SelectAgencyFlag(AgencyId);
            if (responseResult.Successful == true && responseResult.Data != null && responseResult.Data.Count > 0)
            {
                agencyMasterModel.Status = responseResult.Data[0].Status;

                switch (responseResult.Data[0].Status)
                {
                    case true:
                        dynamicModel.AgencyId = AgencyId;

                        String url = config["TRU_CRM_API:InsertEnquiry"];
                        var client = new RestClient(url);
                        var request = new RestRequest(url, Method.Post);

                        request.AddHeader("content-type", "application/json");
                        String data = dynamicModel.ToString();
                        request.AddParameter("application/json", data, ParameterType.RequestBody);
                        client.Execute(request);
                        break;
                    case false:
                        SaveAgencyInsertLog(dynamicModel, AgencyId, agencyMasterModel);
                        break;
                }
            }
            else
            {
                SaveAgencyInsertLog(dynamicModel, AgencyId, agencyMasterModel);
            }
        }
        else
        {
            responseResult = new APIResponse();
            responseResult.Data = "Unauthorized user";
            responseResult.Exception = "Please contact support";
        }
        return new JsonResult(responseResult);
    }
    public APIResponse SelectAgencyFlag(string AgencyId)
    {
        AgencyMasterSearchModel agencyMasterSearchModel = new AgencyMasterSearchModel();
        agencyMasterSearchModel.Input = "CheckStatus";
        agencyMasterSearchModel.APIId = AgencyId;
        requestModel = CreateRequestModel(this.userParameter, agencyMasterSearchModel, StoredProcedureNames.AgencyMaster_Search_Select);
        responseResult = clientResponse.GetItems(requestModel);
        return responseResult;
    }
    public APIResponse SaveAgencyInsertLog(dynamic dynamicModel, string AgencyId, AgencyMasterModel agencyMasterModel)
    {
        agencyMasterModel.Input = "LogInsert";
        agencyMasterModel.Remark = dynamicModel.ToString();
        agencyMasterModel.APIId = AgencyId;
        requestModel = CreateRequestModel(this.userParameter, agencyMasterModel, StoredProcedureNames.AgencyMaster_InsertUpdate);
        APIResponse response = clientResponse.SaveItems(requestModel);
        return response;
    }
    public JsonResult GetVendorsAndEmployeesNames(VendorAndEmployeeModel vendorandemployeemodel)
    {
        requestModel = CreateRequestModel(this.userParameter, vendorandemployeemodel, StoredProcedureNames.SelectAll_VendorAndEmployeeNames);
        responseResult = clientResponse.GetItems(requestModel);
        if (responseResult.Data.Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
        }
        return new JsonResult(responseResult);
    }
    public JsonResult GetProjectsByModule(ProjectsByModule projectsByModule)
    {
        requestModel = CreateRequestModel(this.userParameter, projectsByModule, StoredProcedureNames.GetProjectsByModule);
        responseResult = clientResponse.GetItems(requestModel);
        if (responseResult.Data.Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
        }
        return new JsonResult(responseResult);
    }
    /// <summary>
    /// Check Exists or not
    /// </summary>
    /// <param name="isExistsModel"></param>
    /// <returns></returns>
    public JsonResult IsAlreadyExists(IsExistsModel isExistsModel)
    {
        requestModel = CreateRequestModel(this.userParameter, isExistsModel, StoredProcedureNames.Check_IsAlreadyExists);
        responseResult = clientResponse.GetSetItems(requestModel);
        if (responseResult.Data[0].Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
        }
        return new JsonResult(responseResult);
    }
    private DataTable GetDataTableFromExcel(Stream stream, bool hasHeader = true)
    {
        using (var pck = new ExcelPackage())
        {
            pck.Load(stream);

            var ws = pck.Workbook.Worksheets.First();
            DataTable tbl = new DataTable();
            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
            {
                tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }
            var startRow = hasHeader ? 2 : 1;
            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                DataRow row = tbl.Rows.Add();
                for (int colNum = 0; colNum < tbl.Columns.Count; colNum++)
                {
                    if (wsRow.Count() > colNum)
                    {
                        row[colNum] = wsRow.ElementAt(colNum).Text;
                    }
                    else
                    {
                        row[colNum] = "";
                    }
                }
            }
            return tbl;
        }
    }
    public DataTable ConvertBulkListToDataTable(List<FileAttachmentModel> Files)
    {
        DataTable dataTable = new DataTable();
        try
        {
            byte[] bytes = Files.Count() > 0 ? (Convert.FromBase64String(Files[0].Content)) : new byte[0];
            Stream file = new MemoryStream(bytes);
            dataTable = GetDataTableFromExcel(file, true);
        }
        catch (Exception ex)
        {
            requestModel = CreateRequestModel(this.userParameter, requestModel, null);
            responseResult.Data = "Some technical issue: " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            responseResult.Successful = false;
            responseResult.Exception = ex.Message;
            clientResponse.SaveExceptionLogs(requestModel, responseResult);
        }
        return dataTable;
    }
    public JsonResult ExcelToJson(List<FileAttachmentModel> Files)
    {
        ExcelPackage package = null;
        ExcelWorksheet worksheet = null;
        byte[] bytes = Convert.FromBase64String(Files[0].Content);
        Stream file = new MemoryStream(bytes);
        DataTable dataTable = new DataTable();
        try
        {
            using (package = new ExcelPackage(file))
            {
                worksheet = package.Workbook.Worksheets[0];
                for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                {
                    dataTable.Columns.Add(worksheet.Cells[1, col].Value.ToString());
                }

                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {
                        dataRow[col - 1] = (worksheet.Cells[row, col].Value ?? string.Empty).ToString();
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
        }
        catch (Exception ex)
        {
            package.Dispose();
            worksheet.Dispose();
            GC.SuppressFinalize(package);
            GC.SuppressFinalize(worksheet);
            return new JsonResult("Leads did not get uploaded due to some technical issue. Please contact administrator.");
        }
        responseResult = new APIResponse();
        responseResult.Data = dataTable;
        return new JsonResult(responseResult);
    }

    public JsonResult TRU_Contact_Insert(ContactModelInsert contactModelInsert)
    {
        requestModel = CreateRequestModel(this.userParameter, contactModelInsert, StoredProcedureNames.SP_Employee_TRU_Contact_Insert);
        responseResult = clientResponse.SaveDataTableItems(requestModel, contactModelInsert);
        return new JsonResult(responseResult);
    }

    /// <summary>
    /// Check Exists or not
    /// </summary>
    /// <param name="isExistsModelColdCalling"></param>
    /// <returns></returns>
    public JsonResult IsAlreadyExistsColdCalling(IsExistsModelColdCalling isExistsModelColdCalling)
    {
        requestModel = CreateRequestModel(this.userParameter, isExistsModelColdCalling, StoredProcedureNames.Check_IsAlreadyExistsColdCalling);
        responseResult = clientResponse.GetSetItems(requestModel);
        if (responseResult.Data[0].Count == 0 || responseResult.Data == null)
        {
            responseResult.Exception = "No Data Found";
        }
        return new JsonResult(responseResult);
    }
    public JsonResult UpdateEmailApproveReject(UpdateEmailApproveRejectModel updateEmailApproveRejectModel)
    {
        switch (updateEmailApproveRejectModel.Module)
        {
            case "Sales":
                GetApproveRejectEmailSales(updateEmailApproveRejectModel);
                break;
            case "HRMS":
                GetApproveRejectEmailHRMS(updateEmailApproveRejectModel);
                break;
        }
        return new JsonResult(responseResult);
    }

    public JsonResult GetApproveRejectEmailSales(UpdateEmailApproveRejectModel updateEmailApproveRejectModel)
    {
        string TemplateName = null;
        requestModel = CreateRequestModel(this.userParameter, updateEmailApproveRejectModel, StoredProcedureNames.EmailApproveRejectTransaction_Update);
        responseResult = clientResponse.GetItems(requestModel);
        JObject Jdata = JObject.FromObject(responseResult.Data[0]);
        switch (Convert.ToString(Jdata.GetValue("RequestType")))
        {
            case "Source Changed":
                {
                    TemplateName = "Email-ChangeReferredByRequest_Approved";
                }
                break;
            case "EOI Cheque":
                {
                    TemplateName = "Email_ChequeDetail_status";
                }
                break;
        }
        if (!string.IsNullOrEmpty(Convert.ToString(Jdata.GetValue("EmailStatus"))) && !string.IsNullOrEmpty(Convert.ToString(Jdata.GetValue("Email"))) && TemplateName != null)
        {
            var emailSMSPersonalization = new EmailSMSPersonalization(config);
            {
                emailSMSPersonalization.SendEmailSmsAsync(TemplateName, Jdata, WebAPICommon.GetUserJSONObject(this.userParameter), null, Convert.ToString(Jdata.GetValue("Email")), "Employee");
            }
        }
        return new JsonResult(responseResult);
    }

    public JsonResult GetApproveRejectEmailHRMS(UpdateEmailApproveRejectModel updateEmailApproveRejectModel)
    {
        string SPName = "[dbo].[HRMS_EmailApproveRejectTransaction_Update]";
        requestModel = CreateRequestModel(this.userParameter, updateEmailApproveRejectModel, SPName);
        responseResult = clientHrResposne.GetItems(requestModel);
        if (responseResult.Successful && responseResult.Data.Count > 0)
        {
            JObject Data = JObject.FromObject(responseResult.Data[0]);
            if (!string.IsNullOrEmpty(Convert.ToString(Data.GetValue("EmailId"))))
            {
                var emailSMSPersonalization = new EmailSMSPersonalization(config);
                {
                    emailSMSPersonalization.SendEmailSmsAsync(Data.GetValue("TriggerName").ToString(), Data, null, null, Convert.ToString(Data.GetValue("EmailId")), "Employee");
                }
            }
        }
        return new JsonResult(responseResult);
    }

    public IActionResult Treos_postData(JToken postDataModel, String Website = null)
    {
        try
        {
            string jsonString = Convert.ToString(postDataModel);
            ITreos_postDataModel treos_PostDataModel = new ITreos_postDataModel();

            treos_PostDataModel.data = jsonString;
            treos_PostDataModel.Website = Website;

            requestModel = CreateRequestModel(null, treos_PostDataModel, StoredProcedureNames.Treos_PostDataTable_InsertUpdate);
            responseResult = clientResponse.SaveItems(requestModel);
            if (responseResult.Successful)
            {
                return new JsonResult(responseResult);
            }
            else
            {
                return new EmptyResult();
            }
        }
        catch (Exception ex)
        {
            return new EmptyResult();
        }
    }

}