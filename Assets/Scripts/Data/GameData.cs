using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Game Data", menuName = "Data/Game Data", order = 0)]
    public class GameData : ScriptableObject
    {
        public int currentLevel = 1;
    }
}