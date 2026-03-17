using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;





public class PlayerControl : MonoBehaviour
{
    
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpforce = 680.0f;
    float walkforce = 30.0f;
    float maxwalkspeed = 2.0f;
    float threshold = 0.2f;
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame ==true && this.rigid2D.linearVelocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
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


        if (speedx < this.threshold)
        {
            // 停止時將動畫重置回第 0 幀（原始姿勢）
            this.animator.Play(this.animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0f);
            this.animator.speed = 0;
        }
        else
        {
            if(this.rigid2D.linearVelocity.y == 0)
            {
                this.animator.speed = speedx / 2.0f; // 根據速度調整動畫播放速度
            }
            else
            {
                this.animator.speed = 1.0f; // 跳躍時保持正常動畫速度
            }
        }


        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("終點");
            SceneManager.LoadScene("ClearScene");
        }
}