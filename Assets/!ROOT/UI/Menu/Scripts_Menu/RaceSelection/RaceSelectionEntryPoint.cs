using System;
using _ROOT.UI.Menu.Scripts_Menu.RaceSelection.View;
using UnityEngine;

namespace _ROOT.UI.Menu.Scripts_Menu.RaceSelection
{
    public class RaceSelectionEntryPoint : MonoBehaviour
    {
        [SerializeField] private RaceListView raceCardView;
        [SerializeField] private RaceDataDisplayView raceDataDisplayView;

        private RaceSelectionModel _model;
        private RaceSelectionPresenter _presenter;
        private RaceSelectionViewComposite _viewComposite;
        
        private void Awake()
        {
            _model ??= new RaceSelectionModel();
            _viewComposite ??= new RaceSelectionViewComposite(raceCardView, raceDataDisplayView);
            _presenter ??= new RaceSelectionPresenter(_model, _viewComposite);
            
            raceCardView.Initialize(_presenter);
            raceDataDisplayView.Initialize(_presenter);
            
            _presenter.AssignData();
        }

        public void OnShow()
        {
            
        }

        public void OnHide()
        {
            
        }

        private void OnDestroy()
        {
            _presenter.Dispose();
        }
    }
}
