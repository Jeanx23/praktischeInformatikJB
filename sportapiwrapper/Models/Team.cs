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
        int? TeamId { get; }
        string? TeamName { get; }
        string? ShortName { get; }
        string? TeamIconUrl { get; }
        string? TeamGroupName { get; }

        public Team(JToken info)
        {
            TeamId = info["teamId"]?.ToObject<int>();
            TeamName = info["teamName"]?.ToObject<string>();
            ShortName = info["shortName"]?.ToObject<string>();
            TeamIconUrl = info["teamIconUrl"]?.ToObject<string>();
            TeamGroupName = info["teamGroupName"]?.ToObject<string>();
        }
    }
}
