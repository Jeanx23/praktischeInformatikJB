using System.Collections.Generic;
using praktischeInformatikJB.ViewModels;
using sportapiwrapper.models;

namespace praktischeInformatikJB.Interfaces
{
    public interface IFilter
    {
        public League SelectedLeague { get; }

        public List<MatchViewModel> Filter();
    }
}
