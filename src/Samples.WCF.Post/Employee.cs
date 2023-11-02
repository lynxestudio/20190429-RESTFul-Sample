﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samples.WCF.Post
{
    public class Employee
    {
        public int? EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HireDate { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Commission { get; set; }
        public string JobId { get; set; }

    }
}