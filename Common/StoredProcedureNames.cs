namespace TRU.Employee.WebAPI.BAL;
public class StoredProcedureNames
{
    #region EmployeeProfile
    public const string Select_BroucherProjectName = "dbo.[Employee_PreSales_Email_ProjectName_SelectAll]";
    public const string Select_BroucherByProjectName = "dbo.[Employee_PreSales_GetBroucherBy_ProjectName]";
    #endregion
    #region EmployeeDashboard
    public const string Dashboard_SearchResult = "dbo.Employee_Dashboard";
    public const string Insert_CallDetails = "dbo.Tru_Call_InsertDetails";
    public const string Update_CallDetails = "dbo.[Tru_Call_UpdateDetails_StatusCallBack]";
    public const string Insert_OfflineCallDetails = "dbo.[Tru_Call_InsertOfflineDetails]";
    public const string Insert_EmailDetails = "[dbo].[Marketing_Email_InsertDetails]";
    public const string Insert_SMSDetails = "dbo.Tru_SMS_InsertDetails";
    public const string GetCountForDashboard = "dbo.[Employee_SalesDashboard_GetCount]";
    public const string GetModalDetailsForDashboard = "dbo.[Employee_SalesDashboard_DetailsForModal]";
    public const string Insert_CallNotification = "dbo.[Tru_Call_Notification_InsertDetails]";
    public const string Select_CallNotification = "dbo.[Tru_Call_Notification_SelectDetails]";
    public const string GetEmployeeTodaysLogin = "dbo.[EmployeeTodaysLogin_Identifier]";
    public const string Select_Conversations = "[dbo].[Employee_Conversations_Select]";
    public const string MobileApp_GetAppAnalytics = "dbo.[GetAppAnalytics]";
    public const string Insert_UpdateUserNotifId = "[dbo].[Employee_Signalid_InsertUpdate]";
    public const string Insert_ColdCallingDetails = "[dbo].[Employee_Insert_ColdCallingDetails]";
    public const string Insert_OfflineColdCallingDetails = "[dbo].[Employee_Insert_OfflineColdCallingDetails]";
    public const string SOP_Presales_PopUp_Report = "[dbo].[SOP_Presales_PopUp_Report]";
    #endregion
    #region EmployeeDashboardViewDetails
    public const string Dashboard_ViewDetail = "dbo.Employee_DashBoard_ViewDetail";
    public const string Order_Status = "dbo.Employee_Dashboard_OrderStatus";
    public const string Referral_Status = "dbo.Employee_Dashboard_ReferralStatus";
    public const string Issue_Status = "dbo.Employee_Dashboard_IssueStatus";
    public const string Dashboard_ServiceRequest = "dbo.Employee_DashBoard_ServiceRequestALL";
    public const string Dashboard_ServiceRequestByEmployee = "dbo.Employee_DashBoard_ServiceRequest_Employee";
    #endregion
    #region ProjectMaster
    public const string SelectAll_ProjectMasterData = "dbo.Employee_ProjectMaster_SelectAll";
    public const string InsertUpate_ProjectMasterData = "[dbo].[Employee_ProjectMaster_Insert_Update]";
    public const string Insert_ProjectMasterData = "dbo.Employee_ProjectMaster_Insert";
    public const string SelectByName_ProjectMasterData = "dbo.Employee_ProjectMaster_SelectProjectByName";
    public const string Update_ProjectMasterData = "dbo.Employee_ProjectMaster_Update";
    public const string SELECT_DuplicateProjectName = "dbo.Employee_ProjectMaster_DuplicateProjectName";
    public const string SELECT_ProjectId = "dbo.Project_Mapping_select";
    public const string Select_Phase1ProjectID = "[dbo].[Project_Mapping_Select]";
    public const string Select_ExecutionProjectStatus = "[dbo].[Project_Completion_Status_Select]";
    public const string Insert_ProjectMapping = "[dbo].[Project_Mapping_Insert]";
    public const string Insert_ProjectMappinginPh2 = "[dbo].[Project_Mapping_ExecutionInsert]";
    #endregion
    #region ProjectDetails
    public const string Insert_ProjectDetailsData = "dbo.Employee_ProjectDetails_Insert";
    public const string Update_ProjectDetailsData = "dbo.Employee_ProjectDetails_Update";
    public const string Update_ProjectDetailsRate = "dbo.Employee_ProjectDetails_Rate_Update";
    public const string SELECT_RateFromProjectMaster = "dbo.Employee_rateByProjectName";
    public const string SELECT_ProjectDetails = "dbo.Employee_ProjectDetails_Select";
    public const string SELECT_DuplicateFlat = "dbo.Employee_ProjectDetails_DuplicateFlatNo";
    public const string Update_FlatAvailibility = "dbo.[Employee_ProjectDetails_FlatAvailibility_Update]";
    public const string Insert_ParkingDetailsData = "dbo.[ProjectDetails_ParkingDetails_InsertUpdate]";
    #endregion
    #region CROAdminDashboard
    #endregion
    public const string NameSelectOnId = "[dbo].[Employee_Name_Select_On_Id]";
    public const string SELECT_Report_CRO_Lead_Analysis = "[dbo].[Report_CRO_Lead_Analysis]";
    public const string SELECT_CRO_Leads_ByCROId = "[dbo].[CRO_Leads_Select]";
    public const string SELECT_GetEmployeeDetail = "[dbo].[GetEmployee]";
    public const string sp_InsertEmployeeLogin = "[dbo].[InsertEmployee]";

