using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{

    public bool isTopWall = true;
    Transform go;
    Vector2 vWallPosition = Vector2.zero;

    // initialization
    void Awake()
    {
        go = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _PositionOnSideOfScreen();
    }

    private void _PositionOnSideOfScreen()
    {
        if (isTopWall)
            vWallPosition = new Vector2(0, Screen.height);
        else
            vWallPosition = new Vector2(0, 0);
        vWallPosition.y = (Camera.main.ScreenToWorldPoint(vWallPosition)).y;
        vWallPosition.x = go.position.x;
        go.position = vWallPosition;
    }
}
