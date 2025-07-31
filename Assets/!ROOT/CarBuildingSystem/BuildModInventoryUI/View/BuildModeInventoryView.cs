using System.Collections.Generic;
using _ROOT.CarBuildingSystem.Data;
using _ROOT.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _ROOT.CarBuildingSystem.BuildModInventoryUI.View
{
    public partial class BuildModeInventoryView : MonoBehaviour
    {
        private BuildModInventoryPresenter _presenter;
        
        [Header("Categories")]
        [SerializeField] private RectTransform groupsRoot;
        [SerializeField] private BetterToggleGroup groupsToggleGroup;
        [SerializeField] private Toggle groupPrefab;
        [Header("Car parts")]
        [SerializeField] private RectTransform itemsRoot;
        [SerializeField] private BetterToggleGroup itemsToggleGroup;
        [SerializeField] private Toggle itemPrefab;
        [Header("___")]
        [SerializeField] private TMP_Text currentGroupText;
        [SerializeField] private TMP_Text selectedItemText;
        [SerializeField] private Button applyButton;

        private Dictionary<BuildModeInventoryModel.PartGroup, GroupView> _groupsView;
        
        public void Initialize(BuildModInventoryPresenter presenter)
        {
            _presenter = presenter;
        }

        public void AssignContent(List<BuildModeInventoryModel.PartGroup> partGroups)
        {
            _groupsView = new Dictionary<BuildModeInventoryModel.PartGroup, GroupView>(partGroups.Count);
            
            foreach (var group in partGroups)
            {
                var groupInstance = SpawnService.SpawnToggle(groupPrefab, groupsRoot, group.PartGroupData.Icon, groupsToggleGroup);
                
                var itemsList = new List<Toggle>(group.PartsData.Length);
                foreach (var partData in group.PartsData)
                {
                    var itemInstance = SpawnService.SpawnToggle(itemPrefab, itemsRoot, partData.Icon, itemsToggleGroup);
                    itemsList.Add(itemInstance);
                }

                var groupView = new GroupView(groupInstance, itemsList.ToArray());
                _groupsView.Add(group, groupView);
                groupView.Display(false);
            }
        }

        public void DisplayGroup(BuildModeInventoryModel.PartGroup partGroup, bool isDisplay)
        {
            var groupView = _groupsView[partGroup];
            groupView.Display(isDisplay);
            currentGroupText.text = partGroup.PartGroupData.GroupName;
        }

        public void SelectedItemLoad(PartData partData)
        {
            selectedItemText.text = partData.ItemName;
        }

        private void OnEnable()
        {
            groupsToggleGroup.OnChangeIndex += _presenter.OnGroupSelected;
            itemsToggleGroup.OnChangeIndex += _presenter.OnItemSelected;
            applyButton.onClick.AddListener(_presenter.OnApply);
        }

        private void OnDisable()
        {
            groupsToggleGroup.OnChangeIndex -= _presenter.OnGroupSelected;
            itemsToggleGroup.OnChangeIndex -= _presenter.OnItemSelected;
            applyButton.onClick.RemoveListener(_presenter.OnApply);
        }
    }
}