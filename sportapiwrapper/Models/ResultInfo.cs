using Newtonsoft.Json.Linq;
using sportapiwrapper.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Models
{
    internal class ResultInfo
    {
        int? Id { get; }
        int? OrderId { get; }
        string? Name { get; }
        string? Description { get; }
        GlobalResultInfo? GlobalResultInfo { get; }
        public ResultInfo(JObject info)
        {
            Id = info["id"]?.ToObject<int>();
            OrderId = info["orderId"]?.ToObject<int>();
            Name = info["name"]?.ToObject<string>();
            Description = info["description"]?.ToObject<string>();
            JToken globalResult = info["globalResultInfo"]!;
            if (globalResult.HasValues)
            {
                GlobalResultInfo = new GlobalResultInfo(globalResult);
            }
        }
    }
}
