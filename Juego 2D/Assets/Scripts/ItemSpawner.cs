using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bananaPrefab;

    public int maxApples = 5;
    public int maxBananas = 7;

    public List<GameObject> puntosDisponibles = new List<GameObject>();

    void Start()
    {
        // Generar apples
        int cantidadApples = Random.Range(1, maxApples + 1);
        for (int i = 0; i < cantidadApples; i++)
        {
            GenerarItem(applePrefab);
        }

        // Generar bananas
        int cantidadBananas = Random.Range(1, maxBananas + 1);
        for (int i = 0; i < cantidadBananas; i++)
        {
            GenerarItem(bananaPrefab);
        }
    }

    void GenerarItem(GameObject itemPrefab)
    {
        if (puntosDisponibles.Count == 0) return;

        int index = Random.Range(0, puntosDisponibles.Count);
        GameObject punto = puntosDisponibles[index];

        Instantiate(itemPrefab, punto.transform.position, Quaternion.identity);

        puntosDisponibles.RemoveAt(index);
    }
}
