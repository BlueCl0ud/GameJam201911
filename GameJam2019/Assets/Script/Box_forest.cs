using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_forest : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        float theta = Mathf.Atan2(transform.position.y - player.position.y,
            transform.position.x - player.position.x);
        theta =theta * 360 / 6.28f;
        transform.eulerAngles = new Vector3(0, 0, theta);
        if(transform.position.x < player.position.x )
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
