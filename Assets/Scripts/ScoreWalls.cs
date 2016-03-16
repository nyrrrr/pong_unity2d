using UnityEngine;
using System.Collections;

public class ScoreWalls : MonoBehaviour
{

    public bool isLeftWall = true;
    Transform go;
    Vector2 vWallPosition = Vector2.zero;
    Collider2D col;

    // initialization
    void Awake()
    {
        go = this.transform;
        col = this.gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _PositionOnSideOfScreen();
    }

    private void _PositionOnSideOfScreen()
    {
        if (isLeftWall)
            vWallPosition = new Vector2(Screen.width + (col.bounds.size.x), 0);
        else
            vWallPosition = new Vector2(0 - (col.bounds.size.x), 0);
        vWallPosition.x = (Camera.main.ScreenToWorldPoint(vWallPosition)).x;
        vWallPosition.y = go.position.y;
        go.position = vWallPosition;
    }
}
