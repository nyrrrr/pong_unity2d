using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    Transform go;
    Vector2 paddlePlayerPos;

    void Awake()
    {
        go = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _PositionPaddleOnLeftSideOfScreen();
    }

    private void _PositionPaddleOnLeftSideOfScreen()
    {
        paddlePlayerPos = new Vector2(32, 0);
        paddlePlayerPos.x = (Camera.main.ScreenToWorldPoint(paddlePlayerPos)).x;
        transform.position = paddlePlayerPos;
    }
}
