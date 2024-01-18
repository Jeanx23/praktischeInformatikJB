using Newtonsoft.Json.Linq;
using sportapiwrapper.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Models
{
    public class IGroup
    {      
        public int? GroupOrderID { get; }
        public int? GroupID { get; }
        public string? GroupName { get; }

        public IGroup(JToken info)
        {
            GroupOrderID = info["groupOrderID"]?.ToObject<int>();
            GroupID = info["groupID"]?.ToObject<int>();
            GroupName = info["groupName"]?.ToObject<string>();
        }
    }
}
