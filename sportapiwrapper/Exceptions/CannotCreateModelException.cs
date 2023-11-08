using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Exceptions
{
    internal class CannotCreateModelException: Exception
    {
        public CannotCreateModelException(string message) : base(message)
        {
        }

    }
}