    public const string sp_InsertStudetD = "[dbo].[InsertStudent]";

    public const string sp_InsertAssetData = "[dbo].[AssetOperation]";
    public const string sp_SelectAssetData = "[dbo].[AssetView]";

    #region LeadDashboard
    public const string SELECT_BY_Name_Referral = "dbo.Employee_LeadDashboard_SelectByName";
    public const string SELECT_ALL_Referral = "dbo.Employee_LeadDashboard_SelectAll";
    public const string SELECT_ALL_LeadForFrontDeskOrAdmin = "dbo.[Employee_LeadDashboard_FrontDeskOrAdmin_SelectAll]";
    public const string Update_ReferralStatus = "dbo.Employee_LeadDashboard_Update";
    public const string SELECT_ReportingTo = "dbo.Employee_ReportingTo_Select";
    public const string Insert_FollowUp = "dbo.[Employee_LeadDashboard_Update_FollowUp]";
    public const string Update_SiteVisitTime = "[Employee_LeadDashboard_UpdateSiteVisitTime]";
    public const string SELECT_AppDetails = "dbo.[Employee_Leads_AppDetails_Select]";
    public const string SELECT_ByReferralId = "dbo.[Employee_LeadDashboard_Referral_Select]";
    public const string SELECT_NewLeads = "dbo.[Employee_FrontDesk_NewLeads]";
    public const string SELECT_NewLeadsSummary = "dbo.[Employee_FrontDesk_NewLeadsSummary]";
    public const string SELECT_Marketing_Analysis_list = "[dbo].[Report_Marketing_Analysis]";
    public const string UPDATE_MergeLead = "[dbo].[Employee_Sales_Lead_Merge]";
    public const string Select_Survey_Lead = "[dbo].[Employee_Survey_Referral_Select]";
    public const string Employee_ChequeDetails_Insert_Update = "[dbo].[Employee_ChequeDetails_Insert_Update]";
    public const string Employee_Select_ChequeDetails = "[dbo].[Employee_Select_ChequeDetails]";
    #endregion
    #region CustomerInteraction
    public const string INSERT_Interaction = "dbo.Employee_Interaction_Insert";
    public const string CP_CRO_Interaction = "dbo.Employee_CP_CRO_FollowUp";
    public const string SELECT_Employee_Interaction = "dbo.Employee_Interaction_SelectAll";
    public const string SELECT_Entity_Interaction = "dbo.Employee_Interaction_Select";
    public const string Select_Data_By_Id = "dbo.Interaction_Select_Enquiy_Referral_Data_ById";
    public const string Insert_Update_Cancel_Site_Visit = "[dbo].[Employee_SiteVisit_Insert_Update_Cancel]";
    #endregion
    #region CustomerOrder
    public const string SELECT_Order = "CustomerOrder_Order_Select";
    public const string SELECT_OrderStatus = "dbo.CustomerOrder_OrderStatus_SelectAll";
    public const string INSERT_Order = "dbo.CustomerOrder_Insert";
    public const string UPDATE_Agreement_Order = "dbo.CustomerOrder_AgreementStatus_Update";
    public const string UPDATE_Order = "dbo.CustomerOrder_Update";
    public const string DELETE_Order = "dbo.CustomerOrder_Delete";
    public const string SELECT_BrokerAssigned = "dbo.CustomerOrder_BrokerAssigned_Select";
    public const string SEARCH_OrderSummary = "dbo.[Employee_Order_Summary]";
    public const string SEARCH_OrderSummaryDetails = "dbo.[Employee_Order_Summary_Details]";
    public const string SELECT_ParkingDetailsOnBuildingType = "[dbo].[ParkingDetailsOnBuildingType_Select]";
    public const string Select_CRMDashboardCount = "dbo.[Employee_CRMDashboard_Count]";
    public const string Select_CRMDashboardDetails = "dbo.[Employee_CRMDashboard_Details]";
    public const string Update_OCRDetails = "dbo.[CustomerOrder_OCR_Update]";
    public const string Update_CPOrderVerification = "[dbo].[CPOrderVerification_Update]";
    public const string Incentive_Transaction = "[dbo].[DPMIncentive_Transaction]";



    #endregion
    #region Ratio       
    public const string Select_RatioAll = "Ratio_SelectByDateAndProject";
    #endregion

    #region PaymentStatus
    public const string SELECT_PaymentStatus = "dbo.Employee_PaymentStatus_Select";
    public const string SELECT_PaymentStatuses = "dbo.ChannelPartner_PaymentStatus_SelectAll";
    public const string SELECT_OrderDetailsByBrokerId = "dbo.ChannelPartner_Order_Select";
    public const string INSERT_PaymentStatus = "dbo.Employee_PaymentStatus_Insert";
    public const string UPDATE_PaymentStatus = "dbo.Employee_PaymentStatus_Update";
    #endregion

