using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Models
{
    public class GlobalResultInfo
    {
        int? Id { get; }
        string? Name { get; }

        public GlobalResultInfo(JToken info)
        {
            Id = info["id"]?.ToObject<int>();
            Name = info["name"]?.ToObject<string>();
        }
    }
}
