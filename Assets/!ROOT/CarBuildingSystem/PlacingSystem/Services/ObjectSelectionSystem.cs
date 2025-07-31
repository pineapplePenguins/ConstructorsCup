using System;
using UnityEngine;

namespace _ROOT.CarBuildingSystem.PlacingSystem.Services
{
    public class ObjectSelectionSystem
    {
        private readonly Camera _camera;
        
        public event Action<GameObject> OnSelectGO;

        public ObjectSelectionSystem(Camera camera)
        {
            _camera = camera;
        }

        public void TrySelect(Vector3 mousePosition)
        {
            
        }

        private void Cast(Vector3 mousePosition)
        {
            var ray = _camera.ScreenPointToRay(mousePosition);
            var layerToIgnore = LayerMask.NameToLayer("Ignore Raycast");
            var layerMask = ~(1 << layerToIgnore);
            
            if (Physics.Raycast(ray, out var hit, 100, layerMask))
            {

            }
        }
    }
}