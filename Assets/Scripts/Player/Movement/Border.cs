using System;

namespace Player.Movement
{
    [Serializable]
    public struct Border
    {
        public float positiveBorder;
        public float negativeBorder;

        public bool IsBetweenBorders(float value) => value >= negativeBorder && value <= positiveBorder;
    }
}