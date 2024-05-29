using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CamMove_copI : MonoBehaviour
{
    public static bool cursorLocked = true;

    public Transform player;
    public Transform cams;
    public Transform Camera;
    public Renderer Egg;
    public Color RayCol;

    public GameObject Sungalsses;

    public Material Diffuse, normal;

    public float xSensetivity;
    public float ySensetivity;

    public float distance = -3, RS;

    public bool firstPerson;

    public float MaxDis, MinDis, MaxAngle, originDistance = 3, RaycastDistance, RaycastDistanceX, offset;

    private Quaternion camCenter;
    private float MW;

    void Start()
    {
        camCenter = cams.localRotation;
        Egg = GameObject.Find("Egg").GetComponent<Renderer>();
        distance = originDistance;
    }

    void Update()
    {
        SetY();
        SetX();
        SeeEgg();
        SetDistance();

        UpdateCursorLock();;
    }

    void SetY()
    {
        float t_input = Input.GetAxis("Mouse Y") * ySensetivity * Time.deltaTime;
        Quaternion t_adj = Quaternion.AngleAxis(t_input, -Vector3.right);
        Quaternion t_delta = cams.localRotation * t_adj;

        RaycastHit lol = new RaycastHit();

        if (Physics.Raycast(player.transform.position, -Camera.transform.forward, out RaycastHit hit, -MaxDis))
        {
            distance = -hit.distance + offset;
        }
        else 
        {
            distance = originDistance;
        }

        if (Quaternion.Angle(camCenter, t_delta) < MaxAngle)
        {
            cams.localRotation = t_delta;
        }

        if (distance > -0.23f)
        {
            Egg.material = normal;
            firstPerson = true;
            Sungalsses.SetActive(false);
        }
        else
        {
            Egg.material = Diffuse;
            firstPerson = false;
            Sungalsses.SetActive(true);
        }
    }

    void SetX()
    {
        float t_input = Input.GetAxis("Mouse X") * xSensetivity * Time.deltaTime;

        Debug.Log(t_input);

        Quaternion t_adj = Quaternion.AngleAxis(t_input, Vector3.up);
        Quaternion t_delta = player.localRotation * t_adj;
        player.localRotation = t_delta;
    }

    void SeeEgg()
    {
        if (Physics.Raycast(player.transform.position, -Camera.transform.forward, out RaycastHit hit, -MaxDis))
        {
            distance = -hit.distance + offset;
        }

        Debug.DrawRay(player.transform.position, -Camera.transform.forward, RayCol, distance);
    }

    void SetDistance()
    {    
        Camera.transform.localPosition = (new Vector3(0f, 0f, distance));
    }

    void UpdateCursorLock()
    {


        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;
                Application.Quit();
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = true;
            }
        }
    }
}
  
