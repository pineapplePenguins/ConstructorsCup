using System;
using UnityEngine;

namespace _ROOT.CarBuildingSystem.PlacingSystem.Services.Interfaces
{
    public interface IMoveable
    {
        event Action OnEndMove;
        void Move(Transform target, RaycastHit hit);
        void DropMove();
    }
}