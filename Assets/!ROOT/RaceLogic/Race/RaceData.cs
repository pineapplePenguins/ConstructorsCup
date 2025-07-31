using _ROOT.RaceLogic.Enums;
using _ROOT.RaceLogic.Map;
using UnityEngine;

namespace _ROOT.RaceLogic
{
    [CreateAssetMenu(fileName = "RaceData", menuName = "Race/RaceData", order = 1)]
    public class RaceData : ScriptableObject
    {
        [SerializeField] private string raceName;
        [SerializeField] private RaceType _raceType;
        [SerializeField] private LocationData _locationData;

        public string RaceName => raceName;
    }
}