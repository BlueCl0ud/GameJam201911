using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Animator playerFrontAnim;

    public GameObject playerFront;

    public float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerFrontAnim = playerFront.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Movement();
        SwichAnim();
    }

    //角色移动
    void Movement()
    {
        float verMov = Input.GetAxisRaw("Vertical");
        float horMov = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Time.fixedDeltaTime * horMov * speed, Time.fixedDeltaTime * verMov * speed);

    }

    //切换动画
    void SwichAnim()
    {
        anim.SetFloat("HorizontalMove", Math.Abs(Input.GetAxisRaw("Horizontal")));
        anim.SetFloat("VerticalMove", Input.GetAxisRaw("Vertical"));
        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        playerFrontAnim.SetFloat("HorizontalMove", anim.GetFloat("HorizontalMove"));
        playerFrontAnim.SetFloat("VerticalMove", anim.GetFloat("VerticalMove"));
        playerFrontAnim.SetBool("Push", anim.GetBool("Push"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("Push", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Push", false);
    }
}
