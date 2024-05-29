using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody rig;

    public GameObject ball;
    public GameObject player;
    public GameObject XAxis;
    public GameObject GndDetrector;
    public LayerMask Ground;

    public bool isGrounded, isInWater;

    public float Force, EmersionForce, breakTime, MaxSpeed, waterSink, RiverHeight, RiverY, MaxSize;
    public int JumpForce;

    private void Start()
    {
        rig = GameObject.Find("Egg").GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h_rotate = Input.GetAxis("Horizontal");
        float v_rotate = Input.GetAxis("Vertical");

        
        if (isInWater)
        { 
            rig.AddForce(Vector3.up * EmersionForce * (Math.Min(RiverY + RiverHeight / 2 + MaxSize / 2 - transform.position.y, MaxSize) / MaxSize));
            // Debug.LogWarning((Math.Min(RiverY + RiverHeight / 2 + MaxSize / 2 - transform.position.y, MaxSize) / MaxSize));
        }
        else
        {
            isGrounded = Physics.Raycast(GndDetrector.transform.position, Vector3.down, out RaycastHit gnd, 1f, Ground);
            if (rig.velocity.x < MaxSpeed ^ rig.velocity.y < MaxSpeed ^ rig.velocity.z < MaxSpeed ^ rig.velocity.x < -MaxSpeed ^ rig.velocity.y < -MaxSpeed ^ rig.velocity.z < -MaxSpeed)
            {
                rig.AddForce(XAxis.transform.forward * Force * v_rotate);
                rig.AddForce(XAxis.transform.right * Force * h_rotate);
            }

            if (Input.GetKey(KeyCode.LeftControl) && isGrounded || Input.GetKey(KeyCode.RightControl) && isGrounded)
            {
                rig.velocity = new Vector3(Mathf.Lerp(rig.velocity.x, 0, breakTime * Time.deltaTime), Mathf.Lerp(rig.velocity.y, 0, breakTime * Time.deltaTime), Mathf.Lerp(rig.velocity.z, 0, breakTime * Time.deltaTime));
            }

        }
        isInWater = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
                rig.AddForce(Vector3.up * JumpForce);
        }
    }


    void OnTriggerStay (Collider col)
    {
        if (col.tag == "Water2")
        {
            isInWater = true;
            RiverY = col.gameObject.GetComponent<Transform>().position.y;
            RiverHeight = col.gameObject.GetComponent<Transform>().lossyScale.y;
        }
        if (col.tag == "Stone")
            SceneManager.LoadScene("LVL1");
    }

    void OnTriggerExit (Collider col)
    {
        isInWater = false;
    }

    void LateUpdate()
    {
        player.transform.position = ball.transform.position;
    }
}
