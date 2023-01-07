using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GunScript : MonoBehaviour
{
    private float angle;
    public float range;

    public GameObject shootPoint;

    public PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine){
            PointToMouse();
            shoot();
        }
    }

    void PointToMouse()
    {
        Vector2 mousePos = Input.mousePosition; //Gets mouse position
        Vector3 gunPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);

        float sideA = mousePos.x - gunPos.x; //One leg of triangle between gun and mouse
        float sideB = mousePos.y - gunPos.y; //One leg of triangle between gun and mouse

        angle = Mathf.Atan2(sideB, sideA) * Mathf.Rad2Deg; //Gets angle between two points

        this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle); //Sets rotation to the angle
    }

    void shoot()
    {
        RaycastHit hit; //The raycast collision

        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(shootPoint.transform.position, transform.TransformDirection(Vector3.right) * 10, Color.red); //Draws a ray to visualize raycast

            if (Physics.Raycast(shootPoint.transform.position, transform.TransformDirection(Vector3.right) * 10, out hit)) //Detects if raycast hit an object and if so stores the object in hit
            {
                GameObject hitObject = hit.transform.gameObject; //Stores hit object in variable

                Debug.Log(hitObject.name);
            }
        }
    }
}
