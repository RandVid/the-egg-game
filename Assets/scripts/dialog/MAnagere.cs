using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MAnagere : MonoBehaviour
{
    public TextMeshPro dialougeText;
    public TextMeshPro Name;

    public GameObject FAm;
    public GameObject text;
    public GameObject GameCam;
    public GameObject D1Cam;

    public Transform TreeCam;
    public Transform TreeName;
    public Transform TreeText;

    public Transform Tree2Cam;
    public Transform Tree2Name;
    public Transform Tree2Text;

    public Transform FrogCam;
    public Transform FrogName;
    public Transform FrogText;

    public Transform BirbCam;
    public Transform BirbName;
    public Transform BirbText;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialouge dialouge)
    {
        FAm.SetActive(true);
        text.SetActive(true);
        GameCam.SetActive(false);
        D1Cam.SetActive(true);
        Name.text = dialouge.name;
        sentences.Clear();

        foreach(string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSent();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            DisplayNextSent();
        }

        if (Name.text == "Tree")
        {
            D1Cam.transform.position = TreeCam.transform.position;
            D1Cam.transform.rotation = TreeCam.transform.rotation;
            FAm.transform.position = TreeName.transform.position;
            FAm.transform.rotation = TreeName.transform.rotation;
            text.transform.position = TreeText.transform.position;
            text.transform.rotation = TreeText.transform.rotation;
        }
        if (Name.text == "Tree2")
        {
            D1Cam.transform.position = Tree2Cam.transform.position;
            D1Cam.transform.rotation = Tree2Cam.transform.rotation;
            FAm.transform.position = Tree2Name.transform.position;
            FAm.transform.rotation = Tree2Name.transform.rotation;
            text.transform.position = Tree2Text.transform.position;
            text.transform.rotation = Tree2Text.transform.rotation;
        }
        if (Name.text == "Frog")
        {
            D1Cam.transform.position = FrogCam.transform.position;
            D1Cam.transform.rotation = FrogCam.transform.rotation;
            FAm.transform.position = FrogName.transform.position;
            FAm.transform.rotation = FrogName.transform.rotation;
            text.transform.position = FrogText.transform.position;
            text.transform.rotation = FrogText.transform.rotation;
        }
        if (Name.text == "Nice Birb")
        {
            D1Cam.transform.position = BirbCam.transform.position;
            D1Cam.transform.rotation = BirbCam.transform.rotation;
            FAm.transform.position = BirbName.transform.position;
            FAm.transform.rotation = BirbName.transform.rotation;
            text.transform.position = BirbText.transform.position;
            text.transform.rotation = BirbText.transform.rotation;
        }
    }

    public void DisplayNextSent()
    {
        if(sentences.Count == 0)
        {
            FAm.SetActive(false);
            text.SetActive(false);
            GameCam.SetActive(true);
            D1Cam.SetActive(false);
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentences(sentence));
    }

    IEnumerator TypeSentences(string sentence)
    {
        dialougeText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return null;
        }
    }
    
    public void EndDia()
    {
        FAm.SetActive(false);
        text.SetActive(false);
        GameCam.SetActive(true);
        D1Cam.SetActive(false);
    }
    
}
