using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samples.WCF.Post
{
    public sealed class BaseRs
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
    }
}