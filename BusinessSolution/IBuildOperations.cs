using CommonSolution;
using System.Collections.Generic;

namespace BusinessSolution
{
    /// <summary>
    /// Build operations interface.
    /// </summary>
    public interface IBuildOperations
    {
        /// <summary>
        /// Get ordered builds.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        List<string> GetOrderedBuilds(RequestModel requestModel);
    }
}