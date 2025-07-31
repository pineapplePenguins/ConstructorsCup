using System.Linq;
using UnityEngine.UI;

namespace _ROOT.CarBuildingSystem.BuildModInventoryUI.View
{
    public partial class BuildModeInventoryView
    {
        public class GroupView
        {
            public Toggle GroupToggle { get; }
            private Toggle[] ItemsToggle { get; }

            public GroupView(Toggle groupToggle, Toggle[] itemsToggle)
            {
                GroupToggle = groupToggle;
                ItemsToggle = itemsToggle;
            }

            public void Display(bool isOn)
            {
                foreach (var toggle in ItemsToggle)
                    toggle.gameObject.SetActive(isOn);

                ItemsToggle.First().isOn = true;
            }
        }
    }
}