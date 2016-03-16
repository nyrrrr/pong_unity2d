using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public AudioClip aHit, aScore;

    Rigidbody2D rigGo;
    Transform go;
    float fSpeed = 8f, fCollisionValue = 0f, fMaxSpeed = 14f;
    AudioSource audio;

    // init
    void Awake()
    {
        go = this.transform;
        rigGo = this.GetComponent<Rigidbody2D>();
        audio = this.GetComponent<AudioSource>();
        audio.clip = aHit;
    }

    // start setup
    void Start()
    {
        rigGo.velocity = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.25f, 0.25f)).normalized * fSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigGo.velocity.magnitude < fSpeed || rigGo.velocity.magnitude > fMaxSpeed) rigGo.velocity = new Vector2(Mathf.Lerp(rigGo.velocity.x, (rigGo.velocity.normalized * fSpeed).x, Time.deltaTime * fSpeed), Mathf.Lerp(rigGo.velocity.y, (rigGo.velocity.normalized * fSpeed).y, Time.deltaTime));
        Debug.Log("Speed: " + rigGo.velocity.magnitude);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        _PlaySound(col);
        _Bounce(col);
    }

    private void _Bounce(Collision2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Player or AI")
        {
            fCollisionValue = _GetCollisionAngle(go.position.y, col.transform.position.y, col.collider.bounds.size.y);
            rigGo.velocity = new Vector2((go.position.x > col.transform.position.x ? 1 : -1), fCollisionValue).normalized * fSpeed;
        }
    }

    private void _PlaySound(Collision2D col)
    {
        if (col.gameObject.tag != "Finish")
        {
            audio.clip = aHit;
        }
        else
        {
            audio.clip = aScore;
        }
        audio.Play();
    }

    // not calculating a real "angle"
    private float _GetCollisionAngle(float fBallY, float fPaddleY, float fPaddleSize)
    {
        return (fBallY - fPaddleY) / fPaddleSize;
    }
}
