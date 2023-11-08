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
        int? GoalGetterId { get; }       
        int? GoalCount { get; }
        string? GoalGetterName { get; }

        /*
        "goalGetterId": 0,
        "goalGetterName": "string",
        "goalCount": 0
        */

        public GoalGetter(JObject info)
        {
            GoalGetterId = info["goalGetterId"]?.ToObject<int>();
            GoalCount = info["goalCount"]?.ToObject<int>();
            GoalGetterName = info["goalGetterName"]?.ToObject<string>();
        }

    }
}
