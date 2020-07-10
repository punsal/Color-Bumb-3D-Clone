using TMPro;
using UI.Controller.Level_Information.Type;
using UnityEngine;

namespace UI.Controller.Level_Information
{
    public class LevelInformationController : MonoBehaviour
    {
        #pragma warning disable 649
        [SerializeField] private LevelInformationType informationType = LevelInformationType.Current;
        #pragma warning  restore 649
        
        private TextMeshProUGUI text;

        private void Awake()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            text.text = informationType == LevelInformationType.Current
                ? GameManager.GameData.currentLevel.ToString()
                : (GameManager.GameData.currentLevel + 1).ToString();
        }
    }
}
