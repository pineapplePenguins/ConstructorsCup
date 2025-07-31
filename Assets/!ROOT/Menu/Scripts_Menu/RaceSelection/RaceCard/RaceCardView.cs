using System;
using _ROOT.RaceLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _ROOT.Menu.Scripts_Menu.RaceSelection.RaceCard
{
    [RequireComponent(typeof(Toggle))]
    public class RaceCardView : MonoBehaviour
    {
        public event Action<RaceCardView> OnSelected;
        
        [SerializeField] private TMP_Text cardName;
        
        private Toggle _toggle;
        
        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(HandleToggle);
        }

        private void OnDestroy() => 
            _toggle.onValueChanged.RemoveListener(HandleToggle);

        private void HandleToggle(bool value)
        {
            if(value)
                OnSelected?.Invoke(this);
        }

        public void LoadData(RaceData data)
        {
            cardName.text = data.RaceName;
        }
    }
}
