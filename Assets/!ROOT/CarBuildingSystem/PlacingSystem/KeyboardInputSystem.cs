using System;
using _ROOT.CarBuildingSystem.PlacingSystem.Services;
using _ROOT.CarBuildingSystem.PlacingSystem.Services.Interfaces;
using UnityEngine;

namespace _ROOT.CarBuildingSystem.PlacingSystem
{
    public class KeyboardInputSystem : IBuildModeInputSystem
    {
        public CarPart InHandPart { private get; set; }

        public bool IsRemovePartFromHandOnNext => !Input.GetKey(KeyCode.LeftControl);

        public event Action<CarPart> OnPlace;
        public event Action<CarPart> OnKill;
        public event Action RequireToRemoveItemFromHand;

        private readonly IMoveable _moveService;
        private readonly IRotatable _rotationService;
        private readonly Camera _camera;

        private bool _isPlacingBlocked;
        
        public KeyboardInputSystem(Camera camera, MonoBehaviour caller)
        {
            _camera = camera;
            
            _moveService = new MoverService(caller);
            _rotationService = new RotatorService();

            _moveService.OnEndMove += ()=> BlockPlacing(false);
            _rotationService.OnRotated += () => _mousePosition = Vector3.zero;
        }
        
        public void Update()
        {
            if (InHandPart == null)
            {
                
                return;
            }
            
            MouseCast();
            _rotationService.Rotate(InHandPart.transform, true);
            
            if(Input.GetKeyDown(KeyCode.Mouse0))
                Place();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _moveService.DropMove();
                RequireToRemoveItemFromHand?.Invoke();
            }
        }

        private Vector3 _mousePosition;
        
        private void MouseCast()
        {
            if (InHandPart == null)
                return;
            
            if (_mousePosition == Input.mousePosition)
                return;
            
            _mousePosition = Input.mousePosition;
            
            var ray = _camera.ScreenPointToRay(_mousePosition);
            var layerToIgnore = LayerMask.NameToLayer("Ignore Raycast");
            var layerMask = ~(1 << layerToIgnore);
            
            if (Physics.Raycast(ray, out var hit, 100, layerMask))
            {
                _moveService.Move(InHandPart.transform, hit);
                BlockPlacing(true);
            }
        }

        private void BlockPlacing(bool isBlock)
        {
            _isPlacingBlocked = isBlock;
        }
        
        private void Place()
        {
            if (_isPlacingBlocked)
                return;
            
            OnPlace?.Invoke(InHandPart);
        }

        private void Kill()
        {
            OnKill?.Invoke(InHandPart);
        }
    }
}