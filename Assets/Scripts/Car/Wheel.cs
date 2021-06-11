using UnityEngine;
using System;

namespace Car
{

    [Serializable]
    public struct Wheel
    {
        public GameObject _wheel;
        public WheelCollider _collider;
        public Place _place;
    }
    public enum Place
    {
        Rear,
        Front
    }
}