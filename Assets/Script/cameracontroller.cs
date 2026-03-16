using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerpos = this.player.transform.position;
        transform.position = new Vector3(transform.position.x, playerpos.y, transform.position.z);
    }
}