    #region CustomerReceipt
    public const string SELECT_CustomerReceipt = "dbo.Employee_CustomerReceipt_Select";
    public const string INSERT_CustomerReceipt = "dbo.Employee_CustomerReceipt_Insert";
    public const string UPDATE_CustomerReceipt = "dbo.Employee_CustomerReceipt_Update";
    public const string SELECT_LegalDetails = "dbo.Project_LeagalEntityDetails";
    #endregion

    #region Common
    public const string Select_ProjectImageUrl = "[dbo].[Employee_Tru_Images_Insert]";
    public const string Update_ProjectImageUrl = "[dbo].[Employee_Tru_Images_Update]";
    public const string Select_Documents = "[dbo].[Employee_Tru_Images_Select]";
    public const string Delete_ImageUrl = "[dbo].[Employee_Tru_Images_Delete]";
    public const string SelectAll_EmployeeNames = "[dbo].[EmployeeNames_SelectAll]";
    public const string SelectAll_EmployeesRoles = "[dbo].[EmployeeRole_SelectAll]";
    public const string SelectAll_EmployeeNames_ByRole = "[dbo].[EmployeeNames_SelectAll_ByRole]";
    public const string SelectAll_SalesEmployeesRoles = "[dbo].[Employee_SalesId_SelectAll]";
    public const string SelectAll_Keys = "[dbo].[Key_Content_GetAll]";
    public const string Select_Contents = "[dbo].[Key_Content_Match]";
    public const string Select_DuplicateProjectName = "[dbo].[Employee_ProjectMaster_DuplicateProjectName]";
    public const string SelectAll_UtilityFlag = "[dbo].[UtilityFlag_GetAll]";
    public const string Select_UtilityFlag = "[dbo].[UtilityFlag_Select]";
    public const string Update_UtilityFlag = "[dbo].[UtilityFlag_Update]";
    public const string AgencyInsertData_InsertUpdate = "[dbo].[UtilityFlag_Update]";

    public const string SelectAll_VendorAndEmployeeNames = "[dbo].[HR_EmployeeAndVendorNames_SearchAndSelect]";
    public const string Check_IsAlreadyExists = "dbo.[Employee_Check_Exist_Or_Not]";
    public const string GetProjectsByModule = "dbo.[GetProjectsByModule]";
    public const string SP_Employee_TRU_Contact_Insert = "dbo.[Employee_TRU_ColdCalling_Insert]";
    public const string SP_Employee_TRU_Contact_Update = "dbo.[Employee_TRU_ColdCalling_Update]";
    public const string SP_Employee_TRU_Contact_Select = "dbo.[Employee_TRU_ColdCalling_SelectAll_ByStatus]";
    public const string Check_IsAlreadyExistsColdCalling = "dbo.[Employee_Check_Exist_Or_Not_ColdCalling]";
    public const string GetContactsourceCampaign = "dbo.[Contact_Source_Campaign_Select]";
    public const string EmailApproveRejectTransaction_Update = "[dbo].[Employee_EmailApproveRejectTransaction_Update]";
    public const string PostOrderUpdate = "dbo.[Employee_Post_Order_Update]";
    public const string StakeholderMeet_Contact_Insert_Update = "[dbo].[StakeholderMeet_Contact_Insert_Update]";
    public const string Visitors_Insert_Update = "[dbo].[Visitors_Insert_Update]";
    public const string Visitors_Select = "[dbo].[Select_Visitors]";
    public const string StakeholderMeetContactSelect = "[dbo].[StakeholderMeet_Contact_Select]";
    public const string Select_StakeholderDetails = "[dbo].[Get_Stackholder_Meet_Details]";
    public const string GetStakeholderUMSTime = "[dbo].[StakeHolderMeet_UMS_Timing]";
    public const string Customer_Possession_Insert_Update = "[dbo].[Customer_Possession_Insert_Update]";
    public const string CustomerOrderCancelSP = "[dbo].[CustomerOrder_Cancel]";
    public const string CancelOrderSelectSP = "[dbo].[Customer_CancelOrderSelect]";
    public const string Employee_ColdCallingDashboard_CountTotalAll = "[dbo].[Employee_ColdCallingDashboard_CountTotalAll]";
    public const string Employee_ColdCallingDashboard_DetailModel = "[dbo].[Employee_ColdCallingDashboard_DetailModel]";
    public static readonly string Treos_PostDataTable_InsertUpdate = "[dbo].[Treos_PostDataTable_InsertUpdate]";

    #endregion
    #region PaymentSchedule
    public const string INSERT_PaymentSchedule = "dbo.[Employee_PaymentSchedule_Insert]";
    public const string SELECT_PaymentSchedule = "dbo.Employee_PaymentSchedule_Select";
    public const string UPDATE_PaymentSchedule = "[dbo].[Employee_PaymentSchedule_Update]";
    public const string Employee_SnagListInsertUpdate = "[dbo].[Employee_SnaglistMasterInsertUpdate]";
    public const string GetFromSnagListMasterModel = "[dbo].[Select_Employee_SnagListMaster]";
    public const string Customer_SnagListUserTransInsertUpdate = "[dbo].[Customer_Snaglist_UserTransaction_Insert_Update]";
    #endregion

