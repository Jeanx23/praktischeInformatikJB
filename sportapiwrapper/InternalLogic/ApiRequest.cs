using sportapiwrapper.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace sportapiwrapper.InternalLogic
{
    internal class ApiRequest
    {
        private static readonly HttpClient _webClient = new HttpClient();
        private const string ApiURL = "https://api.openligadb.de";
        internal static HttpResponseMessage RequestAvailableLeagues()                                               // gibt alle Ligen zurück, auch unterschiedliche Saisons
        {
            string request = ApiURL + "/getavailableleagues";
            return _webClient.GetAsync(request).Result;
        }
        internal static HttpResponseMessage RequestAvailableSports()                                                // gibt alle Sportarten zurück
        {
            string request = ApiURL + "/getavailablesports";
            return _webClient.GetAsync(request).Result;
        }
        // /getmatchdaydata/{leagueShortcut}/{leagueSeason}/{groupOrderId}
        internal static HttpResponseMessage RequestMatchDayData(string league, string year, string matchday)        // gibt alle Relevanten Daten eines Spieltags zurück
        {
            string request = ApiURL + "/getmatchdata/" + league + "/" + year + "/" + matchday;
            return _webClient.GetAsync(request).Result;
        }
        // /getmatchdata/{teamId1}/{teamId2}
        internal static HttpResponseMessage RequestTwoClubsMatchHistory(string team1, string team2)
        {
            string request = ApiURL + "/getmatchdata/" + team1 + "/" + team2;                                       // gibt die Ergebnisse vergangener Duelle zweier Teams zurück
            return _webClient.GetAsync(request).Result;
        }
        internal static HttpResponseMessage RequestTable(string league, string year)                                // eine Request die die Tabelle einer Saison zurück gibt
        {
            string request = ApiURL + "/getbltable/" + league + "/" + year; 
            return _webClient.GetAsync(request).Result;
        }
        internal static HttpResponseMessage RequestAvailableTeams(string league, string year)                       // eine Request die alle Teams einer Saison zurück gibt
        {
            string request = ApiURL + "/getavailableteams/" + league + "/" + year; 
            return _webClient.GetAsync(request).Result;
        }

        internal static HttpResponseMessage RequestGoalGetters(string league, string year)
        {
            string request = ApiURL + "/getgoalgetters/" + league + "/" + year;
            return _webClient.GetAsync(request).Result;
        }

    }
}
