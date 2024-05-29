using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBirb : MonoBehaviour
{
    public Dialouge dialouge;

    public void TriggerDialogue()
    {
            FindObjectOfType<MAnagere>().StartDialogue(dialouge);
    }
        
}
