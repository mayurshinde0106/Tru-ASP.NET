using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using TRU.Employee.WebAPI.BAL;
using TRU.Employee.WebAPI.Helpers;
using TRU.Employee.WebAPI.Models;
using TRU.Employee.WebAPI.Models.Employee;
using TRU.Employee.WebAPI.Models.ImageModel;

namespace TRU.Employee.WebAPI.Controllers;
[Produces("application/json")]
public class CommonController : Controller
{
    Common common = null;
    IConfiguration config;

    public CommonController(IConfiguration _config, IOptions<ConnectionStrings> _connectionString)
    {
        config = _config;
        common = new Common(config, _connectionString);
    }

    // insert Assete data 
    [HttpPost()]
    [Route("PostAssetDetails")]

    public IActionResult PostAssetDetails([FromBody] Asset_PostDataModel asset_PostDataModel)
    {
        return common.PostAssetDetails(asset_PostDataModel);
    }

    // Get Asset data 
    [HttpGet()]
    [Route("GetAssetDetails")]

    public JsonResult GetAssetDetails()
    {
        return common.GetAssetDetails();
    }


    //  Update Asset Data
    [HttpPut]
    [Route("api/UpdateAssetDetail")]
    public JsonResult UpdateAssetDetail(Asset_PostDataModel asset_PostDataModel)
    {
        return common.UpdateAssetDetail(asset_PostDataModel);
    }

    //  Delete Asset Data
    [HttpPut]
    [Route("api/DeleteAssetDetail")]
    public JsonResult DeleteAssetDetail(Asset_PostDataModel asset_PostDataModel)
    {
        return common.DeleteAssetDetail(asset_PostDataModel);
    }




    // Get the Employee data for login 
    [HttpGet]
    [Route("api/GetEmployeeLogin")]
    public JsonResult GetEmployeesDetails(String Mail,String Password)
    {
        return common.GetlEmployeesDetail(Mail,Password);
    }

    // post the EMployeeLogin Details
    [HttpPost()]
    [Route("SetEmployeesDetails")]

    public IActionResult SetEmployeesDetail([FromBody] Employee_postDataModel emp_PostDataModel)
    {
        return common.SetEmployeesDetails(emp_PostDataModel);
    }

    // Post or add the student data 

    [HttpPost()]
    [Route("SetStudentData")]

    public IActionResult SetStudentData([FromBody] Student_PostDataModel stu_PostDataModel)
    { 
        return common.SetStudentDetailData(stu_PostDataModel);
    }

    // POST: api/UploadImage
    [Route("api/UploadImage")]
    [HttpPost]
    public async Task<JsonResult> UploadImage(ICollection<IFormFile> files)
    {
        ImageParameter imageParameter = new ImageParameter();
        imageParameter.IssueId = 1234;
        imageParameter.ImageType = "Upload";
        return await common.UploadImage(imageParameter, files);
    }
    
    // GET: api/EmployeeNames
    [HttpGet]
    [Route("api/GetAllEmployeeNames")]
    public JsonResult GetAllEmployeesNames()
    {
        return common.GetAllEmployeesNames();
    }
    // GET: api/EmployeeRoles     
    [HttpGet]
    [Route("api/GetAllEmployeeRoles")]
    public JsonResult GetAllEmployeesRoles()
    {
        return common.GetAllEmployeesRoles();
    }

    // GET: api/EmployeeNamesByRole
    [HttpGet]
    [Route("api/GetAllEmployeeNames_ByRole")]
    public JsonResult GetAllEmployeesNames_ByRole(EmployeeRole employeeRole)
    {
        return common.GetAllEmployeesNames_ByRole(employeeRole);
    }

    // GET: api/GetAllFileNames
    [HttpGet]
    [Route("api/GetAllFileNames")]
    public JsonResult GetAllFileNames()
    {
        return common.GetAllFileNames();
    }
    // GET: api/GetContentByFileName/FileName
    [HttpGet]
    [Route("api/GetContentByFileName/FileName,ContentType")]
    public JsonResult GetContentByFileName(FileNameParam fileNameParam)
    {
        return common.GetContentByFileName(fileNameParam);
    }
    //PUT: api/UpdateUtilityFlag
    [HttpPut]
    [Route("api/UpdateUtilityFlag")]
    public JsonResult SetFlag(SetFlagModel setFlagModel)
    {
        return common.setFlag(setFlagModel);
    }
    //GET: api/GetAllUtilityFlagStatus
    [HttpGet]
    [Route("api/GetAllUtilityFlagStatus")]
    public JsonResult GetAllFlag()
    {
        return common.getAllFlag();
    }

    // GET: api/GetAllOrganization
    [HttpGet()]
    [Route("api/GetAllOrganization/UserId,EntityId,UserType")]
    public JsonResult GetAllOrganization(int UserId, EmployeeParameter employeeParameter)
    {
        common.userParameter.UserId = UserId;
        common.userParameter.UserType = employeeParameter.UserType;
        return common.GetAllOrganization();
    }

