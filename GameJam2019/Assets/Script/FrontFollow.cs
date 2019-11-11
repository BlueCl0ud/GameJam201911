using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontFollow : MonoBehaviour
{
    private Animator anim;

    public GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.position = player.transform.position;
        anim.SetFloat("HorizontalMove", player.GetComponent<Animator>().GetFloat("HorizontalMove"));
        anim.SetFloat("VerticalMove", player.GetComponent<Animator>().GetFloat("VerticalMove"));
    }
}
