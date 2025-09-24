using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float globalTime;
    private int scoreApple = 0;
    private int scoreBanana = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void AddApple(int value = 5)
    {
        scoreApple += value;
    }

    public void AddBanana(int value = 7)
    {
        scoreBanana += value;
    }

    // Propiedades públicas
    public float GlobalTime { get => globalTime; }
    public int ScoreApple { get => scoreApple; }
    public int ScoreBanana { get => scoreBanana; }
}
