using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Models
{
    public class MatchResult
    {
        public int? ResultID { get; }
        public int? PointsTeam1 { get; }
        public int? PointsTeam2 { get; }
        public int? ResultOrderID { get; }
        public int? ResultTypeID { get; }
        public string? ResultName { get; }
        public string? ResultDescription { get; }
        public MatchResult(JToken info)
        {
          
            ResultID = info["resultID"]?.ToObject<int>();
            PointsTeam1 = info["pointsTeam1"]?.ToObject<int>();
            PointsTeam2 = info["pointsTeam2"]?.ToObject<int>();
            ResultOrderID = info["resultOrderID"]?.ToObject<int>();
            ResultTypeID = info["resultTypeID"]?.ToObject<int>();
            ResultName = info["resultName"]?.ToObject<string>();
            ResultDescription = info["resultDescription"]?.ToObject<string>();
            
        }
    }
}
