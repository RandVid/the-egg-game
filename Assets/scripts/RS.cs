using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RS : MonoBehaviour
{
    public Camera camPl;
    public Camera camRS, camCS;
    public Transform terrain;
    public float speedRS, EggSpeed, MaxSpeed, minX, maxX, stoneZ, stoneY, stoneSpawnRate, minZ, maxZ, SSR;

    public GameObject kuvsh;
    public GameObject[] stones = new GameObject[4];
    private Rigidbody rig;

    public bool RSstart, RSstarted, cd;

    private void Start()
    {
        camPl.enabled = true;
        camRS.enabled = false;
        camCS.enabled = false;
        rig = GameObject.Find("Egg").GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            camPl.enabled = false;
            camRS.enabled = true;

            RSstart = true;
            rig.Sleep();
            rig.WakeUp();
        }
        if (other.gameObject.tag == "trap") Destroy(kuvsh);
        if (other.gameObject.tag == "CD") { cd = true; rig.constraints = RigidbodyConstraints.None;}
        if (other.gameObject.tag == "NextLVL") {
            camPl.enabled = false;
            camRS.enabled = false;
            camCS.enabled = true;
            FindObjectOfType<CScene>().start = true;
            camCS.transform.position = new Vector3(transform.position.x, camCS.transform.position.y, camCS.transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if (RSstart == true)
        {
            float h_rotate = Input.GetAxis("Horizontal");
            float v_rotate = Input.GetAxis("Vertical");
            terrain.transform.position = terrain.transform.position + new Vector3(0, 0, -speedRS * Time.deltaTime);
            MaxSpeed = GetComponent<Movement>().MaxSpeed;
            if (!cd)
            {
                transform.position = new Vector3(Math.Max(Math.Min(transform.position.x + h_rotate * EggSpeed * Time.deltaTime, minX), maxX),
                    transform.position.y, Math.Min(Math.Max(transform.position.z + v_rotate * EggSpeed * Time.deltaTime, minZ), maxZ));
                rig.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }
            Debug.LogWarning(rig.velocity.x + " " + rig.velocity.z);
            /*if (rig.velocity.x < MaxSpeed ^ rig.velocity.y < MaxSpeed ^ rig.velocity.z < MaxSpeed ^ rig.velocity.x < -MaxSpeed ^ rig.velocity.y < -MaxSpeed ^ rig.velocity.z < -MaxSpeed)
            {   
                rig.AddForce(Vector3.right * EggForce * h_rotate);
                rig.AddForce(Vector3.forward * EggForce * v_rotate);
            }*/
            int random = Convert.ToInt32(UnityEngine.Random.Range(0f, stoneSpawnRate));
            if (random == 0)
            {
                speedRS += 0.1f;
                stoneSpawnRate -= SSR;
                Instantiate(stones[Convert.ToInt32(UnityEngine.Random.Range(0, stones.Length))], 
                    new Vector3(UnityEngine.Random.Range(minX, maxX), stoneY, stoneZ), UnityEngine.Random.rotation);
            }
        }
    }
}
