using _ROOT.CarBuildingSystem.Data;

namespace _ROOT.CarBuildingSystem.BuildModInventoryUI
{
    public partial class BuildModeInventoryModel
    {
        public class PartGroup
        {
            public PartGroupData PartGroupData { get; }
            public PartData[] PartsData { get; }

            public PartGroup(PartGroupData partGroupData, PartData[] partsData)
            {
                PartGroupData = partGroupData;
                PartsData = partsData;
            }
        }
    }
}