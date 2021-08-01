using CommonSolution;
using System.Collections.Generic;
using System.Linq;

namespace BusinessSolution
{
    /// <summary>
    /// Build Operations.
    /// </summary>
    public class BuildOperations : IBuildOperations
    {
        /// <summary>
        /// Request object variable.
        /// </summary>
        private RequestModel requestObject { get; set; }

        /// <summary>
        /// Get ordered builds.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public List<string> GetOrderedBuilds(RequestModel requestModel)
        {
            Dictionary<ProjectDependecy, bool> visitedProject = new Dictionary<ProjectDependecy, bool>();
            var orderedBuilds = new List<string>();
            requestObject = requestModel;
            requestModel.ProjectDependecies.ForEach(item =>
            {
                OrderBuilds(item, orderedBuilds, visitedProject);
            });
            return orderedBuilds;
        }

        #region - Private Methods

        /// <summary>
        /// Order builds.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="orderedBuilds"></param>
        /// <param name="visitedProject"></param>
        private void OrderBuilds(ProjectDependecy item, List<string> orderedBuilds, Dictionary<ProjectDependecy, bool> visitedProject)
        {
            //Explaination - Graph data structure is used to cater this problem.
            //As per problem statement there should be no cycles in input to target successfull build. This is handled in program.
            //We can traverse this graph problem using DFS and mark node as visited once traversed.

            bool inProgress;
            var alreadyVisited = visitedProject.TryGetValue(item, out inProgress);

            if (alreadyVisited)
            {
                if (inProgress)
                {
                    throw new CyclicException();
                }
            }
            else
            {
                visitedProject[item] = true;
                var dependencies = GetDepenciesForItem(item);
                if (dependencies != null)
                {
                    foreach (var dependency in dependencies)
                    {
                        OrderBuilds(dependency, orderedBuilds, visitedProject);
                    }
                }

                visitedProject[item] = false;
                orderedBuilds.Add(item.Name);
            }
        }

        /// <summary>
        /// Get dependencies for item.
        /// </summary>
        /// <param name="dependecy"></param>
        /// <returns></returns>
        private List<ProjectDependecy> GetDepenciesForItem(ProjectDependecy dependecy)
        {
            return requestObject.ProjectDependecies.Where(x => dependecy.Dependencies.Contains(x.Name)).ToList();
        }
        #endregion
    }
}
