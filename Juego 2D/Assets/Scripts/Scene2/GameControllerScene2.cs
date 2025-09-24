using UnityEngine;
using TMPro;

public class GameControllerScene2 : MonoBehaviour
{
    public Timer tiempoEscena;
    public TextMeshProUGUI textApple;
    public TextMeshProUGUI textBanana;

    void Update()
    {
        if (GameManager.Instance != null)
        {
            textApple.text = GameManager.Instance.ScoreApple.ToString();
            textBanana.text = GameManager.Instance.ScoreBanana.ToString();
        }
    }

    public void AddTime()
    {
        tiempoEscena.TimerStop();
        float getTimeScene = tiempoEscena.StopTime;

        GameManager.Instance.AddTime(getTimeScene);

        Debug.Log("Tiempo Escena 2 " + GameManager.Instance.GlobalTime);
    }


}
