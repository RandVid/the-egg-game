using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public MAnagere dm;

    public string col;

    public int Ont = 0;

    public bool tut = false;

    public void OnTriggerEnter(Collider other)
    {
        Ont = 1;
        col = other.name;
    }

    public void Update()
    { 
        if (Ont == 1) {
            if ((col == "Nice Birb") && (tut == false)) {
                tut = true;
                FindObjectOfType<TriggerBirb>().TriggerDialogue();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (col == "tree")
                    FindObjectOfType<Trigger>().TriggerDialogue();
                if (col == "tree2")
                    FindObjectOfType<TriggerTree2>().TriggerDialogue();
                if (col == "frog")
                    FindObjectOfType<TriggerFrog>().TriggerDialogue();
                if (col == "Nice Birb")
                    FindObjectOfType<TriggerBirb>().TriggerDialogue();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        dm.EndDia();
        Ont = 0;
    }
}
