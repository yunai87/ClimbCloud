using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.InputSystem;
using System.Reflection;




public class PlayerControl : MonoBehaviour
{
    
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpforce = 680.0f;
    float walkforce = 30.0f;
    float maxwalkspeed = 2.0f;
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            this.rigid2D.AddForce(transform.up * this.jumpforce);
        }

        int key = 0;
        if (Keyboard.current.aKey.isPressed) key = -1;
        if (Keyboard.current.dKey.isPressed) key = 1;

        float speedx = Mathf.Abs(this.rigid2D.linearVelocity.x);

        if (speedx < this.maxwalkspeed)
        {
            this.rigid2D.AddForce(transform.right * this.walkforce * key);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        this.animator.speed = speedx / 2.0f;
    }
}