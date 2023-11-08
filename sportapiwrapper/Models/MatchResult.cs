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
        int? ResultID { get; }
        int? PointsTeam1 { get; }
        int? PointsTeam2 { get; }
        int? ResultOrderID { get; }
        int? ResultTypeID { get; }
        string? ResultName { get; }
        string? ResultDescription { get; }
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