    #region ProjectStatus 
    public const string INSERT_ProjectStatus = "dbo.Employee_ProjectStatus_Insert";
    public const string UPDATE_ProjectStatus = "dbo.Employee_ProjectStatus_Update";
    public const string GET_DuplicateBuildingType = "dbo.Employee_ProjectStatus_DuplicateProjectStatus";
    public const string SELECT_FEEDBACK = "[dbo].[FeedBack_Select]";
    public const string INSERT_FEEDBACK = "[dbo].[FeedBack_Insert]";
    public const string Insert_PaymentMilestone = "[dbo].[Employee_ProjectStatus_Paymentmilestone_Insert]";
    public const string SELECT_PAYMENTMILESTONE = "[dbo].[Employee_ProjectStatus_Paymentmilestone_Select]";
    #endregion

    #region EmployeeAdmin
    public const string InsertEmployee = "[dbo].[Employee_Registration]";
    public const string UpdateEmployee = "dbo.Employee_Update";
    public const string GetAllEmployee = "dbo.Employee_Admin_Getdetail";
    public const string GetAuditDetail = "dbo.Audit_GetDetail";
    public const string Select_ChannelPartner = "dbo.Employee_Admin_GetAllChannelPartner";
    public const string Aproval_ChannelPartner = "dbo.Employee_Admin_CP_Approval";
    public const string Decline_ChannelPartner = "dbo.Employee_Admin_CP_Decline";
    public const string InsertTemplate = "dbo.[Key_Content_Insert]";
    public const string UpdateSMSTemplate = "dbo.Key_SMSContent_Update";
    public const string SelectAll_Organization = "dbo.ChannelPartner_Organization_SelectAll";
    public const string Update_AssignProjectToOrganization = "dbo.Employee_Admin_AssignProject_ToCP";
    public const string InsertLeadExcel = "dbo.[Lead_Excel_Import]";
    public const string Delete_LeadImport = "dbo.[Customer_Import_Temp_Delete]";
    public const string GetAllTempLeads = "dbo.[Customer_Import_Temp_Select]";
    public const string Insert_SwitchRoleRequest = "[dbo].[Employee_SwitchRoleRequest_Insert]";
    public const string GetsourceCampaign = "dbo.[Source_Campaign_Select]";
    public const string InsertSourceCampaign = "dbo.[Source_Campaign_Insert]";
    public const string Select_ApplicationLog = "dbo.[ApplicationLog_Select]";
    public const string Update_ApplicationLog = "dbo.[ApplicationLog_UpdateStatus]";
    public const string DELETE_Brochure = "dbo.[TruImages_Brochure_UpdateDelete]";
    public const string InsertLeadExcel_Migration = "dbo.[Lead_Excel_Import_Migration]";
    public const string Check_Duplicate = "dbo.[Employee_CheckDuplicate]";
    public const string AgencyMaster_InsertUpdate = "[dbo].[Employee_AgencyMaster_InsertUpdate]";
    public const string AgencyMaster_Search_Select = "[dbo].[Employee_AgencyMaster_Search_Select]";
    public const string InsertDPMIncentive = "dbo.[Employee_DPM_Incentive_InsertUpdate]";
    public const string AppSetting_Insert_Update = "dbo.[Employee_AppSetting_Insert_Update]";
    public const string Get_DiscountNames = "dbo.[Employee_Discounts_Search_Select]";
    public const string DiscountRuleBook_Insert_Update_Delete = "dbo.[Employee_DiscountRuleBook_Insert_Update_Delete]";
    public const string Select_Discount_RuleBook_Data = "dbo.[Employee_Discount_RuleBook_Search_Select]";
    public const string Discount_GroupMaster_Insert_Update_Delete = "dbo.[Employee_Discount_GroupMaster_Insert_Update_Delete]";
    public const string Select_Discount_GroupMaster = "dbo.[Employee_Discount_GroupMaster_Search_Select]";
    public const string InsertUpdateDelete_Rewards_Against_Score = "dbo.[Employee_Rewards_Against_Score_InsertUpdateDelete]";
    public const string Select_Rewards_Against_Score = "dbo.[Employee_Rewards_Against_Score_SearchAndSelect]";
    public const string InsertUpdateDelete_Rewards_Transaction = "dbo.[Employee_Rewards_Transaction_InsertUpdateDelete]";
    public const string Select_Rewards_Transaction = "dbo.[Employee_Rewards_Transaction_SearchAndSelect]";
    public const string InsertUpdate_Flagged_Entity = "dbo.[Employee_Flagged_Entity_InsertUpdate]";
    public const string Select_Flagged_Entity = "dbo.[Employee_Flagged_Entity_SearchAndSelect]";
    public const string GetImportedDetails = "dbo.[Enquiry_import_excel]";
    public const string UserMaster_Account_Status_Updation = "[dbo].[UserMasterAccountStatusUpdation]";
    public const string EmployeeSOPInsertUpdateDelete = "[dbo].[Employee_SOP_Insert_Update_Delete]";
    public const string EmployeeSOPSelect = "[dbo].[Employee_SOP_Select]";
    public const string InsertUpdate_Employee_ReportName = "[dbo].[Employee_ReportName_Insert_Update]";
    public const string Project_InsertUpdate = "[dbo].[Project_InsertUpdate]";
    public const string Project_SearchAndSelect = "[dbo].[Project_SearchAndSelect]";
    public const string GetPresalesAdmin_EmployeeDetails = "[dbo].[GetPresalesAdmin_EmployeeDetails]";
    public const string Employee_NoLeadDay_Update = "[dbo].[Employee_NoLeadDay_Update]";
    #endregion

