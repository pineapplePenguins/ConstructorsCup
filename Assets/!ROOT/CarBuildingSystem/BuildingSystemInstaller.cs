using UnityEngine;

namespace _ROOT.CarBuildingSystem
{
    public class BuildingSystemInstaller : MonoBehaviour
    {
        [SerializeField] private PlacingSystem.PlacingSystem placingSystem;
        [SerializeField] private InventoryManager inventoryManager;

        private void OnEnable()
        {
            inventoryManager.OnDisplayInventory += placingSystem.BuildAccess;
        }

        private void OnDisable()
        {
            inventoryManager.OnDisplayInventory -= placingSystem.BuildAccess;
        }
    }
}