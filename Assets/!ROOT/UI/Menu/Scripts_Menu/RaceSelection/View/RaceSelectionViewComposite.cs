using _ROOT.RaceLogic.Race;
using _ROOT.UI.Menu.Scripts_Menu.RaceSelection.Interfaces;
using _ROOT.UI.PatternBases.MVP;

namespace _ROOT.UI.Menu.Scripts_Menu.RaceSelection.View
{
    public class RaceSelectionViewComposite : IRaceSelectionView
    {
        private readonly IBaseView<RaceData[]> _raceSelectionView;
        private readonly IBaseView<RaceData> _raceDataDisplay;

        public RaceSelectionViewComposite(IBaseView<RaceData[]> raceSelectionView, IBaseView<RaceData> raceDataDisplay)
        {
            _raceSelectionView = raceSelectionView;
            _raceDataDisplay = raceDataDisplay;
        }

        public void UpdateView(RaceData[] data) => 
            _raceSelectionView.UpdateView(data);

        public void UpdateRacesList(RaceData[] races) => 
            UpdateView(races);

        public void ShowRaceDetails(RaceData detail) => 
            _raceDataDisplay.UpdateView(detail);
    }
}