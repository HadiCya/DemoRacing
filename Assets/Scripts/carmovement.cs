using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class carmovement : MonoBehaviour
{
    
    public carStats car;

    public Rigidbody2D rb;
    public float length;
    public float speed;
    public float accel;
    public float maxspeed;
    public float decay;
    public float displayvelocity;
    public bool active;
    public PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        //this line probably doesnt work cause its not connected online, for now im removing it for testing purposes when it needs to be online it can be readded
       // gameObject.GetComponentInChildren<TextMeshPro>().text = view.Owner.NickName;
        rb = this.transform.GetComponent<Rigidbody2D>();


        car = rb.GetComponent<carStats>();
        //speed is speed car is currently going
        //accel is how much faster car goes when gas is pressed
        speed = 0f;
        accel = car.acceleration; //0.2f
        maxspeed = car.topSpeed; //10
        decay = car.decay;//.05f
        active = true;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (view.IsMine)
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

            if (Input.GetKey("r")) //Temporary destruction testing remove later
            {
                carDestruct();
            }

            //make car go in direction and speed determined by controls this frame
            rb.velocity = transform.up * speed;
            //need to have the angular friction at like 10000 because if you dont when you bump something itll just keep spinning for almost ever

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

            //Debug.Log(car.acceleration);
        }
    }

   public void  carDestruct()
    {
        active = false;
        
        GetComponent<BoxCollider2D>().enabled = false;
       
        StartCoroutine(waiter());
        speed = 0;
        maxspeed = 0;
        
    }

   public void  carRespawn()
    {
        active = true;
        
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
        maxspeed = car.topSpeed;
    }

    void thetimerstarter()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        int count = 3;
        float time = .2f;
        while(count > 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);

            yield return new WaitForSeconds(time);

            GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);

            yield return new WaitForSeconds(time);

            count--;
        }

        carRespawn();

    }

    


}


