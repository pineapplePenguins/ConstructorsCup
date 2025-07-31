using UnityEngine;
using UnityEngine.UI;

namespace _ROOT.CarBuildingSystem.BuildModInventoryUI.View
{
    public abstract class SpawnService
    {
        public static Toggle SpawnToggle(Toggle prefab, RectTransform root, Sprite icon, ToggleGroup toggleGroup)
        {
            var itemInstance = Object.Instantiate(prefab, root);
            itemInstance.image.sprite = icon;
            itemInstance.group = toggleGroup;
            return itemInstance;
        }
    }
}