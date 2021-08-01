using System.Collections.Generic;

namespace CommonSolution
{
    public interface IResponseWrapper
    {
        ResponseBase WrapResponse(dynamic response, List<Error> errors = null, string exceptionMessage = "");
    }
}