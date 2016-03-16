using UnityEngine;
using System.Collections;

public class ScoreWalls : MonoBehaviour
{

    public bool isLeftWall = true;
    Transform go;
    Vector2 vWallPosition = Vector2.zero;

    // initialization
    void Awake()
    {
        go = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _PositionOnSideOfScreen();
    }

    private void _PositionOnSideOfScreen()
    {
        if (isLeftWall)
            vWallPosition = new Vector2(Screen.width, 0);
        else
            vWallPosition = new Vector2(0, 0);
        vWallPosition.x = (Camera.main.ScreenToWorldPoint(vWallPosition)).x;
        vWallPosition.y = go.position.y;
        go.position = vWallPosition;
    }
}
