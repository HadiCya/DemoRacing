using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private float angle;
    public float range;

    public GameObject shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PointToMouse(ref angle);
        shoot();
    }

    void PointToMouse(ref float angle)
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 gunPos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);

        float sideA = mousePos.x - gunPos.x;
        float sideB = mousePos.y - gunPos.y;

        angle = Mathf.Atan2(sideB, sideA) * Mathf.Rad2Deg;

        this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void shoot()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(shootPoint.transform.position, transform.TransformDirection(Vector3.right) * 10, Color.red);

            if (Physics.Raycast(shootPoint.transform.position, transform.TransformDirection(Vector3.right) * 10, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                Debug.Log(hitObject.name);
            }
        }
    }
}
