using System.Collections.Generic;
using UnityEngine;

public enum CharacterPosition
{
    left,
    mid,
    right
}

public class CharacterPanelController : MonoBehaviour
{


    private CharacterPanel characterPanel;
    private Dictionary<CharacterPosition, string> currentCharacters = new Dictionary<CharacterPosition, string>();

    void Start()
    {
        currentCharacters.Add(CharacterPosition.left, "");
        currentCharacters.Add(CharacterPosition.mid, "");
        currentCharacters.Add(CharacterPosition.right, "");

        EventMgr.Instance.AddEventListener<string, string>("ShowCharacter", ShowCharacter);
        EventMgr.Instance.AddEventListener<string>("HideCharacter", HideCharacter);
        EventMgr.Instance.AddEventListener<TextAsset>("DialogueStart", InitializePanel);
        EventMgr.Instance.AddEventListener("DialogueEnd", ClearPanel);
    }


    private void ShowCharacter(string characterName, string position)
    {
        CharacterPosition characterPosition = (CharacterPosition)System.Enum.Parse(typeof(CharacterPosition), position);
        currentCharacters[characterPosition] = characterName;
        characterPanel.UpdateCharacter(currentCharacters);
    }
    
    private void HideCharacter(string characterName)
    {
        List<CharacterPosition> keys = new List<CharacterPosition>(currentCharacters.Keys);
        foreach (CharacterPosition key in keys)
        {
            if (currentCharacters[key] == characterName)
            {
                currentCharacters[key] = "";
            }
        }
        characterPanel.UpdateCharacter(currentCharacters);
    }

    private void InitializePanel(TextAsset _)
    {
        UIMgr.Instance.ShowPanel<CharacterPanel>("CharacterPanel", E_PanelLayer.Mid, (panel) => {
            characterPanel = panel;
            characterPanel.UpdateCharacter(currentCharacters);
        });
    }

    private void ClearPanel()
    {
        UIMgr.Instance.HidePanel("CharacterPanel");
    }

    void OnDestroy()
    {
        EventMgr.Instance.RemoveEventListener<string, string>("ShowCharacter", ShowCharacter);
        EventMgr.Instance.RemoveEventListener<string>("HideCharacter", HideCharacter);
        EventMgr.Instance.RemoveEventListener<TextAsset>("DialogueStart", InitializePanel);
        EventMgr.Instance.RemoveEventListener("DialogueEnd", ClearPanel);
    }
}