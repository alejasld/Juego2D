using UnityEngine;

public class GameControllerScene2 : MonoBehaviour
{
    public Timer tiempoEscena;

    [Header("Jugador")]
    public GameObject playerPrefab;
    public Transform spawnPoint;

    [Header("Spawner de ítems")]
    public ItemSpawner itemSpawner; // referencia al script spawner

    void Start()
    {
        // --- Instanciar o mover al jugador ---
        GameObject existingPlayer = GameObject.FindWithTag("Player");

        if (existingPlayer == null)
        {
            Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            existingPlayer.transform.position = spawnPoint.position;
        }

        // --- Generar frutas ---
        if (itemSpawner != null)
        {
            itemSpawner.SpawnFruits();
        }
        else
        {
            Debug.LogWarning("No se asignó el ItemSpawner en GameControllerScene2.");
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
