using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFrog : MonoBehaviour
{
    public Dialouge dialouge;

    public void TriggerDialogue()
    {
            FindObjectOfType<MAnagere>().StartDialogue(dialouge);
    }
        
}
