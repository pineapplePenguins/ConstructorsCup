using System;
using _ROOT.RaceLogic.Race;
using _ROOT.UI.Menu.Scripts_Menu.RaceSelection.View;
using _ROOT.UI.PatternBases.MVP;
using UnityEngine;

namespace _ROOT.UI.Menu.Scripts_Menu.RaceSelection
{
    public class RaceSelectionModel : BaseModel<RaceData[]>
    {
        public event Action<RaceData> OnSelectedRaceUpdate;
        public RaceData SelectedRace => _allRaces[_selectedRace];
        
        private readonly RaceListView _view;
        private RaceData[] _allRaces;
        private int _selectedRace;
        
        private int SelectedRaceIndex
        {
            set
            {
                _selectedRace = value;
                OnSelectedRaceUpdate?.Invoke(SelectedRace);
            }
        }
        
        protected override RaceData[] LoadDataInternal()
        {
            _allRaces = Resources.LoadAll<RaceData>("ScriptableObjects/Races");
            return _allRaces;
        }

        public void UpdateSelectedCard(int index) =>
            SelectedRaceIndex = index;
    }
}