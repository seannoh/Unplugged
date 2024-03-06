using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPanelController : MonoBehaviour
{

    private BackgroundPanel backgroundPanel;
    // Start is called before the first frame update
    void Start()
    {
        UIMgr.Instance.ShowPanel<BackgroundPanel>("BackgroundPanel", E_PanelLayer.Bot, (panel) => {
            backgroundPanel = panel;
        });
        EventMgr.Instance.AddEventListener<string>("UpdateBackground", UpdateBackground);
        EventMgr.Instance.AddEventListener("HideBackground", HideBackground);
    }

    private void UpdateBackground(string backgroundName)
    {
        StartCoroutine(UpdateBackgroundCoroutine(backgroundName));
    }

    private void HideBackground()
    {
        StartCoroutine(HideBackgroundCoroutine());
    }

    private IEnumerator HideBackgroundCoroutine()
    {
        yield return StartCoroutine(FadeOut());
        UIMgr.Instance.HidePanel("BackgroundPanel");
    }

    private IEnumerator UpdateBackgroundCoroutine(string backgroundName)
    {
        yield return StartCoroutine(FadeOut());
        UIMgr.Instance.ShowPanel<BackgroundPanel>("BackgroundPanel", E_PanelLayer.Bot, (panel) => {
            backgroundPanel = panel;
            panel.GetComponent<Image>().sprite = ResMgr.Instance.Load<Sprite>("Backgrounds/" + backgroundName);
        });
        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            backgroundPanel.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            backgroundPanel.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }

    private void OnDestroy()
    {
        EventMgr.Instance.RemoveEventListener<string>("UpdateBackground", UpdateBackground);
        EventMgr.Instance.RemoveEventListener("HideBackground", HideBackground);
        
        if(this != null) UIMgr.Instance.HidePanel("BackgroundPanel");
    }
}
