using System;
using _ROOT.CarBuildingSystem.PlacingSystem.Services.Interfaces;
using UnityEngine;

namespace _ROOT.CarBuildingSystem.PlacingSystem.Services
{
    public class RotatorService : IRotatable
    {
        private const float ROTATION_SPEED = 50F;
        private const float ROTATION_ANGLE = 90F;
        private const float ROTATION_COOLDOWN = 0.2F;
        
        private readonly (KeyCode key, Vector3 axis, float direction)[] _rotations = {
            (KeyCode.Q, Vector3.up, -1),    // Вращение по оси Y влево
            (KeyCode.E, Vector3.up, 1),     // Вращение по оси Y вправо
            (KeyCode.R, Vector3.forward, -1), // Вращение по оси Z влево
            (KeyCode.T, Vector3.forward, 1),  // Вращение по оси Z вправо
            (KeyCode.F, Vector3.right, -1),   // Вращение по оси X влево
            (KeyCode.G, Vector3.right, 1)     // Вращение по оси X вправо
        };
        
        private float _lastSnapTime;
        
        public event Action OnRotated;

        public void Rotate(Transform target, bool isSnapRotation)
        {
            foreach (var (key, axis, direction) in _rotations)
            {
                if (Input.GetKey(key))
                {
                    if (isSnapRotation)
                    {
                        var currentAngles = target.eulerAngles;
                        
                        if (axis == Vector3.up)
                            currentAngles.y = Mathf.Round(currentAngles.y / ROTATION_ANGLE) * ROTATION_ANGLE;
                        else if (axis == Vector3.forward)
                            currentAngles.z = Mathf.Round(currentAngles.z / ROTATION_ANGLE) * ROTATION_ANGLE;
                        else if (axis == Vector3.right)
                            currentAngles.x = Mathf.Round(currentAngles.x / ROTATION_ANGLE) * ROTATION_ANGLE;
                        
                        target.eulerAngles = currentAngles;
                    }
                    
                    target.Rotate(axis, GetRotationSpeed(isSnapRotation) * direction, Space.World);
                    OnRotated?.Invoke();
                }
            }
        }
        
        private float GetRotationSpeed(bool isSnapRotation)
        {
            if (isSnapRotation)
            {
                if (Time.time >= _lastSnapTime + ROTATION_COOLDOWN)
                {
                    _lastSnapTime = Time.time;
                    return ROTATION_ANGLE;
                }

                return 0;
            }

            return ROTATION_SPEED * Time.deltaTime;
        }
    }
}