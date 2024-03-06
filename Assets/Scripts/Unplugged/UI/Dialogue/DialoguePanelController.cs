using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using RedBlueGames.Tools.TextTyper;
using System.Threading.Tasks;

public class DialoguePanelController : MonoBehaviour
{
    public bool isDialogueActive = false;
    private Story story;
    private BasePanel dialoguePanel = null;

    private TMP_Text dialogueTitleText = null;
    private TextTyper dialogueTitleTyper = null;
    private TMP_Text dialogueBodyText = null;
    private TextTyper dialogueBodyTyper = null;
    private GameObject choicesPanel = null;
    private TextTyper currentTyper = null;
    private string currentTitle = "";

    // Start is called before the first frame update
    void Start()
    {
        EventMgr.Instance.AddEventListener<TextAsset>("DialogueStart", DialogueStart);
        EventMgr.Instance.AddEventListener("DialogueEnd", DialogueEnd);

        EventMgr.Instance.EventTrigger<TextAsset>("DialogueStart", ResMgr.Instance.Load<TextAsset>("InkStories/MainStory"));
    }

    private void Update()
    {
        if (isDialogueActive && currentTyper != null && Input.GetKeyDown(KeyCode.Space))
        {
            currentTyper.Skip();
        }
    }

    private void BindFunctions(Story story)
    {
        story.BindExternalFunction<string>("ShowBackground", (backgroundName) =>
        {
            EventMgr.Instance.EventTrigger<string>("UpdateBackground", backgroundName);
            print("show background: " + backgroundName);
        });
        story.BindExternalFunction<string, string>("ShowCharacter", (characterName, position) =>
        {
            EventMgr.Instance.EventTrigger<string, string>("ShowCharacter", characterName, position);
            print("show character: " + characterName);
        });
        story.BindExternalFunction<string>("HideCharacter", (characterName) =>
        {
            EventMgr.Instance.EventTrigger<string>("HideCharacter", characterName);
            print("hide character: " + characterName);
        });
        story.BindExternalFunction<string>("PlayBGM", (bgmName) =>
        {
            AudioMgr.Instance.ClearAudio();
            AudioMgr.Instance.PlayBGM(bgmName);
            print("play bgm: " + bgmName);
        });
        story.BindExternalFunction<string>("PlaySFX", (sfxName) =>
        {
            AudioMgr.Instance.PlayAudio(sfxName, false);
            print("play sfx: " + sfxName);
        });
        story.BindExternalFunction("RestartGame", () =>
        {
            EventMgr.Instance.EventTrigger("GameOver");
        });
    }

    private void InitializeVariables()
    {
        Player.Instance.UpdateHappiness((int)story.variablesState["happiness"]);
        story.ObserveVariable("happiness", (name, happiness) =>
        {
            Player.Instance.UpdateHappiness((int)happiness);
        });

        if (Player.Instance.playerName == "")
        {
            Player.Instance.UpdateName("Default");
        }
        story.variablesState["name"] = Player.Instance.playerName;

    }


    private void DialogueStart(TextAsset textAsset)
    {
        if (isDialogueActive) return;
        isDialogueActive = true;
        story = new Story(textAsset.text);
        story.ResetState();

        BindFunctions(story);
        InitializeVariables();

        UIMgr.Instance.ShowPanel<DialoguePanel>("DialoguePanel", E_PanelLayer.Mid, (panel) =>
        {
            dialoguePanel = panel;
            dialogueTitleText = dialoguePanel.transform.Find("DialogueTitleText").GetComponent<TMP_Text>();
            dialogueTitleTyper = dialoguePanel.transform.Find("DialogueTitleText").GetComponent<TextTyper>();
            dialogueBodyText = dialoguePanel.transform.Find("DialogueBodyText").GetComponent<TMP_Text>();
            dialogueBodyTyper = dialoguePanel.transform.Find("DialogueBodyText").GetComponent<TextTyper>();
            choicesPanel = dialoguePanel.transform.Find("ChoicesPanel").gameObject;
            RefreshView();
        });


    }

    private void RefreshView()
    {
        ClearPanel();

        // get a dialogue line
        if (story.canContinue)
        {
            string line = story.Continue();
            line = line.Trim();

            // display dialogue title and body using TextTyper
            if (currentTitle != (string)story.variablesState["title"])
            {
                currentTitle = (string)story.variablesState["title"];
                currentTyper = dialogueTitleTyper;
                dialogueTitleTyper.TypeText(currentTitle, 0.1f);
                dialogueTitleTyper.PrintCompleted.AddListener(() =>
                {
                    currentTyper = dialogueBodyTyper;
                    // Task.Delay(500);
                    dialogueBodyTyper.TypeText(line, 0.02f);
                });
            }
            else
            {
                dialogueTitleText.text = currentTitle;
                currentTyper = dialogueBodyTyper;
                dialogueBodyTyper.TypeText(line, 0.02f);
            }
            dialogueBodyTyper.PrintCompleted.AddListener(() =>
            {
                currentTyper = null;
                DisplayChoices(story);
            });

        }
        else
        {
            DisplayChoices(story);
        }


    }

    private void DisplayChoices(Story story)
    {
        // clear old choices
        foreach (Transform child in choicesPanel.transform)
        {
            Destroy(child.gameObject);
        }
        // display choices
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                List<string> choiceTags = choice.tags;

                // create button
                Button choiceButton = CreateChoiceView(choice.text.Trim());
                if (choiceTags != null && choiceTags.Contains("unchoosable"))
                {
                    choiceButton.interactable = false;
                    choiceButton.GetComponentInChildren<TMP_Text>().color = new Color(0.5f, 0.5f, 0.5f);
                };
                choiceButton.onClick.AddListener(() =>
                {
                    // go to choice index
                    story.ChooseChoiceIndex(choice.index);
                    story.Continue();
                    RefreshView();
                });
            }
            Canvas.ForceUpdateCanvases();
        }
        // at end of set of lines, show next button
        else
        {
            Button endButton = CreateChoiceView("Next");
            endButton.onClick.AddListener(() =>
            {
                RefreshView();
            });
        }
    }

    private void ClearPanel()
    {
        Canvas.ForceUpdateCanvases();

        dialogueTitleText.text = "";
        dialogueBodyText.text = "";
        foreach (Transform child in choicesPanel.transform)
        {
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

    private void OnDestroy()
    {
        EventMgr.Instance.RemoveEventListener<TextAsset>("DialogueStart", DialogueStart);
        EventMgr.Instance.RemoveEventListener("DialogueEnd", DialogueEnd);
    }
}
