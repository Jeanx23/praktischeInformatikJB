using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Models
{
    public class Team
    {
        public int TeamId { get; }
        public string? TeamName { get; }
        public string? ShortName { get; }
        public string? TeamIconUrl { get; }
        public string? TeamGroupName { get; }        
        public Team(JToken info)
        {
            TeamId = info["teamId"].ToObject<int>();
            TeamName = info["teamName"]?.ToObject<string>();
            ShortName = info["shortName"]?.ToObject<string>();
            TeamIconUrl = info["teamIconUrl"]?.ToObject<string>();
            TeamGroupName = info["teamGroupName"]?.ToObject<string>();
        }
    }
}
