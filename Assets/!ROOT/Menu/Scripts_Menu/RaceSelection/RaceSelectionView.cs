using System;
using System.Collections.Generic;
using _ROOT.Menu.Scripts_Menu.RaceSelection.RaceCard;
using _ROOT.RaceLogic;
using UnityEngine;
using UnityEngine.UI;

namespace _ROOT.Menu.Scripts_Menu.RaceSelection
{
    public class RaceSelectionView : MonoBehaviour
    {
        [SerializeField] private RaceCardView raceCardPrefab;
        [SerializeField] private ToggleGroup cardRoot;
        [SerializeField] private Button startButton;

        private RaceSelectionPresenter _presenter;
        private List<RaceCardView> _instances;

        private void Awake() => 
            startButton.onClick.AddListener(OnCompleteSelection);

        public void Initialize(RaceSelectionPresenter presenter) => 
            _presenter = presenter;

        private void OnDestroy()
        {
            startButton.onClick.RemoveListener(OnCompleteSelection);
            Clear();
        }

        public void AssignCards(RaceData[] data)
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
        }

        private void OnToggleSelected(RaceCardView selectedCard)
        {
            var cardIndex = _instances.IndexOf(selectedCard);
            _presenter.OnUserSelectCard(cardIndex);
        }

        private void OnCompleteSelection() => 
            _presenter.OnCompleteSelection();

        private void Clear()
        {
            foreach (var instance in _instances)
            {
                instance.OnSelected -= OnToggleSelected;
                Destroy(instance.gameObject);
            }
            
            _instances.Clear();
        }
    }
}
