using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPanel : BasePanel
{
    void Start()
    {
        UIMgr.Instance.ShowPanel<BackgroundPanel>("BackgroundPanel", E_PanelLayer.Bot);
    }
    
    
}
