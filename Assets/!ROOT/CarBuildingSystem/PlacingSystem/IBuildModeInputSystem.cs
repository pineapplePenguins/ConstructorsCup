using System;

namespace _ROOT.CarBuildingSystem.PlacingSystem
{
    public interface IBuildModeInputSystem
    {
        CarPart InHandPart { set; }
        bool IsRemovePartFromHandOnNext { get;}

        event Action<CarPart> OnPlace;
        event Action<CarPart> OnKill;
        event Action RequireToRemoveItemFromHand; 
        
        void Update();
    }
}