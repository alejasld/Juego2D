using UnityEngine;
using System.IO;

public class Reporte : MonoBehaviour
{
    [System.Serializable]
    public class GameData
    {
        public float totalTime;
        public int totalApples;
        public int totalBananas;
    }

    // Este método lo asignas al botón en la escena final
    public void GuardarReporte()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("No existe GameManager en memoria.");
            return;
        }

        GameData data = new GameData
        {
            totalTime = GameManager.Instance.GlobalTime,
            totalApples = GameManager.Instance.ScoreApple,
            totalBananas = GameManager.Instance.ScoreBanana
        };

        string json = JsonUtility.ToJson(data, true);

        // Carpeta StreamingAssets
        string folderPath = Application.streamingAssetsPath;
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Ruta del archivo
        string filePath = Path.Combine(folderPath, "gameData.json");
        File.WriteAllText(filePath, json);

        Debug.Log(" Reporte guardado en: " + filePath);
    }
}
