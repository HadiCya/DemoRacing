using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed;

    public Rigidbody2D rb;

    public PhotonView view;
    
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        gameObject.GetComponentInChildren<TextMeshPro>().text = view.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine)
        {
            movement();
        }
    }

    public void movement()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(hor * moveSpeed, ver * moveSpeed);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

}
