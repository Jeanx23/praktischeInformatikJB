using Newtonsoft.Json.Linq;
using sportapiwrapper.Exceptions;
using sportapiwrapper.models;
using sportapiwrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportapiwrapper.InternalLogic
{
    internal class SportsApiHelper
    {
        internal static List<League> ParseLeagues(JArray info)
        {
            List<League> leagues = new List<League>();
            
            if (info.Count == 0)
            {
                throw new CannotCreateModelException("Missing ´Data");
            }

            foreach (JObject jObject in info)
            {
                leagues.Add(new League(jObject));
            }

            return leagues;
        }        

        internal static List<Sport> ParseSports(JArray info)
        {
            List<Sport> sportTypes = new List<Sport>();

            if (info.Count == 0)
            {
                throw new CannotCreateModelException("Missing ´Data");
            }

            foreach (JObject jObject in info)
            {
                sportTypes.Add(new Sport(jObject));
            }

            return sportTypes;
        }

        internal static List<MatchData> ParseMatchDayData(JArray info)
        {
            List<MatchData> matchDayData = new List<MatchData>();

            if (info.Count == 0)
            {
                throw new CannotCreateModelException("Missing ´Data");
            }

            foreach (JObject jObject in info)
            {
                matchDayData.Add(new MatchData(jObject));
            }

            return matchDayData;
        }

        internal static List<MatchData>? ParseMatchHistory(JArray info)
        {
            List<MatchData> matchHistory = new List<MatchData>();

            if (info.Count == 0)
            {
                throw new CannotCreateModelException("Missing ´Data");
            }

            foreach (JObject jObject in info)
            {
                matchHistory.Add(new MatchData(jObject));
            }

            return matchHistory;
        }

        internal static List<Table>? ParseTable(JArray info)
        {
            List<Table> leagueTable = new List<Table>();

            if (info.Count == 0)
            {
                throw new CannotCreateModelException("Missing ´Data");
            }

            foreach (JObject jObject in info)
            {
                leagueTable.Add(new Table(jObject));
            }

            return leagueTable;
        }

        internal static List<Team>? ParseTeam(JArray info)
        {
            List<Team> teams = new List<Team>();

            if (info.Count == 0)
            {
                throw new CannotCreateModelException("Missing ´Data");
            }

            foreach (JObject jObject in info)
            {
                teams.Add(new Team(jObject));
            }

            return teams;
        }

        internal static List<GoalGetter>? ParseGoalGetters(JArray info)
        {
            List<GoalGetter> goalGetters = new List<GoalGetter>();

            if (info.Count == 0)
            {
                throw new CannotCreateModelException("Missing ´Data");
            }

            foreach (JObject jObject in info)
            {
                goalGetters.Add(new GoalGetter(jObject));
            }

            return goalGetters;
        }
    }
}
