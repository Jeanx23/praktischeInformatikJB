using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sportapiwrapper.models
{
    public class League
    {
        public int? LeagueID {  get; }
        public string? LeagueName { get; }
        public string? LeagueShortcut { get; }
        public string? LeagueSeason { get; }
        public Sport? Sport { get; }

        public League(JObject info)
        {
            LeagueID = info["leagueId"]?.ToObject<int>();
            LeagueName = info["leagueName"]?.ToObject<string>();
            LeagueShortcut = info["leagueShortcut"]?.ToObject<string>();
            LeagueSeason = info["leagueSeason"]?.ToObject<string>();
            JToken sportInfo = info["sport"]!;
            if (sportInfo.HasValues)
            {
                Sport = new Sport(sportInfo);
            }      
        }
    }
}
