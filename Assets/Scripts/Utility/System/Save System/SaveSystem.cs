using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Utility.System.Save_System
{
    public class SaveSystem : MonoBehaviour
    {
        #pragma warning disable 649
        
        [Header("Data List To Save")] 
        [SerializeField] private List<ScriptableObject> objectsToSave;

        #pragma warning restore 649
        
        private void OnEnable()
        {
            Load();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                Save();
            }
        }

        private void OnDisable()
        {
            Save();
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public void Load()
        {
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < objectsToSave.Count; i++)
            {
                if (!File.Exists($"{Application.persistentDataPath}/{objectsToSave[i].name}.pso")) continue;
                var binaryFormatter = new BinaryFormatter();
                var fileStream = File.Open(
                    $"{Application.persistentDataPath}/{objectsToSave[i].name}.pso",
                    FileMode.Open);
                JsonUtility.FromJsonOverwrite((string) binaryFormatter.Deserialize(fileStream), objectsToSave[i]);
                fileStream.Close();
            }
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public void Save()
        {
            Debug.Log(Application.persistentDataPath);
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < objectsToSave.Count; i++)
            {
                var binaryFormatter = new BinaryFormatter();
                var fileStream = File.Create($"{Application.persistentDataPath}/{objectsToSave[i].name}.pso");
                var json = JsonUtility.ToJson(objectsToSave[i]);
                binaryFormatter.Serialize(fileStream, json);
                fileStream.Close();
            }
        }
    }
}