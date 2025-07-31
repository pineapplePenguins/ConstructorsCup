using System;
using _ROOT.CarBuildingSystem.PlacingSystem.Services.Interfaces;
using Code.Scripts.Utility;
using UnityEngine;

namespace _ROOT.CarBuildingSystem.PlacingSystem.Services
{
    public class MoverService : IMoveable
    {
        private const float SNAP_TIME = 0.1F;
        
        private readonly MonoBehaviour _caller;
        private Coroutine _moveCor;

        public event Action OnEndMove;
        
        public MoverService(MonoBehaviour caller)
        {
            _caller = caller;
        }

        public void Move(Transform target, RaycastHit hit)
        {
            var snapPosition = SnapPositionService.Snap(hit, target);
            var partPosition = target.position;
                
            if (_moveCor != null)
                _caller.StopCoroutine(_moveCor);
                
            _moveCor = _caller.StartCoroutine(CoroutineUtility.ExecuteOverTime(SNAP_TIME,
                f => target.position = Vector3.Lerp(partPosition, snapPosition, f), DropMove));
        }

        public void DropMove()
        {
            if(_moveCor != null)
                _caller.StopCoroutine(_moveCor);
            
            _moveCor = null;
            OnEndMove?.Invoke();
        }
    }
}