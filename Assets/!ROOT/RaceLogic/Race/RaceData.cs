using _ROOT.RaceLogic.Enums;
using _ROOT.RaceLogic.Map;
using UnityEngine;

namespace _ROOT.RaceLogic.Race
{
    [CreateAssetMenu(fileName = "RaceData", menuName = "Race/RaceData", order = 1)]
    public class RaceData : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private Sprite sprite;
        [SerializeField] private RaceType raceType;
        [SerializeField] private LocationData locationData;

        public string Title => title;
        public Sprite Sprite => sprite;
    }
}