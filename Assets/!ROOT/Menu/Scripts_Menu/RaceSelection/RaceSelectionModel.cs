using _ROOT.RaceLogic;
using UnityEngine;

namespace _ROOT.Menu.Scripts_Menu.RaceSelection
{
    public class RaceSelectionModel
    {
        private readonly RaceSelectionView _view;
        private readonly RaceData[] _allRaces;
        
        private int _selectedRace;
        
        public RaceSelectionModel(RaceSelectionView view)
        {
            _view = view;
            _allRaces = Resources.LoadAll<RaceData>("ScriptableObjects/Races");
        }

        public void Load() => 
            _view.AssignCards(_allRaces);

        public void UpdateSelectedCard(int index)
        {
            _selectedRace = index;
            //TODO грузим данные для превью гонки во view
        }
    }
}