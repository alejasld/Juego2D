using UnityEngine;

public class GameControllerScene2 : MonoBehaviour
{
    public Timer tiempoEscena;

    void Start()
    {
       
    }

    public void AddTime()
    {
        tiempoEscena.TimerStop();
        float getTimeScene = tiempoEscena.StopTime;

        GameManager.Instance.TotalTime(getTimeScene);

        Debug.Log("Tiempo Escena 2: " + GameManager.Instance.GlobalTime);
    }
}
