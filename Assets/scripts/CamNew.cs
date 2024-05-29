using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamNew : MonoBehaviour
{
    public float XSens, YSens;

    private void Update()
    {
        float x_rotate = Input.GetAxis("Mouse X") * XSens * Time.deltaTime;
        float y_rotate = Input.GetAxis("Mouse Y") * YSens * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, x_rotate, y_rotate) * transform.rotation;
    }
}
