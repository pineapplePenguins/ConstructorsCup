using UnityEngine;

namespace _ROOT.Utilities
{
    public class LayersUtilities
    {
        public static void SetLayerRecursive(GameObject _go, int _layer)
        {
            _go.layer = _layer;
            foreach (Transform child in _go.transform)
            {
                child.gameObject.layer = _layer;

                var _HasChildren = child.GetComponentInChildren<Transform>();
                if (_HasChildren != null)
                    SetLayerRecursive(child.gameObject, _layer);
            }
        }
    }
}