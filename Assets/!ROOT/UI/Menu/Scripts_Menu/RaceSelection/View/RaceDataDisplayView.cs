using _ROOT.RaceLogic.Race;
using _ROOT.UI.PatternBases.MVP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _ROOT.UI.Menu.Scripts_Menu.RaceSelection.View
{
    public class RaceDataDisplayView : MonoBehaviour, IBaseView<RaceData>
    {
        [SerializeField] private TMP_Text raceNameField;
        [SerializeField] private Image spriteRoot;
        [SerializeField] private Button startButton;

        private RaceSelectionPresenter _presenter;
        
        private void Awake() => 
            startButton.onClick.AddListener(OnCompleteSelection);
        
        private void OnDestroy() => 
            startButton.onClick.RemoveListener(OnCompleteSelection);

        public void Initialize(RaceSelectionPresenter presenter) => 
            _presenter = presenter;

        public void UpdateView(RaceData data)
        {
            raceNameField.text = data.Title;
            spriteRoot.sprite = data.Sprite;
        }

        private void OnCompleteSelection() => 
            _presenter.OnCompleteSelection();
    }
}