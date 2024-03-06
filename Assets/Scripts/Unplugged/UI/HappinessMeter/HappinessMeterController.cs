using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessMeterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIMgr.Instance.ShowPanel<HappinessMeterPanel>("HappinessMeterPanel", E_PanelLayer.Mid);
    }

    private void OnDestroy()
    {
        if(this != null) UIMgr.Instance.HidePanel("HappinessMeterPanel");
    }
}
