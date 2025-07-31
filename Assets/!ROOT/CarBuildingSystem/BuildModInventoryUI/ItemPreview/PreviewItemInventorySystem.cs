using UnityEngine;

namespace _ROOT.CarBuildingSystem.BuildModInventoryUI.ItemPreview
{
    public class PreviewItemInventorySystem : MonoBehaviour
    {
        [SerializeField] private Transform root;
        [SerializeField] private float rotationSpeed = 10F;

        private GameObject _rotatedGOInstance;

        private void Update()
        {
            root.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        public void Load(GameObject prefab)
        {
            if (_rotatedGOInstance != null)
                Destroy(_rotatedGOInstance);
            
            _rotatedGOInstance = Instantiate(prefab, root);
            _rotatedGOInstance.transform.localPosition = Vector3.zero;
            _rotatedGOInstance.transform.localRotation = Quaternion.identity;
        }
    }
}