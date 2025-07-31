using _ROOT.RaceLogic.Race;
using _ROOT.UI.PatternBases.MVP;

namespace _ROOT.UI.Menu.Scripts_Menu.RaceSelection.Interfaces
{
    public interface IRaceSelectionView : IBaseView<RaceData[]>
    {
        void UpdateRacesList(RaceData[] races);
        void ShowRaceDetails(RaceData detail);
    }
}