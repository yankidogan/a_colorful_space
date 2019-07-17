using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ship;
    public float offsetz;
    public float offsety;
    public float positionx;
    private float positiony;

    void Start()
    {
        offsetz = (transform.position.z - ship.transform.position.z);
        offsety = (transform.position.y - ship.transform.position.y);
    }

    void Update()
    {
        positiony = ship.transform.position.y;
        positionx = ship.transform.position.x;
        transform.position = new Vector3(positionx, positiony + offsety, offsetz);
    }
}
