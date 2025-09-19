using UnityEngine;

public class GameControllerScene2 : MonoBehaviour
{
    public Timer tiempoEscena;

    [Header("Jugador")]
    public GameObject playerPrefab;      // Prefab del jugador
    public Transform spawnPoint;         // Punto de aparición del jugador

    [Header("Items coleccionables")]
    public GameObject applePrefab;
    public GameObject bananaPrefab;
    public int maxApples = 5;
    public int maxBananas = 7;

    [Header("Zona de spawn")]
    public Transform leftLimit;
    public Transform rightLimit;
    public float yPosition = 0.5f; // Altura donde se colocarán los ítems

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

        // --- Generar coleccionables ---
        SpawnItems(applePrefab, maxApples);
        SpawnItems(bananaPrefab, maxBananas);
    }

    void SpawnItems(GameObject itemPrefab, int maxAmount)
    {
        for (int i = 0; i < maxAmount; i++)
        {
            float randomX = Random.Range(leftLimit.position.x, rightLimit.position.x);
            Vector2 spawnPos = new Vector2(randomX, yPosition);
            Instantiate(itemPrefab, spawnPos, Quaternion.identity);
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
