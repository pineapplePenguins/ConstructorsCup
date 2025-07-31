using System;
using _ROOT.CarBuildingSystem.BuildModInventoryUI;
using _ROOT.CarBuildingSystem.BuildModInventoryUI.ItemPreview;
using _ROOT.CarBuildingSystem.BuildModInventoryUI.View;
using _ROOT.CarBuildingSystem.Data;
using _ROOT.CarBuildingSystem.PlacingSystem;
using UnityEngine;

namespace _ROOT.CarBuildingSystem
{
    public class InventoryManager : MonoBehaviour
    {
        public event Action<bool> OnDisplayInventory; 

        [SerializeField] private BuildModeInventoryView inventoryView;
        [SerializeField] private PreviewItemInventorySystem previewItemInventorySystem;
        [SerializeField] private CarPartSpawner carPartSpawner;

        private BuildModInventoryPresenter _inventoryPresenter;

        private void Awake()
        {
            InitializeInventory();
            _inventoryPresenter.OnPartSelected += OnPartSelected;
            _inventoryPresenter.OnPartApproved += OnPartApproved;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!inventoryView.gameObject.activeInHierarchy)
                    OpenInventory();
                else
                    CloseInventory();
            }
        }

        private void OpenInventory()
        {
            inventoryView.gameObject.SetActive(true);
            _inventoryPresenter.OnShow();
            OnDisplayInventory?.Invoke(true);
        }

        private void CloseInventory()
        {
            inventoryView.gameObject.SetActive(false);
            OnDisplayInventory?.Invoke(false);
        }

        private void OnPartSelected(PartData partData)
        {
            previewItemInventorySystem.Load(partData.Prefab.gameObject);
        }
        
        private void OnPartApproved(PartData partData)
        {
            carPartSpawner.CreatePartToHand(partData.Prefab);
            CloseInventory();
        }

        private void InitializeInventory()
        {
            var inventoryModel = new BuildModeInventoryModel(inventoryView);
            _inventoryPresenter = new BuildModInventoryPresenter(inventoryModel);
            inventoryView.Initialize(_inventoryPresenter);
        }
    }
}