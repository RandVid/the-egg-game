using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public GameObject mama;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(mama.transform);
    }

    private void FixedUpdate()
    {
        if (transform.localPosition.z > 415)
        {
            transform.Translate(10000, 0, 10000);
        }
    }
}
