using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmovement : MonoBehaviour
{
    
    carStats car = new carStats();

    public Rigidbody2D rb;
    public float length;
    public float speed;
    public float accel;
    public float maxspeed;
    public float decay;
    public float displayvelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody2D>();

        //speed is speed car is currently going
        //accel is how much faster car goes when gas is pressed
        speed = 0f;
        accel = car.acceleration; //0.2f
        maxspeed = car.topSpeed; //10
        decay = .05f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed < maxspeed)
        {


            //press gas (increase speed)
            if (Input.GetKey("w"))
            {
                speed = speed + accel;

            }
        }
        else
        {
            speed = maxspeed;
        }


        if (speed > -maxspeed)
        {
            //slow down (reverse)
            if (Input.GetKey("s"))
            {
                speed = speed - accel;
            }
        }
        else
        {
            speed = -maxspeed;
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

        if (!Input.GetKey("w") && !Input.GetKey("s"))
        {
            if (speed > 0)
            {
                speed = speed - decay;
                if (speed < 0)
                    speed = 0;
            }
            else if (speed < 0)
            {
                speed = speed + decay;
                if (speed > 0)
                    speed = 0;
            }

        }


        displayvelocity = rb.velocity.magnitude;
        //this clamps the movement correctly however the float speed itself also needs to be clamped
        //rb.velocity = Vector2.ClampMagnitude(transform.up * speed, 15); 

        Debug.Log(speed);
    }
}


