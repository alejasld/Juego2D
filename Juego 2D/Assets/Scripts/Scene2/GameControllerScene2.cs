using UnityEngine;

public class GameControllerScene2 : MonoBehaviour
{
    public Timer tiempoEscena;

    [Header("Jugador")]
    public Transform spawnPoint;

    void Start()
    {
        GameObject existingPlayer = GameObject.FindWithTag("Player");

        if (existingPlayer != null)
        {
            existingPlayer.transform.position = spawnPoint.position;
        }
    }

    public void AddTime()
    {
        tiempoEscena.TimerStop();
        float getTimeScene = tiempoEscena.StopTime;

        GameManager.Instance.TotalTime(getTimeScene);

        Debug.Log("Tiempo Escena 2: " + GameManager.Instance.GlobalTime);
    }
}
