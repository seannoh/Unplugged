using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationPanel : BasePanel
{
    private TMP_InputField nameInput = null;
    private Button submitButton = null;
    private Button closeButton = null;
    void Start()
    {
        nameInput = transform.GetComponentInChildren<TMP_InputField>();
        submitButton = transform.GetChild(0).Find("CharacterCreationSubmitButton").GetComponent<Button>();
        closeButton = transform.GetChild(0).Find("CharacterCreationExitButton").GetComponent<Button>();
        submitButton.onClick.AddListener(OnSubmitButtonClicked);
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnSubmitButtonClicked()
    {
        Debug.Log("submit button clicked");
        if(nameInput.text.Trim() == "") return;
        Player.Instance.UpdateName(nameInput.text.Trim());
        Debug.Log(nameInput.text);
        Debug.Log(Player.Instance.playerName);
        UIMgr.Instance.HidePanel("CharacterCreationPanel");
        UIMgr.Instance.HidePanel("StartScreenPanel");
        GoToScene("MainScene");

    }

    private void OnCloseButtonClicked()
    {
        UIMgr.Instance.HidePanel("CharacterCreationPanel");
    }

    
    private void GoToScene(string sceneName)
    {
        UIMgr.Instance.ShowPanel<LoadingPanel>("LoadingPanel", E_PanelLayer.Top); //show loading panel

        SceneMgr.Instance.LoadSceneAsync(sceneName, () => {
            EventMgr.Instance.EventTrigger("ProgressBar", 1f);
        });
    }

    void OnDestroy()
    {
        submitButton.onClick.RemoveAllListeners();
        closeButton.onClick.RemoveAllListeners();
    }
}