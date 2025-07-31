using System.Collections.Generic;
using System.Linq;
using _ROOT.CarBuildingSystem.BuildModInventoryUI.View;
using _ROOT.CarBuildingSystem.Data;
using UnityEngine;

namespace _ROOT.CarBuildingSystem.BuildModInventoryUI
{
    public partial class BuildModeInventoryModel
    {
        private readonly BuildModeInventoryView _view;
        private readonly List<PartGroup> _partGroups;
        
        private int _displayedGroupIndex;
        private int _selectedPartIndex;
        public PartData SelectedPart => _partGroups[_displayedGroupIndex].PartsData[_selectedPartIndex];

        public BuildModeInventoryModel( BuildModeInventoryView view)
        {
            var allGroupsData = Resources.LoadAll<PartGroupData>("ScriptableObjects/BuildMod/PartGroups");
            var allPartsData = Resources.LoadAll<PartData>("ScriptableObjects/BuildMod/Parts");
            
            _view = view;
            _partGroups = new List<PartGroup>(allGroupsData.Length);

            foreach (var partGroup in allGroupsData)
            {
                var partsToGroup = from p in allPartsData
                                                     where p.PartType == partGroup.PartGroup
                                                     select p;
                
                var newGroup = new PartGroup(partGroup, partsToGroup.ToArray());
                _partGroups.Add(newGroup);
            }
            
            _view.AssignContent(_partGroups);
        }

        public void DisplayGroup(int index)
        {
            _view.DisplayGroup(_partGroups[_displayedGroupIndex], false);
            _displayedGroupIndex = index;
            _view.DisplayGroup(_partGroups[_displayedGroupIndex], true);
        }

        public void OnSelectItem(int index)
        {
            _selectedPartIndex = index;
            _view.SelectedItemLoad(SelectedPart);
        }
    }
}