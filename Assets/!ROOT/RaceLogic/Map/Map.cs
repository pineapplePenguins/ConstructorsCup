using System.Linq;
using UnityEngine;

namespace _ROOT.RaceLogic.Map
{
    public class Map : MonoBehaviour
    {
        [Header("Треки на карте")]
        [SerializeField] private Track[] tracks;

        public Track[] Tracks => tracks.ToArray();
    }
}