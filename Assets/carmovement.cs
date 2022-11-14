using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float length;
    float speed;
    float accel;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody2D>();

        //speed is speed car is currently going
        //accel is how much faster car goes when gas is pressed
        speed = 0f;
        accel = 0.2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //press gas (increase speed)
        if (Input.GetKey("w"))
        {
            speed = speed + accel;

        }

        //slow down (reverse)
        if (Input.GetKey("s"))
        {
            speed = speed - accel;
        }

        //turn car left
        if (Input.GetKey("a"))
        {
            rb.rotation += 3f;
        }

        if (Input.GetKey("d"))
        {
            rb.rotation -= 3f;
        }

        //make car go in direction and speed determined by controls this frame
        rb.velocity = transform.up * speed;

        //this clamps the movement correctly however the float speed itself also needs to be clamped
        //rb.velocity = Vector2.ClampMagnitude(transform.up * speed, 15); 
        
        Debug.Log(speed);
    }
}


