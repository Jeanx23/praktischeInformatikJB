using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sportapiwrapper.Enums;
using sportapiwrapper.InternalLogic;
using sportapiwrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sportapiwrapper.models
{
    public class MatchData
    {
        int? MatchID { get; }
        int? LeagueID { get; }
        int? LeagueSeason { get; }
        int? NumberOfViewers { get; }
        string? MatchDateTime { get; }
        string? TimeZoneID { get; }
        string? LeagueShortcut { get; }
        string? MatchDateTimeUTC { get; }
        string? LastUpdateDateTime { get; }
        string? LeagueName { get; }
        bool? MatchIsFinished { get; }
        IGroup? Group { get; }
        Team? Team1 { get; }
        Team? Team2 { get; }
        List<MatchResult>? MatchResults { get; }
        List<Goal>? Goals { get; }
        
        
       
        public MatchData(JObject info)
        {
            MatchID = info["matchID"]?.ToObject<int>();
            LeagueID = info["leagueId"]?.ToObject<int>();
            LeagueSeason = info["leagueSeason"]?.ToObject<int>();
            if (NumberOfViewers.HasValue) { NumberOfViewers = info["numberOfViewers"]?.ToObject<int>(); }
            MatchDateTime = info["matchDateTime"]?.ToObject<string>();
            TimeZoneID = info["timeZoneID"]?.ToObject<string>();
            LeagueName = info["leagueName"]?.ToObject<string>();
            LeagueShortcut = info["leagueShortcut"]?.ToObject<string>();
            MatchDateTimeUTC = info["matchDateTimeUTC"]?.ToObject<string>();
            LastUpdateDateTime = info["lastUpdateDateTime"]?.ToObject<string>();
            MatchIsFinished = info["matchIsFinished"]?.ToObject<bool>();           
            JToken groupInfo = info["group"]!;
            if (groupInfo.HasValues)
            {
                Group = new IGroup(groupInfo);
            }

            JToken team1Info = info["team1"]!;
            if (team1Info.HasValues)
            {
                Team1 = new Team(team1Info);
            }

            JToken team2Info = info["team2"]!;
            if (team2Info.HasValues)
            {
                Team2 = new Team(team2Info);
            }

            MatchResults = new List<MatchResult>();
            JToken matchResultInfo = info["matchResults"]!; 
            if (matchResultInfo.HasValues)
            {          
                foreach(JToken JToken in matchResultInfo)
                {
                    MatchResult matchResults = new MatchResult(JToken);
                    MatchResults.Add(matchResults);
                }
            }

            Goals = new List<Goal>();
            JToken goalInfo = info["goals"]!; 
            if (goalInfo.HasValues)
            {
                foreach (JToken JToken in goalInfo)
                {
                    Goal goals = new Goal(JToken);
                    Goals.Add(goals);
                }
            }

        }

    }
}