    #region PresalesDashboard
    public const string SELECT_AllEnquiry = "dbo.Employee_PreSalesDashboard_Enquiry_SelectAll";
    public const string SELECT_AllUnQualifiedOrLostEnquiry = "dbo.[Employee_PreSalesDashboard_UnQualifiedOrLostEnquiry_SelectAll]";
    public const string SELECT_EnquiryById = "dbo.Employee_PreSalesDashboard_Enquiry_Select";
    public const string INSERT_Enquiry = "dbo.[Employee_PresalesDashboard_Enquiry_Insert]";
    public const string UPDATE_EnquiryById = "dbo.Employee_PreSalesDashboard_Enquiry_Update";
    public const string UPDATE_EnquiryFollowUp = "dbo.Employee_PreSalesDashboard_Enquiry_FollowUpUpdate";
    public const string Insert_Update_FollowUp = "dbo.Employee_Insert_Update_FollowUp";
    public const string SEARCH_Enquiry = "dbo.Employee_PreSalesDashboard_Enquiry_Search";
    public const string SEARCH_FrontDeskOrAdminForEnquiry = "dbo.Employee_FrontDeskOrAdmin_EnquiryReferral_Search";
    public const string SELECT_CallDetails = "dbo.[Tru_Call_SelectCallDetails]";
    public const string UPDATE_SiteVisit = "dbo.[Employee_PreSalesDashboard_ScheduleSiteVisit]";
    public const string SELECT_SMSDetails = "dbo.[Tru_SMS_SelectSmsDetails]";
    public const string UPDATE_MergeEnquiry = "dbo.[Employee_PreSalesDashboard_Enquiry_Merge]";
    public const string COUNTTotal = "[dbo].[Employee_PreSalesDashboard_CountTotalAll]";
    public const string SelectDashboardDetail = "dbo.[Employee_PreSalesDashboard_DetailsModel]";
    public const string Select_PresalesReferral = "[dbo].[Employee_PresalesReferral_Search]";
    public const string UPDATE_MultipleLeads = "[dbo].[Employee_PreSalesDashboard_AssignToMultipleLeads]";
    public const string SelectAll_CallObservation = "[dbo].[Marketing_CallObservation_Select]";
    public const string Select_EnquirySummary = "[dbo].[Employee_Presales_EnquirySummaryByDateRange]";
    public const string Select_EnquirySummaryDetail = "[dbo].[Employee_Presales_EnquirySummaryDetailByDateRange]";
    public const string SelectById_CallObservation = "[dbo].[Marketing_CallObservationTransaction_SearchAndSelect]";
    public const string Insert_CallObservationTransaction = "[dbo].[Marketing_CallObservationTransaction_Insert]";
    public const string Select_UnQualifiedLost = "[dbo].[Employee_PreSalesDashboard_UnQualifiedOrLostEnquiry_BySalesPresale]";
    public const string TotalCallsAndTags = "[dbo].[Employee_CallObservation_PresaleAdmin_DPM]";
    public const string selectPresalesDashboardReport = "[dbo].[PresalesDashboard_Report]";
    public const string Select_Notifications = "[dbo].[Notifications_Select]";
    public const string Update_Notifications_ReadFlag = "[dbo].[Notifications_ReadFlag_Update]";
    public const string Marketing_WorkFlow_Execution = "[dbo].[Marketing_WorkFlow_Execution]";
    #endregion

    #region Reports
    #region PipelineAnalysisReport
    public const string ReportForPipelineAnalysis = "[Report_PipelineAnalysis]";
    public const string ReportForPipelineAnalysisDetails = "[Report_PipelineAnalysis_Details]";
    #endregion
    #region callReport
    public const string CallReport = "[dbo].[Report_AllCalling]";
    #endregion
    #region SalesPerformanceReport
    public const string SalesPerformanceReport = "[dbo].[Report_Salesperformance_SiteVisitedBySales]";
    public const string SalesPerformanceReportforConducted = "[dbo].[Report_SalesPerformance_ConductedSiteByStage]";
    public const string SalesPerformanceReportforFollowupBySales = "[dbo].[Report_SalesPerformance_FollowupBySales]";
    public const string SalesPerformanceReportforBooking = "[dbo].[Report_SalesPerformance_Booking]";
    public const string SalesPerformanceReportLeadPushedBySalesandPresales = "[dbo].[Report_SalesPerformance_LeadPushedBySalesandPresales]";
    public const string SalesPerformanceReportLeadReAssigned = "[dbo].[Report_SalesPerformance_LeadReAssigned]";
    public const string SalesPerformanceReportLeadStaticsagainstsales = "[dbo].[Report_Salesperformace_LeadStaticsagainstsales]";
    public const string CallReports = "[dbo].[Report_SeniorManager_PresalesAndSales]";
    public const string GetEmployeeReportsName = "[dbo].[Employee_ReportName_Select]";
    public const string ExportEmployeeReport = "[dbo].[Employee_Reports_DownloadExcel]";
    public const string LeadAnalysis = "[dbo].[Report_LeadAnalysis]";
    public const string LeadAnalysisDetails = "[dbo].[Report_LeadAnalysis_Details]";
    public const string MissedCallAnalysis = "[dbo].[Report_MissedCall_Analysis]";
    public const string CallAnalysis = "[dbo].[Report_FirstAndLastCall]";
    public const string UntouchedAnalysis = "[dbo].[Report_UntouchedEnquiryAnalysis]";
    public const string UntouchedDetailAnalysis = "[dbo].[Report_UntouchedEnquiryAnalysisDetail]";
    public const string SiteVisitAndBooking = "[dbo].[Report_LeadAnalysis_SiteVisitAndBooking]";
    public const string SiteVisitAndBooking_Detail = "[dbo].[Report_LeadAnalysis_SiteVisitAndBookingDetail]";
    public const string SELECT_MISDashboardCount = "[dbo].[ProjectDetails_MIS_Dashboard_Count]";
    public const string Employee_MISDB_Selection = "[dbo].[Employee_MISDB_Selection]";
    public const string Execution_Meeting_MISDB_Selection = "[dbo].[Execution_Meeting_MISDB_Selection]";
    public const string MISDB_Filter_Select = "[dbo].[MISDB_Filter_Select]";
    public const string MISDB_Category_Insert_Update = "[dbo].[MISDB_Category_Insert_Update]";
    #endregion
    #endregion

