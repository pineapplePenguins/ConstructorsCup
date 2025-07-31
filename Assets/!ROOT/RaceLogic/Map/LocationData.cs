using UnityEngine;

namespace _ROOT.RaceLogic.Map
{
    [CreateAssetMenu(fileName = "LocationData", menuName = "Map/LocationData", order = 1)]
    public class LocationData : ScriptableObject
    {
        [SerializeField] private Map locationPrefab;
    }
}