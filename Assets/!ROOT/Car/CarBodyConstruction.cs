using System.Collections.Generic;
using _ROOT.CarBuildingSystem;
using UnityEngine;

namespace _ROOT.Car
{
    public class CarBodyConstruction
    {
        private readonly List<CarPart> _carElements = new();

        public int ElementsCount => _carElements?.Count ?? 0;

        public void AddPart(CarPart part, CarPart previewPart)
        {
            var duplicate = Object.Instantiate(part);
            
            duplicate.transform.position = previewPart.transform.position;
            duplicate.transform.eulerAngles = previewPart.transform.eulerAngles;
            duplicate.transform.localScale = previewPart.transform.localScale;
            
            _carElements.Add(duplicate);
            duplicate.OnKill += OnRemovePart;
        }

        private void OnRemovePart(CarPart part)
        {
            _carElements.Remove(part);
        }
    }
}