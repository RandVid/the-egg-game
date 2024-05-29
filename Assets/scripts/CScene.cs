using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CScene : MonoBehaviour
{
    public bool start = false;
    public Camera cam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextScene")
        {
            SceneManager.LoadScene("CutScene1");
        }
    }


}
