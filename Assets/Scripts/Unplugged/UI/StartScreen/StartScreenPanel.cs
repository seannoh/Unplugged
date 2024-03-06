using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenPanel : BasePanel
{

    protected override void OnClick(string buttonName)
    {
        switch (buttonName)
        {
            case "StartGameButton":
            Debug.Log("start game");
                UIMgr.Instance.ShowPanel<CharacterCreationPanel>("CharacterCreationPanel", E_PanelLayer.Top);
                break;
            case "OptionsButton":
                // UIMgr.Instance.ShowPanel<OptionsScreenPanel>("OptionsScreenPanel", E_PanelLayer.Top);
                break;
            case "QuitButton":
                Application.Quit();
                break;
        }
    }

}
