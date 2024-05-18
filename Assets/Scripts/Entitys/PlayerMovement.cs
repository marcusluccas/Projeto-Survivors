using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRB;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = this.gameObject.GetComponent<EntityStats>().speed;
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        myRB.velocity = new Vector2(horizontal, vertical).normalized * speed;
    }
}
