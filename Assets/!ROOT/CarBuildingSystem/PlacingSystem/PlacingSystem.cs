using _ROOT.Car;
using UnityEngine;

namespace _ROOT.CarBuildingSystem.PlacingSystem
{
    public class PlacingSystem : MonoBehaviour
    {
        private const int ELEMENTS_LIMIT = 64;
        
        [SerializeField] private CarPartSpawner carPartSpawner;

        private bool _canBuild;
        private IBuildModeInputSystem _buildModeInputSystem;
        private CarBodyConstruction _carBodyConstruction;

        public CarPart InHand
        {
            set => _buildModeInputSystem.InHandPart = value;
        }

        public void BuildAccess(bool isAllow)
        {
            _canBuild = !isAllow;
        }

        private void OnEnable()
        {
            _buildModeInputSystem ??= new KeyboardInputSystem(Camera.main, this);

            _buildModeInputSystem.OnPlace += Place;
            _buildModeInputSystem.OnKill += Kill;
            _buildModeInputSystem.RequireToRemoveItemFromHand += carPartSpawner.RemovePartFromHand;
        }

        private void OnDisable()
        {
            _buildModeInputSystem.OnPlace -= Place;
            _buildModeInputSystem.OnKill -= Kill;
            _buildModeInputSystem.RequireToRemoveItemFromHand -= carPartSpawner.RemovePartFromHand;
        }

        private void Update()
        {
            if (!_canBuild)
                return;
            
            _buildModeInputSystem.Update();
        }

        private void Place(CarPart partInHand)
        {
            _carBodyConstruction ??= new CarBodyConstruction();

            if (_carBodyConstruction.ElementsCount > ELEMENTS_LIMIT)
            {
                //TODO limit message
                return;
            }
            
            _carBodyConstruction.AddPart(carPartSpawner.GetOriginalPrefab(), partInHand);
            
            if(_buildModeInputSystem.IsRemovePartFromHandOnNext)
                carPartSpawner.RemovePartFromHand();
        }
        
        private void Kill(CarPart part)
        {
            part.Kill();
        }
    }
}