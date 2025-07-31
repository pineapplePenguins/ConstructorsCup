using UnityEngine;

namespace _ROOT.CarBuildingSystem.Data
{
    [CreateAssetMenu(fileName = "PartGroupData", menuName = "ScriptableObjects/PartGroupData")]
    public class PartGroupData : ScriptableObject
    {
        [SerializeField] private EnumPartType partGroup;
        [SerializeField] private Sprite icon;
        [SerializeField] private string groupName;

        public Sprite Icon => icon;
        public EnumPartType PartGroup => partGroup;
        public string GroupName => groupName;
    }
}