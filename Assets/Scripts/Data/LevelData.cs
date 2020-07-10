using System.Collections.Generic;
using System.Linq;
using Level;
using UnityEngine;
using Utility.Library;

namespace Data
{
    [CreateAssetMenu(fileName = "New Level Data", menuName = "Data/Level Data", order = 0)]
    public class LevelData : ScriptableObject
    {
        #pragma warning disable 649
        [Header("FinishLine")]
        [SerializeField] private GameObject finishLinePrefab;
        
        [Header("All Levels")]
        [SerializeField] private List<LevelManager> levels;
        
        [Header("Debug Selected Levels")]
        [SerializeField] private List<LevelManager> selectedLevels;

        [Header("Colors")] 
        [SerializeField] private List<Material> colors;
        [SerializeField] private Material playerColor;
        [SerializeField] private Material enemyColor;
        #pragma warning restore 649

        private GameObject currentLevel;

        public Material PlayerColor => playerColor;
        public Material EnemyColor => enemyColor;

        public void CreateLevel()
        {
            if (selectedLevels.Count == 0)
            {
                var randomLevelIndexes = Math.Combination(3, levels.Count);
                foreach (var randomLevelIndex in randomLevelIndexes)
                {
                    selectedLevels.Add(levels[randomLevelIndex]);
                }
            }
            
            currentLevel = new GameObject("Level");
            currentLevel.transform.position = Vector3.zero;
            var spawnPoint = Vector3.zero;
            foreach (var temp in selectedLevels
                .Select(selectedLevel => Instantiate(selectedLevel, currentLevel.transform, true))
            )
            {
                temp.transform.position = spawnPoint;

                spawnPoint = temp.EndPosition;
            }

            var finishLineTemp = Instantiate(finishLinePrefab, currentLevel.transform, true);
            finishLineTemp.transform.position = spawnPoint;
        }

        private void SelectColors()
        {
            do
            {
                playerColor = colors[Random.Range(0, colors.Count)];
                enemyColor = colors[Random.Range(0, colors.Count)];
            } while (playerColor == enemyColor);
        }

        public void LevelCompleted()
        {
            SelectColors();
            selectedLevels.Clear();
        }

        public void DestroyLevel()
        {
            Destroy(currentLevel);
        }
    }
}