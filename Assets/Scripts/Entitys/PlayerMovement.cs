using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityStats
{
    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
