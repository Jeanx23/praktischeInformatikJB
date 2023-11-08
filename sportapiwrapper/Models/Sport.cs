using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.models
{
    public class Sport
    {
        int? SportID { get; }
        string? SportName { get; }

        /*  
        "sportId": 0,
        "sportName": "string"
        */

        public Sport(JToken info)
        {
            SportID = info["sportId"]?.ToObject<int>();
            SportName = info["sportName"]?.ToObject<string>();
        }
    }
}
