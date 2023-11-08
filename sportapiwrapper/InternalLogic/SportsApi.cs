using sportapiwrapper.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using sportapiwrapper.Enums;
using sportapiwrapper.Models;

namespace sportapiwrapper.InternalLogic

{
    public class SportsApi
    {
        public static List<League>? GetAvailableLeagues(out ReturnStatus statusCode)
        {
            HttpResponseMessage response = ApiRequest.RequestAvailableLeagues();
            statusCode = (ReturnStatus)response.StatusCode;

            if (response.StatusCode != HttpStatusCode.OK) { return null; }

            Stream receiveStream = response.Content.ReadAsStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string responseString = readStream.ReadToEnd();
           
            JArray jsonArray = JArray.Parse(responseString);

            List<League>? leagues = null;

            try
            {
                leagues = SportsApiHelper.ParseLeagues(jsonArray);
            }
            catch
            {
                statusCode = ReturnStatus.ParseError;
            }

            return leagues;
        }
        public static List<Sport>? GetAvailableSports(out ReturnStatus statusCode)
        {
            HttpResponseMessage response = ApiRequest.RequestAvailableSports();
            statusCode = (ReturnStatus)response.StatusCode;

            if(response.StatusCode != HttpStatusCode.OK) { return null; }

            Stream receiveStream = response.Content.ReadAsStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string responseString = readStream.ReadToEnd();

            JArray jsonArray = JArray.Parse(responseString);

            List<Sport>? sportTypes = null;

            try
            {
                sportTypes = SportsApiHelper.ParseSports(jsonArray);
            }
            catch
            {
                statusCode = ReturnStatus.ParseError;
            }

            return sportTypes;
        }
        public static List<MatchData>? GetAvailableMatchDayData(out ReturnStatus statusCode)
        {
            HttpResponseMessage response = ApiRequest.RequestMatchDayData();
            statusCode = (ReturnStatus)response.StatusCode;

            if (response.StatusCode != HttpStatusCode.OK) { return null; }

            Stream receiveStream = response.Content.ReadAsStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string responseString = readStream.ReadToEnd();

            JArray jsonArray = JArray.Parse(responseString);

            List<MatchData>? matchDayData = null;

            try
            {
                matchDayData = SportsApiHelper.ParseMatchDayData(jsonArray);
            }
            catch
            {
                statusCode = ReturnStatus.ParseError;
            }

            return matchDayData;
        }
        public static List<MatchData>? GetTwoClubsMatchHistory(out ReturnStatus statusCode)
        {
            HttpResponseMessage response = ApiRequest.RequestTwoClubsMatchHistory();
            statusCode = (ReturnStatus)response.StatusCode;

            if (response.StatusCode != HttpStatusCode.OK) { return null; }

            Stream receiveStream = response.Content.ReadAsStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string responseString = readStream.ReadToEnd();

            JArray jsonArray = JArray.Parse(responseString);

            List<MatchData>? matchHistory = null;

            try
            {
                matchHistory = SportsApiHelper.ParseMatchHistory(jsonArray);
            }
            catch
            {
                statusCode = ReturnStatus.ParseError;
            }

            return matchHistory;
        }
        public static List<Table>? GetLeagueTable(string league, string year,out ReturnStatus statusCode)
        {
            HttpResponseMessage response = ApiRequest.RequestTable(league, year);
            statusCode = (ReturnStatus)response.StatusCode;

            if (response.StatusCode != HttpStatusCode.OK) { return null; }

            Stream receiveStream = response.Content.ReadAsStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string responseString = readStream.ReadToEnd();

            JArray jsonArray = JArray.Parse(responseString);

            List<Table>? leagues = null;

            try
            {
                leagues = SportsApiHelper.ParseTable(jsonArray);
            }
            catch
            {
                statusCode = ReturnStatus.ParseError;
            }

            return leagues;
        }
        public static List<Team>? GetAvailableTeams(string league, string year, out ReturnStatus statusCode)
        {
            HttpResponseMessage response = ApiRequest.RequestTable(league, year);
            statusCode = (ReturnStatus)response.StatusCode;

            if (response.StatusCode != HttpStatusCode.OK) { return null; }

            Stream receiveStream = response.Content.ReadAsStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string responseString = readStream.ReadToEnd();

            JArray jsonArray = JArray.Parse(responseString);

            List<Team>? teams = null;

            try
            {
                teams = SportsApiHelper.ParseTeam(jsonArray);
            }
            catch
            {
                statusCode = ReturnStatus.ParseError;
            }

            return teams;
        }
        public static List<GoalGetter>? GetGoalGetters(string league, string year, out ReturnStatus statusCode)
        {
            HttpResponseMessage response = ApiRequest.RequestGoalGetters(league, year);
            statusCode = (ReturnStatus)response.StatusCode;

            if (response.StatusCode != HttpStatusCode.OK) { return null; }

            Stream receiveStream = response.Content.ReadAsStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string responseString = readStream.ReadToEnd();

            JArray jsonArray = JArray.Parse(responseString);

            List<GoalGetter>? goalGetters = null;

            try
            {
                goalGetters = SportsApiHelper.ParseGoalGetters(jsonArray);
            }
            catch
            {
                statusCode = ReturnStatus.ParseError;
            }

            return goalGetters;
        }
    }
}
