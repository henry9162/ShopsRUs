using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ShopsRUs.CommonClasses.HardCodes;

namespace ShopsRUs.Services
{
    public abstract class BaseController : ControllerBase
    {
        protected Object BindOutput(int Statuscode, RequestState State, String Message, Object Data = null)
        {
            return new RequestResult()
            {
                StatusCode = Statuscode,
                State = State,
                Message = Message,
                Data = Data
            };
        }
    }
}
