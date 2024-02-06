using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using praktischeInformatikJB.Interfaces;
using praktischeInformatikJB.ViewModels;
using sportapiwrapper.Enums;
using sportapiwrapper.InternalLogic;
using sportapiwrapper.models;

namespace praktischeInformatikJB.Model
{
    internal class MatchdayFilter : IFilter
    {
        public League SelectedLeague { get; }

        public string MatchDay { get; }

        public MatchdayFilter(League league, string matchDay)
        {
            SelectedLeague = league;
            MatchDay = matchDay;
        }

        public List<MatchViewModel> Filter()
        {
            if (SelectedLeague.LeagueShortcut == null)
            {
                throw new Exception("League needs a shotcut");
            }

            string year = "2023";
            string leagueShortcut = SelectedLeague.LeagueShortcut;

            List<MatchData>? matchesOfOneMatchDay = SportsApi.GetAvailableMatchDayData(leagueShortcut, year, MatchDay, out ReturnStatus status); 

            if (matchesOfOneMatchDay == null)
            {
                throw new Exception("Could not get match data");
            }

            List<MatchViewModel> matchViewModels = matchesOfOneMatchDay.Select(x => new MatchViewModel(x, leagueShortcut)).ToList();
            return matchViewModels;
        }
    }
}
