using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

  public class CamMove : MonoBehaviour
    {
        public static bool cursorLocked = true;

        public Transform player;
        public Transform cams;
        public Transform Camera;

        public float xSensetivity;
        public float ySensetivity;
        public float MaxAngle;

        private float distance = -3;

        public bool inMenu;

        public float MaxDis, MinDis;

        private Quaternion camCenter;
        private float MW;

        void Start() 
        {
            camCenter = cams.localRotation;
        }

        void Update() 
        {
            SetY();
            SetX();
            SetDistance();

            UpdateCursorLock();
        }
        void SetY() 
        {      
            float t_input = Input.GetAxis("Mouse Y") * ySensetivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(t_input, -Vector3.right);
            Quaternion t_delta = cams.localRotation * t_adj;

            if (Quaternion.Angle(camCenter, t_delta) < MaxAngle)
            {
                cams.localRotation = t_delta;

            }
        }
        
        void SetX()
        {
            float t_input = Input.GetAxis("Mouse X") * xSensetivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(t_input, Vector3.up);
            Quaternion t_delta = player.localRotation * t_adj;
            player.localRotation = t_delta;
        }

        void SetDistance() 
        {
            MW = Input.GetAxis("Mouse ScrollWheel");
            if (distance < MinDis && MW > 0)
            {
                distance += MW;
            }
            if (distance > MaxDis && MW < 0) 
            {
                distance += MW;
            }

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
