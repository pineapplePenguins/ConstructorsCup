using UnityEngine;

namespace _ROOT.CarBuildingSystem.Data
{
    [CreateAssetMenu(fileName = "PartData", menuName = "ScriptableObjects/PartData")]
    public class PartData : ScriptableObject
    {
        [SerializeField] private CarPart prefab;
        [SerializeField] private Sprite icon;
        [SerializeField] private EnumPartType partType;
        [SerializeField] private string itemName;
        //TODO description

        public CarPart Prefab => prefab;
        public Sprite Icon => icon;
        public EnumPartType PartType => partType;
        public string ItemName => itemName;
    }
}