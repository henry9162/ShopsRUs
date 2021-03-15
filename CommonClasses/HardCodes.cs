using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.CommonClasses
{
    public class HardCodes
    {
        public class CustomerTypeCodes
        {
            public const string Employee = "Employee";
            public const string Affiliate = "Affiliate";
            public const string OldCustomer = "OldCustomer";
            public const string NewCustomer = "NewCustomer";
        }

        public class DiscountFrequency
        {
            public const int Value = 100;
        }

        public class SaveChangesCodes
        {
            public const int Add = 1;
            public const int Update = 2;
            public const int Delete = 3;
        }

        public class RequestResult
        {
            public int StatusCode { get; set; }
            public RequestState State { get; set; }
            public String Message { get; set; }
            public Object Data { get; set; }
        }

        public enum RequestState
        {
            Failed = -1,
            Success = 1,
            Error = -3
        }
    }

   
}
