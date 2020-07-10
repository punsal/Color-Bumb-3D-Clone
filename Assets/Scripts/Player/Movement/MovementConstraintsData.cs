using System;

namespace Player.Movement
{
    [Serializable]
    public struct MovementConstraintsData
    {
        public Border horizontalBorder;
        public Border verticalBorder;
    }
}