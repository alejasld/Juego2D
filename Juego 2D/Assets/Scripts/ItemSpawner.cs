using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Prefabs de �tems")]
    public GameObject applePrefab;
    public GameObject bananaPrefab;

    [Header("Cantidad m�xima")]
    public int maxApples = 5;
    public int maxBananas = 7;

    [Header("Zona de spawn")]
    public Transform leftLimit;
    public Transform rightLimit;
    public float yPosition = 0.5f; // altura de spawn

    // M�todo p�blico para generar las frutas
    public void SpawnFruits()
    {
        SpawnItems(applePrefab, maxApples);
        SpawnItems(bananaPrefab, maxBananas);
    }

    // M�todo privado para instanciar
    private void SpawnItems(GameObject itemPrefab, int maxAmount)
    {
        for (int i = 0; i < maxAmount; i++)
        {
            float randomX = Random.Range(leftLimit.position.x, rightLimit.position.x);
            Vector2 spawnPos = new Vector2(randomX, yPosition);
            Instantiate(itemPrefab, spawnPos, Quaternion.identity);
        }
    }
}
