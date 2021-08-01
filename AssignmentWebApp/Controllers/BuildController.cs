using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessSolution;
using CommonSolution;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebApp.Controllers
{
    /// <summary>
    /// Build controller.
    /// </summary>
    [Route("api/Build")]
    [ApiController]
    public class BuildController : ControllerBase
    {
        private readonly IBuildOperations buildOperations;
        private readonly IResponseWrapper responseWrapper;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="_buildOperations"></param>
        /// <param name="_responseWrapper"></param>
        public BuildController(IBuildOperations _buildOperations, IResponseWrapper _responseWrapper)
        {
            buildOperations = _buildOperations;
            responseWrapper = _responseWrapper;
        }

        /// <summary>
        /// Get build order of projects.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Order([FromBody] RequestModel request)
        {
            try
            {
                // Validate request.
                if(request != null && request.ProjectDependecies != null)
                {
                    var result = buildOperations.GetOrderedBuilds(request);
                    return Ok(responseWrapper.WrapResponse(result));
                }
                return BadRequest(responseWrapper.WrapResponse(null, new List<Error>
                {
                    new Error
                    {
                        ExceptionMessage = "Request object cannot be null."
                    }
                }, "Invalid Request."));
            }
            catch(CyclicException e)
            {
                return BadRequest(responseWrapper.WrapResponse(null, new List<Error>
                {
                    new Error
                    {
                        ExceptionMessage = e.StackTrace
                    }
                }, e.Message));
            }
            catch(Exception exception)
            {
                return BadRequest(responseWrapper.WrapResponse(null, new List<Error>
                {
                    new Error
                    {
                        ExceptionMessage = exception.StackTrace
                    }
                }, exception.Message));
            }
        }
    }
}