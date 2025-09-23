using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private float globalTime;

    private int scoreApple=0;
    private int scoreBanana = 0;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        globalTime += Time.deltaTime;
    }

    public void TotalTime(float timeScene)
    {
        globalTime = timeScene;
    }

    public void TotalApple(int apple)
    {
        scoreApple += apple;
        Debug.Log("Manzanas recogidas: " + scoreApple);
    }

    public void TotalBanana(int banana)
    {
        scoreBanana += banana;
        Debug.Log("Bananas recogidas: " + scoreBanana);

    }

  

    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int ScoreApple { get => scoreApple; set => scoreApple = value; }
    public int ScoreBanana { get => scoreBanana; set => scoreBanana = value; }



}





