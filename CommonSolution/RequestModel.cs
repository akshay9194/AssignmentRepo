using System.Collections.Generic;

namespace CommonSolution
{
    public class ProjectDependecy
    {
        public string Name { get; set; }
        public List<string> Dependencies { get; set; }
    }

    public class RequestModel
    {
        public List<string> Projects { get; set; }
        public List<ProjectDependecy> ProjectDependecies { get; set; }
    }
}
