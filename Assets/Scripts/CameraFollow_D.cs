using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_D : MonoBehaviour
{
    public GameObject Ship;
    public GameObject PosRight;
    public GameObject PosLeft;
    public GameObject PosUp;
    public GameObject PosDown;
    public GameObject Pos;

    void Update()
    {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, PosRight.transform.localRotation, Time.deltaTime / 4);
            transform.position = Vector3.Lerp(transform.position, PosRight.transform.position, Time.deltaTime / 4);

        }

        if (horizontal > 0)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, PosLeft.transform.localRotation, Time.deltaTime / 4);
            transform.position = Vector3.Lerp(transform.position, PosLeft.transform.position, Time.deltaTime / 4);
        }

        if ((horizontal == 0) && (vertical == 0))
        {
            transform.position = Vector3.Lerp(transform.position, Pos.transform.position, Time.deltaTime);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Pos.transform.localRotation, Time.deltaTime);
        }

        if (vertical > 0)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, PosUp.transform.localRotation, Time.deltaTime / 4);
            transform.position = Vector3.Lerp(transform.position, PosUp.transform.position, Time.deltaTime / 4);
        }

        if (vertical < 0)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, PosDown.transform.localRotation, Time.deltaTime / 4);
            transform.position = Vector3.Lerp(transform.position, PosDown.transform.position, Time.deltaTime / 4);
        }


    }
}
