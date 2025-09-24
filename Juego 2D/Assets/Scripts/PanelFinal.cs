using UnityEngine;
using TMPro;

public class PanelFinal : MonoBehaviour
{
    [Header("Panel Final")]
    public GameObject endPanel;

    [Header("Textos de resultados")]
    public TMP_Text finalAppleText;
    public TMP_Text finalBananaText;
    public TMP_Text finalTotalText;
    public TMP_Text finalTimeText;

    private bool panelShown = false;

    private void Start()
    {
        endPanel.SetActive(false);
    }
    private void OnEnable()
    {
        if (!panelShown)
        {
            int apples = GameManager.Instance.ScoreApple;
            int bananas = GameManager.Instance.ScoreBanana;
            float totalTime = GameManager.Instance.GlobalTime;

            ShowFinalPanel(apples, bananas, totalTime);
        }
    }

    public void ShowFinalPanel(int apples, int bananas, float totalTime)
    {
        if (panelShown) return;

        if (endPanel != null)
           

        finalAppleText.text = $"Score       : {apples}";
        finalBananaText.text = $"Score       : {bananas}";
        finalTotalText.text = $"Total: {apples + bananas}";
        finalTimeText.text =  FormatTime(totalTime);

        Time.timeScale = 0f;
        panelShown = true;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