    #region PowerSalesDashboard
    public const string SELECT_OrganizationDetails = "dbo.Employee_PowerSales_GetOrganizationDetails";
    public const string SELECT_ChannelPartnerDetails = "dbo.Employee_PowerSales_GetChannelPartnerDetails";
    public const string SELECT_ChannelPartnerLeadDetails = "dbo.Employee_PowerSales_GetChannelPartnerLeadDetails";
    public const string Powersales_GetCount = "dbo.[Employee_PowerSalesDashboard_GetCount]";
    public const string Powersales_ModalDetail = "dbo.[Employee_PowerSalesDashboard_DetailsForModal]";
    #endregion

    #region TRUPay
    public const string SELECT_TRUPayVirtualWallet = "[dbo].[TRUPay_TRUPayVirtual_SelectSearch]";
    public const string Insert_CPCRPSVRecord = "[dbo].[TRUPay_CPCROSVDetails_Insert]";
    public const string Insert_TRUPayVirtualWallet = "[dbo].[TRUPay_TRUPayVirtual_InsertUpdate]";
    public const string Insert_TRUPayActualWallet = "[dbo].[TRUPay_TRUPayActual_InsertUpdate]";
    public const string SELECT_TRUPayActualWallet = "[dbo].[TRUPay_TRUPayActual_SelectSearch]";
    public const string SELECT_TRUPayWithdrawalSummary = "[dbo].[TRUPayWithdrawalSummary_Select]";
    public const string Insert_TRUPayWithdrawalSummary = "[dbo].[TRUPayWithdrawalSummary_InsertUpdate]";
    public const string SELECT_AmountOnRegNo = "[dbo].[TRUPay_GetActualWalletAmountFromRegistrationNo]";
    public const string PayoutInsertUpdate = "[dbo].[TRUPay_Razorpayx_Payout_insertUpdate]";
    public const string RazorpayCreateContactInsertUpdate = "[dbo].[TRUPay_Razorpayx_contact_insertUpdate]";
    public const string RazorpayCreateFundAccInsertUpdate = "[dbo].[TRUPay_Razorpayx_FundAccount_insertUpdate]";
    public const string RazorpayPaymentLinkInsertUpdate = "[dbo].[TRUPayRazorpayxPaymentLinkInsertUpdate]";
    public const string RazorpayCreateContactCheck = "[dbo].[TRUPay_Razorpayx_contact_check]";
    public const string RazorpayCreateFundAccCheck = "[dbo].[TRUPay_Razorpayx_fundAcc_check]";
    public const string RazorpayFundAccountTypeSelect = "[dbo].[TRUPay_Razorpayx_fundAccType_Select]";
    public const string RazorpaySelectByProcessId = "[dbo].[TRUPay_Razorpayx_SelectPaymentLinktStautsProcessing]";
    public const string SelectEOIModel = "[dbo].[Employee_EOI_Details_Select]";
    #endregion
    #region TaskManagement
    public const string TaskProject_TaskMain_Insert_Update = "[dbo].[TaskProject_TaskMain_Insert_Update]";
    public const string TaskProject_SubTask_Main_InsertUpdate = "[dbo].[TaskProject_Task_SubTask_Main_InsertUpdate]";
    public const string TaskProject_TaskMain_Select = "[dbo].[TaskProject_TaskMain_Select]";
    #endregion
    #region OnBoarding
    public const string OnBoarding_Insert_Update = "[dbo].[OnBoarding_Insert_Update]";
    public const string OnBoarding_Get_Header_For_Excel = "[dbo].[OnBoarding_Get_Header_For_Excel]";
    public const string OnBoarding_Insert_BulkExcelData = "[dbo].[OnBoarding_Insert_BulkExcelData]";
    public const string OnBoarding_ExecutionExcelHeader = "[dbo].[OnBoarding_GetHeaderForExcel]";
    public const string GetCommonData = "[dbo].[OnBoarding_GetCommonData]";
    public const string OnboardingExcelUploads = "[dbo].[Onboarding_Excel_Uploads]";
    public const string OnBoarding_GetTenantDetails = "[dbo].[OnBoarding_GetTenantDetails]";
    public const string OnBoarding_Tenant_Insert_Update = "[dbo].[OnBoarding_Tenant_Insert_Update]";
    public const string OnBoarding_SubPlans_Insert_Update = "[dbo].[OnBoarding_SubPlans_Insert_Update]";
    public const string OnBoarding_SubscriptionOrder_Insert_Update = "[dbo].[OnBoarding_SubscriptionOrder_Insert_Update]";
    public const string OnBoarding_GetTenantSubscriptionOrder = "[dbo].[OnBoarding_GetTenantSubscriptionOrder]";
    public const string OnBoarding_SaveLicensingEmp = "[dbo].[OnBoarding_SaveLicensingEmp]";
    public const string OnBoarding_HRMSExcelHeader = "[dbo].[OnBoarding_HRMSExcelHeader]";
    public const string OnBoarding_InsertHRMS_BulkExcelData = "[dbo].[OnBoarding_InsertHRMS_BulkExcelData]";
    #endregion
    #region DPMPresale
    public const string EmployeeSchedule_InsertUpdate = "[dbo].[Employee_EmployeeSchedule_InsertUpdate_DPM]";
    public const string Employee_Availability = "[dbo].[Employee_Availability_DPM]";
    public const string EmployeeSchedule_Select = "[dbo].[Employee_EmployeeSchedule_Select_DPM]";
    public const string IncentivePlan_InsertUpdate = "[dbo].[IncentivePlan_InsertUpdate]";
    public const string IncentivePlan_Select = "[dbo].[IncentivePlan_Select_DPM]";
    public const string UserLoginLogout = "[dbo].[User_LoginLogout_select_DPM]";
    // public const string Update_Callrating = "[dbo].[Tru_Call_InsertUpdate_DPM]";
    // public const string Select_Callrating = "[dbo].[Tru_Call_Select_DPM]";
    public const string IncentiveTransaction_InsertUpdate = "[dbo].[IncentiveTransaction_InsertUpdate_DPM]";
    public const string IncentiveTransaction_Select = "[dbo].[IncentiveTransaction_Select_DPM]";
    public const string TotalIncentive = "[dbo].[Employee_Presales_TotalIncentive_DPM]";
    public const string Incentive_Details = "[dbo].[Employee_Presales_TotalIncentive_Details_DPM]";
    public const string Select_callRatingValues = "[dbo].[Call_Rating_Select_DPM]";
    public const string Insert_callrating = "[dbo].[Call_Rating_Insert_DPM]";
    public const string selectDPMApprove = "[dbo].[Employee_DPM_Incentive_Select]";
    public const string Incentive_Rules_InsertUpdateDelete = "[dbo].[Incentive_Rules_InsertUpdateDelete]";
    public const string Incentive_Rules_Selection = "[dbo].[Incentive_Rules_Selection]";
    #endregion

