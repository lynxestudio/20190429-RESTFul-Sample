using System;
using System.Collections.Generic;

namespace Samples.WCF.Post {
    public class EmployeeServiceImplementation : IEmployeeServiceContract {
        public BaseRs CreateEmployee(Employee e) {
            BaseRs resp = new BaseRs();
            try {
                int records = EmployeesDac.Create(e);
                if (records == 1) {
                    resp.Success = true;
                    resp.Message = "Employee added.";
                }
            }
            catch (Exception ex) {
                resp.ErrorMessage = ex.Message;
            }
            return resp;
        }
        public BaseRs DeleteEmployee(string id) {
            BaseRs resp = new BaseRs();
            try {
                int records = EmployeesDac.Delete(id);
                if(records == 1) {
                	resp.Success = true;
                	resp.Message = "Employee deleted.";
                }
                else 
                	resp.Message = "Nothing to delete.";
            }
            catch (Exception ex) {
                resp.ErrorMessage = ex.Message;
            }
            return resp;
        }
        public BaseRs UpdateEmployee(Employee e) {
            BaseRs resp = new BaseRs();
            try {
                int records = EmployeesDac.Update(e);
                if (records == 1) {
                    resp.Success = true;
                    resp.Message = "Employee updated.";
                }
            }
            catch (Exception ex) {
                resp.ErrorMessage = ex.Message;
            }
            return resp;
        }
    }
}