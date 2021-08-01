using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution
{
    public class ResponseBase
    {
        public dynamic Response { get; set; }
        public List<Error> Error { get; set; }
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
