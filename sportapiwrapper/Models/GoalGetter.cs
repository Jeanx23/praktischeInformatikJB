using Newtonsoft.Json.Linq;
using sportapiwrapper.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Models
{
    public class GoalGetter
    {
        public int? GoalGetterId { get; }       
        public int? GoalCount { get; }
        public string? GoalGetterName { get; }

        public GoalGetter(JObject info)
        {
            GoalGetterId = info["goalGetterId"]?.ToObject<int>();
            GoalCount = info["goalCount"]?.ToObject<int>();
            GoalGetterName = info["goalGetterName"]?.ToObject<string>();
        }

    }
}
