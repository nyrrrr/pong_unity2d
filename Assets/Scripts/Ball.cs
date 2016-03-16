using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    Rigidbody2D rigGo;
    Transform go;
    float fSpeed = 8f;

    // init
    void Awake()
    {
        go = this.transform;
        rigGo = this.GetComponent<Rigidbody2D>();
    }

    // start setup
    void Start()
    {
        
        rigGo.velocity = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.25f, 0.25f)).normalized * fSpeed;
        //transform.Translate(Vector3(randomX, randomY, 0) * moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (rigGo.velocity.magnitude < fSpeed) rigGo.velocity = rigGo.velocity.normalized * fSpeed;
    }

    void OnCollisionEnter2D(Collision2D col) {

    }
}
