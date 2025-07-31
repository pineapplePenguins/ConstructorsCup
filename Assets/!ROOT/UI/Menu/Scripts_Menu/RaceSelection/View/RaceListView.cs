using System.Collections.Generic;
using _ROOT.Menu.Scripts_Menu.RaceSelection.RaceCard;
using _ROOT.RaceLogic.Race;
using _ROOT.UI.PatternBases.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace _ROOT.UI.Menu.Scripts_Menu.RaceSelection.View
{
    public class RaceListView : MonoBehaviour, IBaseView<RaceData[]>
    {
        [SerializeField] private RaceCardView raceCardPrefab;
        [SerializeField] private ToggleGroup cardRoot;

        private RaceSelectionPresenter _presenter;
        private List<RaceCardView> _instances;

        public void Initialize(RaceSelectionPresenter presenter) => 
            _presenter = presenter;

        private void OnDestroy() => 
            Clear();
        
        public void UpdateView(RaceData[] data)
        {
            Clear();
            _instances = new List<RaceCardView>(data.Length);
            
            foreach (var raceData in data)
            {
                var instance = Instantiate(raceCardPrefab, cardRoot.transform);
                instance.LoadData(raceData);
                instance.OnSelected += OnToggleSelected;
                
                _instances.Add(instance);
            }

            OnToggleSelected(_instances[0]);
        }

        private void OnToggleSelected(RaceCardView selectedCard)
        {
            var cardIndex = _instances.IndexOf(selectedCard);
            _presenter.OnUserSelectCard(cardIndex);
        }

        private void Clear()
        {
            if(_instances == null) return;
            
            foreach (var instance in _instances)
            {
                instance.OnSelected -= OnToggleSelected;
                Destroy(instance.gameObject);
            }
            
            _instances.Clear();
        }
    }
}
