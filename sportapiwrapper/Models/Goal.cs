using Newtonsoft.Json.Linq;
using sportapiwrapper.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Models
{
    internal class Goal
    {
        int? GoalID { get; }
        int? ScoreTeam1 { get; }
        int? ScoreTeam2 { get; }
        int? Matchminute { get; }
        int? GoalGetterID { get; }
        bool? IsPenalty { get; }
        bool? IsOwnGoal { get; }
        bool? IsOvertime { get; }
        string? Comment { get; }
        string? GoalGetterName { get; }

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
