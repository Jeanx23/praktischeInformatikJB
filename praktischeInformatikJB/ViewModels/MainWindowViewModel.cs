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
using praktischeInformatikJB.Interfaces;
using praktischeInformatikJB.Model;
using praktischeInformatikJB.Enums;

namespace praktischeInformatikJB.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<MatchViewModel> _matches;

        [ObservableProperty] 
        private SelectionState _selectionState;

        [ObservableProperty]
        private DateTime _selectedDay = DateTime.Now;

        [ObservableProperty]
        private string _selectedMatchDay;

        public League League { get; }

        private IFilter _currentFilter;
        private IFilter CurrentFilter
        {
            get => _currentFilter;
            set
            {
                _currentFilter = value;
                Matches = _currentFilter.Filter();
            } 
        }

        partial void OnSelectedDayChanged(DateTime newDay)
        {
            DateFilter newFilter = new DateFilter(League, newDay);
            SelectionState = SelectionState.Calender;
            CurrentFilter = newFilter;
        }

        partial void OnSelectedMatchDayChanged(string newMatchday)
        {
            MatchdayFilter newFilter = new MatchdayFilter(League, newMatchday);
            SelectionState = SelectionState.MatchDay;
            CurrentFilter = newFilter;
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

            League? bl1 = leagues.FirstOrDefault(x => x.LeagueID == Constants.LeagueIds.Bl1Id);

            if (bl1 == null)
            {
                throw new Exception("Could not retrieve Bl1.");
            }

            League = bl1;
            Numbers = Enumerable.Range(1, 34).ToList();
        }
    }
}