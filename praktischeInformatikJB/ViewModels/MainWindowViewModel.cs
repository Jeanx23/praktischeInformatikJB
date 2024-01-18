using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using sportapiwrapper.Enums;
using sportapiwrapper.InternalLogic;
using sportapiwrapper.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace praktischeInformatikJB.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject // stellt veränderung fest und übernimmt diese
    {
        [ObservableProperty]
        private List<MatchViewModel> _matches; 
        [ObservableProperty]
        private League _league;

        [ObservableProperty]
        private string _matchday;

        [ObservableProperty]
        private DateTime _selectedDay;

        [ObservableProperty]
        private string _selectedMatchDay;
        

        partial void OnSelectedDayChanged(DateTime newDay)
        {
            GetMatchesForBundesligaTodayCommand.Execute(0);
        }

        partial void OnLeagueChanged(League newLeague)
        {           
            GetMatchesForSelectedMatchDayCommand.Execute(0);
        }

        partial void OnSelectedMatchDayChanged(string newMatchday)
        {
            GetMatchesForSelectedMatchDayCommand.Execute(0);
        }

        public List<League> AllLeagues { get; set; }
        public List<int> Numbers { get; set; }
        public MainWindowViewModel()
        {
            List<League>? leagues = SportsApi.GetAvailableLeagues(out ReturnStatus status);

            if (leagues == null)
            {
                throw new Exception("Could not retrieve league informatation.");
            }

            AllLeagues = leagues;
            _matches = new();
            League? bl1 = leagues.FirstOrDefault(x => x.LeagueID == 4608);
       
            if (bl1 != null)
            {
                League = bl1;
            }

            SelectedDay = DateTime.Today;          
            SelectedMatchDay = "1";
            Numbers = Enumerable.Range(1, 34).ToList();
        }

        [RelayCommand]
        private void GetMatchesForBundesligaToday()
        {
            string year = "2023";          
            List<MatchData>? matches = SportsApi.GetAllAvailableMatchDayData(League.LeagueShortcut, year, out ReturnStatus status);          
           
            if (matches == null)
            {
                throw new Exception("Could not get match data");
            }

            List<MatchData> matchesToday = matches.Where(x => x.MatchDateTimeUTC.Value.Date == SelectedDay).ToList();
            List<MatchViewModel> matchViewModels = matchesToday.Select(x => new MatchViewModel(x, League.LeagueShortcut)).ToList();
            Matches = matchViewModels;
        }

        [RelayCommand]
        private void GetMatchesForSelectedMatchDay()
        {
            string year = "2023";        
            List<MatchData>? matchesOfOneMatchDay = SportsApi.GetAvailableMatchDayData(League.LeagueShortcut, year, SelectedMatchDay, out ReturnStatus status); // 3 muss durch Variable Ersetzt werden - gibt den Spieltag an          
            
            if (matchesOfOneMatchDay == null)
            {
                throw new Exception("Could not get match data");
            }

            List<MatchViewModel> matchViewModels = matchesOfOneMatchDay.Select(x => new MatchViewModel(x, League.LeagueShortcut)).ToList();
            Matches = matchViewModels;
        }        
    }
}