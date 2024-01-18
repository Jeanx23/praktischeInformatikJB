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
        public int? SportID { get; }
        public string? SportName { get; }
        public Sport(JToken info)
        {
            SportID = info["sportId"]?.ToObject<int>();
            SportName = info["sportName"]?.ToObject<string>();
        }
    }
}
