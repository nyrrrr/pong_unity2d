﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    Transform go, ball;
    Vector2 vPaddlePlayerPos = Vector2.zero;

    float fVertical = 0;
    float fSpeed = 13f;
    float fBallPaddleDistance;

    Rigidbody2D rigGo;
    Collider2D col;
    public bool isPlayerA = true;
    bool hasMoved = false;

    // init
    void Awake()
    {
        go = this.transform;
        rigGo = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<Collider2D>();
        ball = GameObject.Find("Ball").transform;
    }

    // start setup
    void Start()
    {
        go.position = new Vector2(go.position.x, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _PositionPaddleOnSideOfScreen();
        if (isPlayerA) _MoveOnInput();
        else
        {  // AI movement
            if (ball.position.x > -2f && ball.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                hasMoved = true;

                if (ball.position.y - go.position.y - col.bounds.size.y > 0)
                {
                    rigGo.velocity = Vector2.up * fSpeed;
                }
                else if (ball.position.y - go.position.y < 0)
                {
                    rigGo.velocity = Vector2.up * fSpeed * -1;
                }
            }
            else
                rigGo.velocity = Vector2.zero;
        }
    }

    private void _MoveOnInput()
    {
        fVertical = Input.GetAxisRaw("Vertical");
        if (fVertical != 0)
        {
            hasMoved = true;
            rigGo.velocity = Vector2.up * fVertical * fSpeed;
        }
        else rigGo.velocity = Vector2.zero;
    }

    private void _PositionPaddleOnSideOfScreen()
    {
        if (isPlayerA)
            vPaddlePlayerPos = new Vector2(32, 0);
        else
            vPaddlePlayerPos = new Vector2(Screen.width - 32, 0);
        vPaddlePlayerPos.x = (Camera.main.ScreenToWorldPoint(vPaddlePlayerPos)).x;
        vPaddlePlayerPos.y = (hasMoved ? go.position.y : 0);
        go.position = vPaddlePlayerPos;
    }
}
