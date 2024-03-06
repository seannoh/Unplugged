using UnityEngine;

public class Player : Singleton<Player>
{
    public int happiness = 0;
    public string playerName = "Player";

    public void UpdateName(string name)
    {
        playerName = name;
    }

    public void UpdateHappiness(int value)
    {
        happiness = value;
        EventMgr.Instance.EventTrigger<int>("UpdateHappiness", happiness);
    }

}