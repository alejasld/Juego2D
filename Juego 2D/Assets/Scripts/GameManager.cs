using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TMP_Text appleText;
    public TMP_Text bananaText;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Final")
        {
            // Buscar los textos específicos de la escena final
            TMP_Text appleFinal = GameObject.Find("appleFinalText")?.GetComponent<TextMeshProUGUI>();
            TMP_Text bananaFinal = GameObject.Find("bananaFinalText")?.GetComponent<TextMeshProUGUI>();
            TMP_Text scoreFinal = GameObject.Find("scoreFinalText")?.GetComponent<TextMeshProUGUI>();
            TMP_Text finalTime = GameObject.Find("tiempoFinalText")?.GetComponent<TextMeshProUGUI>();

            if (appleFinal != null) appleFinal.text = scoreApple.ToString();
            if (bananaFinal != null) bananaFinal.text = scoreBanana.ToString();
            if (scoreFinal != null) scoreFinal.text = (scoreApple + scoreBanana).ToString();
        }
        else
        {
            // Escenas normales ? HUD
            appleText = GameObject.Find("AppleText")?.GetComponent<TextMeshProUGUI>();
            bananaText = GameObject.Find("BananaText")?.GetComponent<TextMeshProUGUI>();
            UpdateScoreUI();
        }
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
    private void UpdateScoreUI()
    {
        if (appleText != null)
        {
            appleText.text = scoreApple.ToString();
        }

        if (bananaText != null)
        {
            bananaText.text = scoreBanana.ToString();
        }
    }


    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int ScoreApple { get => scoreApple; set => scoreApple = value; }
    public int ScoreBanana { get => scoreBanana; set => scoreBanana = value; }

}



