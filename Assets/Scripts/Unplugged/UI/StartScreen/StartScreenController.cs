using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIMgr.Instance.ShowPanel<StartScreenPanel>("StartScreenPanel", E_PanelLayer.Mid);   
    }

}
