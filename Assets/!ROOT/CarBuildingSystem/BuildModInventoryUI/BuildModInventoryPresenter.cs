using System;
using _ROOT.CarBuildingSystem.Data;

namespace _ROOT.CarBuildingSystem.BuildModInventoryUI
{
    public class BuildModInventoryPresenter
    {
        public event Action<PartData> OnPartApproved;
        public event Action<PartData> OnPartSelected;
        
        private readonly BuildModeInventoryModel _model;

        public BuildModInventoryPresenter(BuildModeInventoryModel model)
        {
            _model = model;
        }

        public void OnShow()
        {
            OnGroupSelected(0);
            OnItemSelected(0);
        }
        
        public void OnGroupSelected(int index)
        {
            _model.DisplayGroup(index);
            OnItemSelected(0);
        }

        public void OnItemSelected(int index)
        {
            _model.OnSelectItem(index);
            OnPartSelected?.Invoke(_model.SelectedPart);
        }

        public void OnApply()
        {
            var selectedPart = _model.SelectedPart;
            OnPartApproved?.Invoke(selectedPart);
        }
    }
}