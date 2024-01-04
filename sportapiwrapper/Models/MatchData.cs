using Newtonsoft.Json.Linq;
using System.Globalization;
using sportapiwrapper.Models;

namespace sportapiwrapper.models
{
    public class MatchData
    {
        public int? MatchID { get; }
        public int? LeagueID { get; }
        public int? LeagueSeason { get; }
        public int? NumberOfViewers { get; }
        public DateTime? MatchDateTime { get; }
        public string? TimeZoneID { get; }
        public string? LeagueShortcut { get; }
        public DateTime? MatchDateTimeUTC { get; }
        public DateTime? LastUpdateDateTime { get; }
        public string? LeagueName { get; }
        public bool? MatchIsFinished { get; }
        public IGroup? Group { get; }
        public Team? Team1 { get; }
        public Team? Team2 { get; }
        public List<MatchResult>? MatchResults { get; }
        public List<Goal>? Goals { get; }
        
        
       
        public MatchData(JObject info)
        {
            string format = "MM/dd/yyyy HH:mm:ss";
            CultureInfo provider = CultureInfo.InvariantCulture;

            MatchID = info["matchID"]?.ToObject<int>();
            LeagueID = info["leagueId"]?.ToObject<int>();
            LeagueSeason = info["leagueSeason"]?.ToObject<int>();
            if (NumberOfViewers.HasValue) { NumberOfViewers = info["numberOfViewers"]?.ToObject<int>(); }

            string? matchDateTimeString = info["matchDateTime"]?.ToObject<string>();
            if (matchDateTimeString != null)
            {
                MatchDateTime = DateTime.ParseExact(matchDateTimeString, format, provider);
            }

            TimeZoneID = info["timeZoneID"]?.ToObject<string>();
            LeagueName = info["leagueName"]?.ToObject<string>();
            LeagueShortcut = info["leagueShortcut"]?.ToObject<string>();

            string? matchDateTimeUTCString = info["matchDateTimeUTC"]?.ToObject<string>();
            if (matchDateTimeUTCString != null)
            {
                MatchDateTimeUTC = DateTime.ParseExact(matchDateTimeUTCString, format, provider);
            }

            string? lastUpdateDateTimeString = info["lastUpdateDateTime"]?.ToObject<string>();
            if (lastUpdateDateTimeString != null)
            {
                LastUpdateDateTime = DateTime.ParseExact(lastUpdateDateTimeString, format, provider);
            }

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
