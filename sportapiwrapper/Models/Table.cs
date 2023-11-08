using Newtonsoft.Json.Linq;
using sportapiwrapper.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Models
{
    public class Table
    {
        int? TeamInfoId { get; }
        string? TeamName { get; }
        string? ShortName { get; }
        string? TeamIconUrl { get; }
        int? Points { get; }
        int? OpponentGoals { get; }
        int? Goals { get; }
        int? Matches { get; }
        int? Won { get; }
        int? Lost { get; }
        int? Draw { get; }
        int? GoalDiff { get; }

        /*
        "teamInfoId": 0,
        "teamName": "string",
        "shortName": "string",
        "teamIconUrl": "string",
        "points": 0,
        "opponentGoals": 0,
        "goals": 0,
        "matches": 0,
        "won": 0,
        "lost": 0,
        "draw": 0,
        "goalDiff": 0
        */

        public Table(JObject info)
        {
            TeamInfoId = info["teamInfoId"]?.ToObject<int>();
            TeamName = info["teamName"]?.ToObject<string>();
            ShortName = info["shortName"]?.ToObject<string>();
            TeamIconUrl = info["teamIconUrl"]?.ToObject<string>();
            Points = info["points"]?.ToObject<int>();
            OpponentGoals = info["opponentGoals"]?.ToObject<int>();
            Goals = info["goals"]?.ToObject<int>();
            Matches = info["matches"]?.ToObject<int>();
            Won = info["won"]?.ToObject<int>();
            Lost = info["lost"]?.ToObject<int>();
            Draw = info["draw"]?.ToObject<int>();
            GoalDiff = info["goalDiff"]?.ToObject<int>();
        }
    }
}
