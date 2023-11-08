using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Enums
{
    public enum ReturnStatus
    {
        //HTTP STATUS
        OK = 200,
        Unauthorized = 401,
        NotFound = 404,

        //WRAPPER ERROR
        ParseError
    }
}
