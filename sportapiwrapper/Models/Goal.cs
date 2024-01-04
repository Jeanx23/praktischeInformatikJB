using Newtonsoft.Json.Linq;
using sportapiwrapper.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Models
{
    public class Goal
    {
        public int? GoalID { get; }
        public int? ScoreTeam1 { get; }
        public int? ScoreTeam2 { get; }
        public int? Matchminute { get; }
        public int? GoalGetterID { get; }
        public bool? IsPenalty { get; }
        public bool? IsOwnGoal { get; }
        public bool? IsOvertime { get; }
        public string? Comment { get; }
        public string? GoalGetterName { get; }

        public Goal(JToken info) 
        {           
            GoalID = info["goalID"]?.ToObject<int>();
            ScoreTeam1 = info["scoreTeam1"]?.ToObject<int>();
            ScoreTeam2 = info["scoreTeam2"]?.ToObject<int>();
            Matchminute = info["matchminute"]?.ToObject<int>();
            GoalGetterID = info["goalGetterID"]?.ToObject<int>();
            IsPenalty = info["isPenalty"]?.ToObject<bool>();
            IsOwnGoal = info["isOwnGoal"]?.ToObject<bool>();
            IsOvertime = info["isOvertime"]?.ToObject<bool>();
            Comment = info["comment"]?.ToObject<string>();
            GoalGetterName = info["goalGetterName"]?.ToObject<string>();             
        }

    }
}
