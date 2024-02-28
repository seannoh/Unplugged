using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_AllKeysActs
{
    up,
    down,
    left,
    right,
}


#region Input manager
//Input manager is based on event center and public mono manager
//By using listeners, you can control any gameObjects

//You dont have to call any methods of this script.
//Instead, you need to add the listeners of "KeyIsPressed", "KeyIsReleased", and "KeyIsHeld"

//If you want to add new controls, just add new key value pairs inside the dict
//(I may add methods to read from files, not implemented yet)
#endregion
public class InputMgr : Singleton<InputMgr>
{
    public Dictionary<E_AllKeysActs, KeyCode> KeySet = new Dictionary<E_AllKeysActs, KeyCode>() //dict of all the controls
    {
        {E_AllKeysActs.up, KeyCode.W},
        {E_AllKeysActs.down,KeyCode.S},
        {E_AllKeysActs.left, KeyCode.A},
        {E_AllKeysActs.right, KeyCode.D},

    };

    private bool isSwitchOn = true; //flag to open the global check
    public InputMgr() //Constructor, uses public mono manager to open Update function
    {
        MonoMgr.Instance.AddUpdateListener(InputUpdate);
        // MonoMgr.Instance.AddFixedUpdateListener(InputFixedUpdate);
    }

    private void InputUpdate() //The logic in update method
    {
        if (!isSwitchOn) return;
        CheckKeyPress(E_AllKeysActs.up);
        CheckKeyPress(E_AllKeysActs.down);
        CheckKeyPress(E_AllKeysActs.left);
        CheckKeyPress(E_AllKeysActs.right);

        CheckKeyRelease(E_AllKeysActs.up);
        CheckKeyRelease(E_AllKeysActs.down);
        CheckKeyRelease(E_AllKeysActs.left);
        CheckKeyRelease(E_AllKeysActs.right);
        
        CheckKeyHeld(E_AllKeysActs.up);
        CheckKeyHeld(E_AllKeysActs.down);
        CheckKeyHeld(E_AllKeysActs.left);
        CheckKeyHeld(E_AllKeysActs.right);
    }

    private void InputFixedUpdate()
    {

    }
    
    /// <summary>
    ///Change key sets
    /// </summary>
    /// <param name="act">the action you want to change</param>
    /// <param name="newKey">the new key you want to change to</param>
    public void ChangeKey(E_AllKeysActs act, KeyCode newKey)
    {
         KeySet[act] = newKey;
    }
    
    private void CheckKeyPress(E_AllKeysActs act) //check if key is pressed, only trigger event
    {
        if (Input.GetKeyDown(KeySet[act])) //press key
        {
            EventMgr.Instance.EventTrigger("KeyIsPressed", act);
        }
    }

    private void CheckKeyRelease(E_AllKeysActs act)
    {
        if (Input.GetKeyUp(KeySet[act])) //release key
        {
            EventMgr.Instance.EventTrigger("KeyIsReleased", act);
        }
    }
    
    private void CheckKeyHeld(E_AllKeysActs act)
    {
        if (Input.GetKey(KeySet[act])) //hold key
        {
            EventMgr.Instance.EventTrigger("KeyIsHeld", act);
        }
    }
    

    /// <summary>
    ///Open or close global check
    /// </summary>
    /// <param name="state">open or close</param>
    public void SwitchAllButtons(bool state)
    {
        isSwitchOn = state;
    }
}



    