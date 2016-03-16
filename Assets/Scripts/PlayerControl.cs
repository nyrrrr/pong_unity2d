using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    Transform go;
    Vector2 vPaddlePlayerPos = Vector2.zero;
    float fVertical = 0;
    float fSpeed = 13f;
    Rigidbody2D rigGo;
    public bool isPlayerA = true;
    bool hasMoved = false;

    // init
    void Awake()
    {
        go = this.transform;
        rigGo = this.GetComponent<Rigidbody2D>();
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
