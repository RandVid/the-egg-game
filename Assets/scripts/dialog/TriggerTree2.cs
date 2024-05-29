using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTree2 : MonoBehaviour
{
    public Dialouge dialouge;

    public void TriggerDialogue()
    {
            FindObjectOfType<MAnagere>().StartDialogue(dialouge);
    }
        
}