    #region Accounting
    //public const string Ph2Insert_Accounting_Sales = "[dbo].[Accounting_Sales_InsertUpdate]";
    public const string Ph2Insert_Accounting_DemandSales = "[dbo].[Accounting_DemandRaised_InsertUpdate]";
    public const string Ph2Insert_Accounting_Receipt = "[dbo].[Accounting_Receipt_InsertUpdate]";
    public const string Ph2SelectTDSRate = "[dbo].[Accounting_SelectTDSRate]";
    public const string AccountingStatusUpdate = "[dbo].[Accounting_Status_Insert]";
    public const string Ph2Insert_Accounting_Brokerage = "[dbo].[Accounting_Brokerage_InsertUpdate]";
    public const string Ph2Insert_Accounting_Payment = "[dbo].[Accounting_Payment_InsertUpdate]";
    public const string Ph2Insert_Accounting_Contra = "[dbo].[Accounting_contra_InsertUpdate]";

    #endregion

    #region WhatsAppAPI       
    public const string WhatsApp_GupshupMsg_InBound = "[dbo].[WhatsApp_GupshupMsg_InBound]";
    public const string WhatsApp_GupshupMsg_Recieve = "[dbo].[WhatsApp_GupshupMsg_Recieve]";
    public const string GupshupMsg_DialogflowResponse = "[dbo].[WhatsApp_GupshupMsg_DialogflowResponse]";
    public const string Insert_FileUrl = "[dbo].[Execution_Files_Insert]";
    public const string WhatsAppNoOptIn_Insert = "[dbo].[WhatsApp_MobileNo_OptIn_Insert]";
    #endregion

