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
    public class DateFilter : IFilter
    {
        public League SelectedLeague { get; }

        public DateOnly FilterDate { get; }

        public DateFilter(League league, DateTime filterDate)
        {
            SelectedLeague = league;
            FilterDate = DateOnly.FromDateTime(filterDate);
        }

        public List<MatchViewModel> Filter()
        {
            if (SelectedLeague.LeagueShortcut == null)
            {
                throw new Exception("League needs a shotcut");
            }

            string year = "2023";
            string leagueShortcut = SelectedLeague.LeagueShortcut;

            List<MatchData>? matches = SportsApi.GetAllAvailableMatchDayData(leagueShortcut, year, out ReturnStatus status);

            if (matches == null)
            {
                throw new Exception("Could not get match data");
            }

            List<MatchData> matchesToday = matches.Where(x =>
            {
                if (x.MatchDateTimeUTC == null)
                {
                    return false;
                }

                DateTime matchDateTime = x.MatchDateTimeUTC.Value.Date;
                DateOnly matchDate = DateOnly.FromDateTime(matchDateTime);
                return matchDate == FilterDate;
            }).ToList();

            List<MatchViewModel> matchViewModels = matchesToday.Select(x => new MatchViewModel(x, leagueShortcut)).ToList();
            return matchViewModels;
        }
    }
}
