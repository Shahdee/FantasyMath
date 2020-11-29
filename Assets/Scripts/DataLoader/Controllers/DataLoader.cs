using UnityEngine;
using System.IO;
using System.Collections;
using UnityEngine.Events;

namespace DataLoader
{
    public class DataLoader : IDataLoader
    {
        public void LoadGameData<T>(string fileName, UnityAction<T> onLoaded)
        {
            LoadJSON(fileName, (dataAsJson) =>
            {
                var data = JsonUtility.FromJson<T>(dataAsJson);
                
                onLoaded?.Invoke(data);
                
            });
        }

        private IEnumerator LoadJSON(string fileName, UnityAction<string> onDone)
        {
            string dataAsJson;
            
            var filePath = Path.Combine(Application.streamingAssetsPath, fileName);
            if (filePath.Contains ("://") || filePath.Contains (":///")) 
            {
                UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get (filePath);
                yield return www.SendWebRequest();
                dataAsJson = www.downloadHandler.text;
            } else 
            {
                dataAsJson = File.ReadAllText (filePath);
            }

            onDone?.Invoke(dataAsJson);
        }
    }
}