using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carStats : MonoBehaviour
{
[Header("Stats")]
    public float topSpeed;      //maximum Speed the car can go
    public float acceleration;  //how fast the car's speed increases
    public float health;        //how much health the car has left
    public float decay;         //how fast the car slows down

//just hidden till we need them
    [HideInInspector] public float defense;       //defense car has to protect it from bullets
    [HideInInspector] public float wheelFriction; //friction the car has with the ground, used for drifts or turning.
    [HideInInspector] public float maxAmmo;       //maximum number of bullets the car can have
    [HideInInspector] public float curAmmo;       //current numbner of bullets the car has
    
    [HideInInspector] public bool invinsible;     //set true if the car has just been respawned so it has a period where it can not be damaged or effected by another car
    [HideInInspector] public bool stalled;        // set true if the car has been stalled so that it will not keep moving
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
