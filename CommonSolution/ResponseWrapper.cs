using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution
{
    public class ResponseWrapper : IResponseWrapper
    {
        public ResponseBase WrapResponse(dynamic response, List<Error> errors = null, string exceptionMessage = "")
        {
            ResponseBase responseBase = new ResponseBase
            {
                Response = response,
                Status = (errors == null) ? true : false,
                Error = errors,
                ErrorMessage = exceptionMessage
            };
            return responseBase;
        }
    }
}
