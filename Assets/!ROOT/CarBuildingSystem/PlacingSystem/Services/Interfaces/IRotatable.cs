using System;
using UnityEngine;

namespace _ROOT.CarBuildingSystem.PlacingSystem.Services.Interfaces
{
    public interface IRotatable
    {
        event Action OnRotated;
        void Rotate(Transform target, bool isSnapRotation);
    }
}