    // GET: api/GetAllOrganization
    [HttpGet()]
    [Route("api/IsAllReadyExists/UserId,EntityId,UserType")]
    public JsonResult IsAllReadyExists(int UserId, EmployeeParameter employeeParameter, ExistsParameter existsParameter)
    {
        common.userParameter.UserId = UserId;
        common.userParameter.UserType = employeeParameter.UserType;
        return common.IsAllReadyExists(existsParameter);
    }

    [HttpPost()]
    [Route("EncryptionString/ActionAPI")]
    public JsonResult EncryptionString(String ActionAPI)
    {
        return common.EncryptionString(ActionAPI);
    }

    [HttpPost()]
    [Route("TruCrmPostData")]
    public JsonResult TruCrmPostData([FromBody] JObject dynanicModel, String AgencyId, String AgencyPass)
    {
        return common.TruCrmPostData(dynanicModel, AgencyId, AgencyPass);
    }
    // GET: api/VendorAndEmployeeNames
    [HttpGet()]
    [Route("api/GetVendorsAndEmployeesNames/UserId,EntityId,UserType")]
    public JsonResult GetVendorsAndEmployeesNames(int UserId, EmployeeParameter employeeParameter, VendorAndEmployeeModel vendorandemployeemodel)
    {
        common.userParameter.UserId = UserId;
        common.userParameter.UserType = employeeParameter.UserType;
        return common.GetVendorsAndEmployeesNames(vendorandemployeemodel);
    }
    // GET: api/GetProjectsByModule for module wise projects
    [HttpGet()]
    [Route("api/GetProjectsByModule/ModuleId")]
    public JsonResult GetProjectsByModule(int UserId, EmployeeParameter employeeParameter, ProjectsByModule projectsByModule)
    {
        common.userParameter.UserId = UserId;
        common.userParameter.UserType = employeeParameter.UserType;
        return common.GetProjectsByModule(projectsByModule);
    }
    // GET: api/IsAlReadyExists
    [HttpGet()]
    [Route("api/IsAlreadyExists/UserId,EntityId,UserType")]
    public JsonResult IsAlreadyExists(int UserId, EmployeeParameter employeeParameter, IsExistsModel isExistsModel)
    {
        common.userParameter.UserId = UserId;
        common.userParameter.UserType = employeeParameter.UserType;
        return common.IsAlreadyExists(isExistsModel);
    }
    [HttpPost()]
    [Route("TRU_Contact_Insert")]
    public JsonResult TRU_Contact_Insert(int UserId, EmployeeParameter employeeParameter, [FromBody] ContactModelInsert contactModelInsert)
    {
        common.userParameter.UserId = UserId;
        common.userParameter.UserType = employeeParameter.UserType;
        return common.TRU_Contact_Insert(contactModelInsert);
    }

    [HttpPost()]
    [Route("ExcelToJson")]
    public JsonResult ExcelToJson(int UserId, EmployeeParameter employeeParameter, [FromBody] ExcelFileToJsonModel excelFileToJsonModel)
    {
        common.userParameter.UserId = UserId;
        common.userParameter.UserType = employeeParameter.UserType;
        return common.ExcelToJson(excelFileToJsonModel.Files);
    }
    // GET: api/IsAlreadyExistsColdCalling
    [HttpGet()]
    [Route("api/IsAlreadyExistsColdCalling/UserId,EntityId,UserType")]
    public JsonResult IsAlreadyExistsColdCalling(int UserId, EmployeeParameter employeeParameter, IsExistsModelColdCalling isExistsModelColdCalling)
    {
        common.userParameter.UserId = UserId;
        common.userParameter.UserType = employeeParameter.UserType;
        return common.IsAlreadyExistsColdCalling(isExistsModelColdCalling);
    }
    [HttpGet()]
    [Route("api/UpdateEmailApproveReject/UserId,EntityId,UserType")]
    public ActionResult UpdateEmailApproveReject(UpdateEmailApproveRejectModel updateEmailApproveRejectModel)
    {
        var result = common.UpdateEmailApproveReject(updateEmailApproveRejectModel);
        JObject Jdata = JObject.FromObject(result.Value);
        string HTMLContent = "";
        if ((Convert.ToBoolean(Jdata.GetValue("Successful"))) == true)
        {
            if (Jdata["Data"] != null && Jdata["Data"].HasValues && Jdata["Data"][0]["htmlContent"] != null)
            {
                HTMLContent = $"" + Jdata["Data"][0]["htmlContent"].ToString();
            }
            else
            {
                HTMLContent = $"" + config["EmailResponse:SuccessMessage"];
            }
        }
        else
        {
            HTMLContent = $"" + config["EmailResponse:FailMessage"];
        }
        return Content(HTMLContent, "text/html");
    }
    [Route("Treos_postData/Website")]
    [HttpPost]
    public IActionResult TreosPostData([FromBody] JToken inBoundGupshupWhatsApp, string Website)
    {
        return common.Treos_postData(inBoundGupshupWhatsApp, Website);
    }
}
