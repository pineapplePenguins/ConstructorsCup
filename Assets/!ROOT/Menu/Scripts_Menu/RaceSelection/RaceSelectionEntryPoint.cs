using UnityEngine;

namespace _ROOT.Menu.Scripts_Menu.RaceSelection
{
    public class RaceSelectionEntryPoint : MonoBehaviour
    {
        [SerializeField] private RaceSelectionView raceCardView;

        private RaceSelectionModel _model;
        private RaceSelectionPresenter _presenter;
        
        private void Awake()
        {
            _model ??= new RaceSelectionModel(raceCardView);
            _presenter ??= new RaceSelectionPresenter(_model);
            
            raceCardView.Initialize(_presenter);
        }

        public void OnShow()
        {
            
        }

        public void OnHide()
        {
            
        }
    }
}
