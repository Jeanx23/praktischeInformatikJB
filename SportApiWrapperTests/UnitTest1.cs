
using sportapiwrapper;
using sportapiwrapper.Enums;
using sportapiwrapper.InternalLogic;

namespace SportApiWrapperTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAvailableLeaguesTest()
        {
            ReturnStatus status;
            var leagues = SportsApi.GetAvailableLeagues(out status);
            Assert.Pass();
        }

        [Test]
        public void GetAvailableSportsTest()
        {
            ReturnStatus status;
            var sportTypes = SportsApi.GetAvailableSports(out status);
            Assert.Pass();
        }

        [Test]
        public void GetAvailableMatchDayDataTest()
        {
            string league = "bl1";
            string year = "2023";
            string matchday = "1";
            ReturnStatus status;
            var matchData = SportsApi.GetAvailableMatchDayData(league, year, matchday, out status);
            Assert.Pass();
        }

        [Test]
        public void GetLeagueTableTest()
        {
            string league = "bl1";
            string year = "2022";
            ReturnStatus status;
            var leagueTable = SportsApi.GetLeagueTable(league, year, out status);
            Assert.Pass();
        }

        [Test]
        public void GetAvailableTeamsTest()
        {
            string league = "bl1";
            string year = "2022";
            ReturnStatus status;
            var leagueTable = SportsApi.GetAvailableTeams(league, year, out status);
            Assert.Pass();
        }

        [Test]
        public void GetGoalGettersTest()
        {
            string league = "bl1";
            string year = "2022";
            ReturnStatus status;
            var goalGetters = SportsApi.GetGoalGetters(league, year, out status);
            Assert.Pass();
        }

        [Test]
        public void GetTwoClubsAllMatchesTest()
        {
            string team1 = "6";
            string team2 = "40";
            ReturnStatus status;
            var twoclubsMatches = SportsApi.GetTwoClubsAllMatches(team1, team2, out status);
            Assert.Pass();
        }

        [Test]
        public void GetAllAvailableMatchDataTest()
        {
            string league = "bl1";
            string year = "2023";
            ReturnStatus status;
            var matchdayData = SportsApi.GetAllAvailableMatchDayData(league, year, out status);
            Assert.Pass();
        }
    }
}