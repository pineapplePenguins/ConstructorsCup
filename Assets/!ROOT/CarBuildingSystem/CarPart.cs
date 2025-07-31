using System;
using UnityEngine;

namespace _ROOT.CarBuildingSystem
{
    public class CarPart : MonoBehaviour
    {
        public event Action<CarPart> OnKill;

        public void Kill()
        {
            OnKill?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
