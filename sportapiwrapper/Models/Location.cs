using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.Models
{
    internal class Location
    {
        int? LocationID { get; }
        string? LocationCity { get; }
        string? LocationStadium { get; }
        
        public Location(JToken info)
        {
            LocationID = info["locationID"]?.ToObject<int>();
            LocationCity = info["locationCity"]?.ToObject<string>();
            LocationStadium = info["locationStadium"]?.ToObject<string>();
        }
    }
}
