using System;
using _ROOT.RaceLogic.Race;
using _ROOT.UI.Menu.Scripts_Menu.RaceSelection.View;
using _ROOT.UI.PatternBases.MVP;
using UnityEngine;

namespace _ROOT.UI.Menu.Scripts_Menu.RaceSelection
{
    public class RaceSelectionPresenter : BasePresenter<RaceSelectionModel, RaceSelectionViewComposite, RaceData[]>, IDisposable
    {
        // TODO [Inject] private readonly SceneManager

        public RaceSelectionPresenter(RaceSelectionModel model, RaceSelectionViewComposite view) : base(model, view)
        {
            _model.OnSelectedRaceUpdate += _view.ShowRaceDetails;
        }

        protected override void OnDataLoaded(RaceData[] data) => 
            _view.UpdateView(data);

        public void OnUserSelectCard(int cardIndex) => 
            _model.UpdateSelectedCard(cardIndex);

        public void OnCompleteSelection()
        {
            Debug.LogError($"Load race {_model.SelectedRace}");
            //TODO model.SelectedRace get this and load to SceneManager
        }

        public void Dispose()
        {
            _model.OnSelectedRaceUpdate -= _view.ShowRaceDetails;
        }
    }
}