using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;

namespace Samples.RestFul
{

    [ServiceContract]
    public interface IEmployeeServiceContract
    {
    	[OperationContract]
        [WebInvoke(UriTemplate ="/employees",
            Method ="POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json)]
        [Description("Creates a new employee.")]
        BaseRs CreateEmployee(Employee e);

        [OperationContract]
        [WebInvoke(UriTemplate = "/employees", 
            Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Wrapped, 
            RequestFormat =WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json)]
        [Description("Updates an existing employee.")]
        BaseRs UpdateEmployee(Employee e);

        [OperationContract]
        [WebInvoke(UriTemplate = "/employees/{id}", 
            Method = "DELETE",
            BodyStyle=WebMessageBodyStyle.Bare,
            ResponseFormat =WebMessageFormat.Json)]
        [Description("Deletes an existing employee.")]
        BaseRs DeleteEmployee(string id);

    }
}