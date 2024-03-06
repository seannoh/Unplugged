using UnityEngine;

public class GameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventMgr.Instance.AddEventListener("GameOver", ShowGameOverPanel);
    }

    private void ShowGameOverPanel()
    {
        UIMgr.Instance.ShowPanel<GameOverPanel>("GameOverPanel", E_PanelLayer.Mid);
    }

    void OnDestroy()
    {
        EventMgr.Instance.RemoveEventListener("GameOver", ShowGameOverPanel);
    }
}