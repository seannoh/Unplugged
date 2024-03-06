using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HappinessMeterPanel : BasePanel
{
    private TMP_Text happinessText = null;
    private Slider happinessSlider = null;

    // Start is called before the first frame update
    void Start()
    {
        happinessText = transform.GetComponentInChildren<TMP_Text>();
        happinessSlider = transform.GetComponentInChildren<Slider>();
        EventMgr.Instance.AddEventListener<int>("UpdateHappiness", UpdateHappiness);
    }

    private void UpdateHappiness(int happiness)
    {
        happinessText.text = "Happiness: " + happiness.ToString();
        happinessSlider.value = happiness;
    }

    private void OnDestroy()
    {
        EventMgr.Instance.RemoveEventListener<int>("UpdateHappiness", UpdateHappiness);
    }
}
