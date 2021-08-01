using System;

namespace CommonSolution
{
    /// <summary>
    /// Cyclic exception.
    /// </summary>
    public class CyclicException: Exception
    {
        public CyclicException()
            : base("Cyclic dependency found.")
        {

        }
    }
}
