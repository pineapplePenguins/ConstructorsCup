using _ROOT.Utilities;
using UnityEngine;

namespace _ROOT.CarBuildingSystem.PlacingSystem
{
    public class CarPartSpawner : MonoBehaviour
    {
        [SerializeField] private PlacingSystem placingSystem;

        private CarPart _originalPrefab;
        private CarPart _partInHand;

        public void CreatePartToHand(CarPart prefab)
        {
            RemovePartFromHand();
            
            _originalPrefab = prefab;
            _partInHand = Instantiate(prefab);
            LayersUtilities.SetLayerRecursive(_partInHand.gameObject, LayerMask.NameToLayer("Ignore Raycast"));
            placingSystem.InHand = _partInHand;
        }

        public CarPart GetOriginalPrefab() => _originalPrefab;

        public void RemovePartFromHand()
        {
            if(_partInHand != null)
                Destroy(_partInHand.gameObject);

            _originalPrefab = null;
        }
    }
}