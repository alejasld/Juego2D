using UnityEngine;
using System.IO;

[System.Serializable]
public class ReportData
{
    public int apples;
    public int bananas;
    public int total;
    public float time;
}

public class Reporte : MonoBehaviour
{
    public void SaveReport()
    {
        ReportData data = new ReportData
        {
            apples = GameManager.Instance.ScoreApple,
            bananas = GameManager.Instance.ScoreBanana,
            total = GameManager.Instance.ScoreApple + GameManager.Instance.ScoreBanana,
            time = GameManager.Instance.GlobalTime
        };

        string json = JsonUtility.ToJson(data, true);

        // ✅ Usamos la ruta oficial de Unity para StreamingAssets
        string folderPath = Application.streamingAssetsPath;

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string filePath = Path.Combine(folderPath, "reporte.json");
        File.WriteAllText(filePath, json);

        Debug.Log($" Reporte guardado en: {filePath}");
    }
}
