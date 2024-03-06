using TMPro;
using UnityEngine;

public class GameOverPanel : BasePanel
{

    private TMP_Text scoreText = null;
    private TMP_Text statusText = null;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.GetChild(0).Find("ScoreText").GetComponentInChildren<TMP_Text>();
        statusText = transform.GetChild(0).Find("StatusText").GetComponentInChildren<TMP_Text>();

        RenderEndInfo();
    }

    private void RenderEndInfo()
    {
        scoreText.text = "Final Happiness Score: " + Player.Instance.happiness.ToString();
        switch (Player.Instance.happiness)
        {
            case <= 0:
                statusText.text = "Status: Failed";
                break;
            case <= 50:
                statusText.text = "Status: OK";
                break;
            case <= 100 :
                statusText.text = "Status: Success";
                break;
            case < 200:
                statusText.text = "Status: Great Success";
                break;
            default:
                statusText.text = "Status: Unknown";
                break;
        }
    }

    protected override void OnClick(string buttonName)
    {
        switch (buttonName)
        {
            case "RestartButton":
                UIMgr.Instance.HidePanel("GameOverPanel");
                AudioMgr.Instance.ClearAudio();
                AudioMgr.Instance.StopBGM();
                GoToScene("StartScene");
                break;
            case "QuitButton":
                Application.Quit();
                break;
        }
    }

    private void GoToScene(string sceneName)
    {
        UIMgr.Instance.ShowPanel<LoadingPanel>("LoadingPanel", E_PanelLayer.Top); //show loading panel

        SceneMgr.Instance.LoadSceneAsync(sceneName, () => {
            EventMgr.Instance.EventTrigger("ProgressBar", 1f);
        });
    }
}