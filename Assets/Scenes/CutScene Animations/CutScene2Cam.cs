using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene2Cam : MonoBehaviour
{
    public string scene;
    public bool ChangeScene;

    // Update is called once per frame
    void Update()
    {
        if (ChangeScene) SceneManager.LoadScene(scene);
    }
}
