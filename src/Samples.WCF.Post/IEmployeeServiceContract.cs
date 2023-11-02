using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ComponentModel;

namespace Samples.WCF.Post
{

    [ServiceContract]
    public interface IEmployeeServiceContract
    {
    	[OperationContract]
        [WebInvoke(UriTemplate ="/employees/",
            Method ="POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json)]
        [Description("Creates a new employee.")]
        BaseRs CreateEmployee(Employee e);

        [OperationContract]
        [WebInvoke(UriTemplate = "/employees/", 
            Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Wrapped, 
            RequestFormat =WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json)]
        [Description("Updates an existing employee.")]
        BaseRs UpdateEmployee(Employee e);

        [OperationContract]
        [WebInvoke(UriTemplate = "/employees/{id}", 
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json)]
        [Description("Deletes an existing employee.")]
        BaseRs DeleteEmployee(string id);

    }
}