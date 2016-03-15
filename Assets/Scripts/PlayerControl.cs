using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    Transform go;
    Vector2 vPaddlePlayerPos = Vector2.zero;
    float fVertical = 0;
    float fSpeed = 13f;
    Rigidbody2D rigGo;

    void Awake()
    {
        go = this.transform;
        rigGo = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _PositionPaddleOnLeftSideOfScreen();
        _MoveOnInput();
    }

    private void _MoveOnInput()
    {
        fVertical = Input.GetAxisRaw("Vertical");
        if (fVertical != 0)
        {
            rigGo.velocity = Vector2.up * fVertical * fSpeed;
        }
        else rigGo.velocity = Vector2.zero;
            //go.position = new Vector2(go.position.x, go.position.y + (fVertical * fSpeed));
    }

    private void _PositionPaddleOnLeftSideOfScreen()
    {
        vPaddlePlayerPos = new Vector2(32, 0);
        vPaddlePlayerPos.x = (Camera.main.ScreenToWorldPoint(vPaddlePlayerPos)).x;
        vPaddlePlayerPos.y = go.position.y;
        go.position = vPaddlePlayerPos;
    }
}