    #region DMS
    public const string DMS_InsertUpdateTemplateMaster = "dbo.[DMS_InsertUpdateTemplateMaster]";
    public const string DMS_InsertUpdateModule = "dbo.[DMS_InsertUpdateModule]";
    public const string DMS_InsertUpdateProcess = "dbo.[DMS_InsertUpdateProcess]";
    public const string DMS_InsertUpdateImportModule = "dbo.[DMS_InsertUpdateImportModule]";
    public const string DMS_InsertUpdateImportProcess = "dbo.[DMS_InsertUpdateImportProcess]";
    public const string DMS_InsertUpdateImportDocument = "dbo.[DMS_InsertUpdateImportDocument]";
    public const string DMS_InsertUpdateDocument = "dbo.[DMS_InsertUpdateDocument]";
    public const string DMS_ImportTemplateToProject = "dbo.[DMS_ImportTemplateToProject]";
    public const string DMS_ImportDataForInitiateProject = "dbo.[DMS_ImportDataForInitiateProject]";
    public const string DMS_GetModulesByProjectId = "dbo.[DMS_GetModulesByProjectId]";
    public const string DMS_GetProcessesByModuleId = "dbo.[DMS_GetProcessesByModuleId]";
    public const string DMS_GetAllProcesses = "dbo.[DMS_GetAllProcesses]";
    public const string DMS_GetAllModules = "dbo.[DMS_GetAllModules]";
    public const string DMS_GetAllDocuments = "dbo.[DMS_GetAllDocuments]";
    public const string DMS_GetAllTemplates = "dbo.[DMS_GetAllTemplates]";
    public const string DMS_GetDocumentsByProcessId = "dbo.[DMS_GetDocumentsByProcessId]";
    public const string DMS_GetDocumentById = "dbo.[DMS_GetDocumentById]";
    public const string DMS_GetProcessById = "dbo.[DMS_GetProcessById]";
    public const string DMS_GetModuleById = "dbo.[DMS_GetModuleById]";
    public const string DMS_GetFilesByDocumentId = "dbo.[DMS_GetFilesByDocumentId]";
    public const string DMS_UploadDocumentFile = "dbo.[DMS_UploadDocumentFile]";
    public const string DMS_UploadDocumentFileByLink = "DMS_UploadDocumentFileByLink";
    public const string DMS_GetAuditLogById = "dbo.[DMS_GetAuditLogById]";
    public const string DMS_InsertUpdateAuditLog = "dbo.[DMS_InsertUpdateAuditLog]";
    public const string DMS_InitiateProject = "dbo.[DMS_InitiateProject]";
    public const string DMS_getDmsDropdown = "dbo.[DMS_GetDMSDropdown]";
    public const string DMS_GlobalSearch = "dbo.[DMS_GlobalSearch]";
    public const string DMS_GetAssignedDocumentsByUserId = "dbo.[DMS_GetAssignedDocumentsByUserId]";
    public const string DMS_GetRemarksByDocumentId = "dbo.[DMS_GetRemarksByDocumentId]";
    public const string DMS_InsertUpdateDocumentRemark = "dbo.[DMS_InsertUpdateDocumentRemark]";
    public const string DMS_InsertUpdateGeneratedLink = "dbo.[DMS_InsertUpdateGeneratedLink]";
    public const string DMS_GetUserDetailsForLink = "dbo.[DMS_GetUserDetailsForLink]";
    public const string DMS_GetDocumentsByInput = "dbo.[DMS_GetDocumentsByInput]";
    public const string DMS_GetProjectData = "dbo.[DMS_GetProjectData]";
    public const string DMS_GetDashboardCount = "dbo.[DMS_GetDashbaordCount]";
    public const string DMS_DocumentSaveUnSave = "dbo.[DMS_DocumentSaveUnSave]";
    public const string DMS_GetAllDMSProjects = "dbo.[DMS_GetAllDMSProjects]";
    public const string DMS_InsertUpdateDMSProject = "dbo.[DMS_InsertUpdateDMSProject]";

    #endregion

    #region FAQ
    public const string Select_FAQ = "[dbo].[Employee_FAQ_Search_And_Select]";
    public const string InsertUpdateDelete_FAQ = "[dbo].[Employee_FAQ_Insert_Update_Delete]";
    public const string Insert_FAQ_Transaction = "[dbo].[Employee_FAQ_Transaction_Insert]";
    public const string Select_FAQ_Transaction = "[dbo].[Employee_FAQ_Transaction_Search&Select]";

    #endregion
    #region ITPanel
    public const string marketing_Header_Footer_InsertUpdate = "[dbo].[Marketing_Header_Footer_InsertUpdate]";
    public const string Marketing_Select_HeaderFooter = "[dbo].[Marketing_Select_HeaderFooter]";
    public const string Employee_InsertUpdateDelete_ExotelLandlineNumbers = "[dbo].[Employee_InsertUpdateDelete_ExotelLandlineNumbers]";
    public const string Employee_GetExotelLandlineNumbers = "[dbo].[Employee_GetExotelLandlineNumbers]";
    public const string Notification_Insert_Update = "[dbo].[Notifications_Insertion_ITSupport]";
    public const string Employee_Select_EmployeeRole = "[dbo].[Employee_Select_EmployeeRole]";
    public const string Employee_Role_InsertUpdate = "[dbo].[Employee_Role_InsertUpdate]";
    public const string GetItPanelDropdownDetails = "[dbo].[GetItPanelDropdownDetails]";
    public const string HRNotification_Insert_Update = "[dbo].[Notifications_Insertion_ITSupport]";
    public const string GetTriggerTemplateData = "[dbo].[Marketing_TriggerTemplate_SearchAndSelect]";
    public const string TriggerTemplateTokenUpdate = "[dbo].[Marketing_TriggerTemplate_InsertUpdate]";
    public const string Reset_EmployeeDevice_Details = "[dbo].[ITPanel_Reset_EmployeeDevice]";
    public const string ITPanel_Get_SchedulerData = "[dbo].[ITPanel_Get_SchedulerData]";
    #endregion
}
