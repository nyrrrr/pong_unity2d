using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    Transform go;
    Vector2 paddlePlayerPos;
    float vertical = 0;
    float speed = 0.2f;

    void Awake()
    {
        go = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _PositionPaddleOnLeftSideOfScreen();
        _MoveOnInput();
    }

    private void _MoveOnInput()
    {
        vertical = Input.GetAxisRaw("Vertical");
        if (vertical != 0)
            go.position = new Vector2(go.position.x, go.position.y + (vertical * speed));
    }

    private void _PositionPaddleOnLeftSideOfScreen()
    {
        paddlePlayerPos = new Vector2(32, 0);
        paddlePlayerPos.x = (Camera.main.ScreenToWorldPoint(paddlePlayerPos)).x;
        paddlePlayerPos.y = go.position.y;
        go.position = paddlePlayerPos;
    }
}
