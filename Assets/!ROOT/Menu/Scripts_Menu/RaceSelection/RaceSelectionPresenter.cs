using VContainer;

namespace _ROOT.Menu.Scripts_Menu.RaceSelection
{
    public class RaceSelectionPresenter
    {
        // TODO [Inject] private readonly SceneManager
        private readonly RaceSelectionModel _model;

        public RaceSelectionPresenter(RaceSelectionModel model)
        {
            _model = model;
        }

        public void OnUserSelectCard(int cardIndex) => 
            _model.UpdateSelectedCard(cardIndex);

        public void OnCompleteSelection()
        {
            
        }
    }
}