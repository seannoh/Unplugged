using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class DialoguePanelController : MonoBehaviour
{
    public bool isDialogueActive = false;
    private Story story;
    private BasePanel dialoguePanel = null;

    private TMP_Text dialogueTitleText = null;
    private TMP_Text dialogueBodyText = null;
    private GameObject choicesPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        EventMgr.Instance.AddEventListener<TextAsset>("DialogueStart", DialogueStart);
        EventMgr.Instance.AddEventListener("DialogueEnd", DialogueEnd);
    }


    private void DialogueStart(TextAsset textAsset)
    {
        if(isDialogueActive) return;
        isDialogueActive = true;
        story = new Story(textAsset.text);
        UIMgr.Instance.ShowPanel<DialoguePanel>("DialoguePanel", E_PanelLayer.Mid, (panel) => {
            dialoguePanel = panel;
            dialogueTitleText = dialoguePanel.transform.Find("DialogueTitleText").GetComponent<TMP_Text>();
            dialogueBodyText = dialoguePanel.transform.Find("DialogueBodyText").GetComponent<TMP_Text>();
            choicesPanel = dialoguePanel.transform.Find("ChoicesPanel").gameObject;
            RefreshView();
        });


    }

    private void RefreshView()
    {
        ClearPanel();
        // get dialogue speaker from first line
        if(story.canContinue) {
            string dialogueSpeaker = story.Continue();
            dialogueSpeaker = dialogueSpeaker.Trim();
            dialogueTitleText.text = dialogueSpeaker;
        }

        // get set of lines
        while(story.canContinue) {
            string line = story.Continue();
            line = line.Trim();
            dialogueBodyText.text += line + "\n";
        }

        // display choices
        if(story.currentChoices.Count > 0) {
            for(int i = 0; i < story.currentChoices.Count; i++) {
                Choice choice = story.currentChoices[i];
                Button choiceButton = CreateChoiceView(choice.text.Trim());
                choiceButton.onClick.AddListener(() => {
                    story.ChooseChoiceIndex(choice.index);
                    RefreshView();
                });
            }
        } 
        // at end of dialogue, close panel
        else {
            Button endButton = CreateChoiceView("End of dialogue.");
            endButton.onClick.AddListener(() => {
                EventMgr.Instance.EventTrigger("DialogueEnd");
            });
        }
    }

    private void ClearPanel()
    {
        dialogueTitleText.text = "";
        dialogueBodyText.text = "";
        foreach(Transform child in choicesPanel.transform) {
            Destroy(child.gameObject);
        }
    }

    private Button CreateChoiceView(string text)
    {
        GameObject choiceButtonObj = ResMgr.Instance.Load<GameObject>("UI/ChoiceButton");
        choiceButtonObj.transform.SetParent(choicesPanel.transform, false);

        TMP_Text choiceText = choiceButtonObj.GetComponentInChildren<TMP_Text>();
        choiceText.text = text;

        return choiceButtonObj.GetComponent<Button>();
    }

    private void DialogueEnd()
    {
        isDialogueActive = false;
        UIMgr.Instance.HidePanel("DialoguePanel");
    }
}
