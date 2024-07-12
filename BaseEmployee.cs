using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TRU.Employee.WebAPI.Helpers;
using TRU.Realty.BusinessCommon.Client;
using TRU.Realty.BusinessCommon.Helper;

namespace TRU.Employee.WebAPI.BAL;
public class BaseEmployee
{
    public const string SPKey = "SPKey";
    public APIResponse responseResult = null;
    public JObject requestModel = null;
    public UserParameter userParameter = new UserParameter();

    public IOptions<ConnectionStrings> connectionString;
    public Client clientResponse = null;
    public Client phase2Response = null;
    public Client clientHrResposne = null;
    public IConfiguration Configure;
    public List<string> listOfsavedImages = null;
    public List<string> listofDeletedimages = null;
    public SqlConnection connection = null;
    public Client EmployeeResposne = null;


    public BaseEmployee(IOptions<ConnectionStrings> _connectionString)
    {
        this.connectionString = _connectionString;
        connection = new SqlConnection(_connectionString.Value.SalesConnectionString);
        clientResponse = new Client(_connectionString.Value.SalesConnectionString);
        phase2Response = new Client(_connectionString.Value.ExecutionConnectionString);
        clientHrResposne =new Client(_connectionString.Value.HRConnectionString);
        EmployeeResposne = new Client(_connectionString.Value.LocalConnectionString);
    }
}

public class UserParameter
{
    public int? UserId { get; set; }
    public int? EntityId { get; set; }
    public string UserType { get; set; }
    public int? TenantId { get; set; }
    public string UserDetail { get; set; }
    public string DeviceDetails { get; set; }
}
