using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{

    private Rigidbody rb;
    private float movementSpeed;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public Material[] BulMaterial;
    public Material[] ShipMaterial;
    public GameObject ship;
    public GameObject gameMaster;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        movementSpeed = 10;
        bulletPrefab.gameObject.GetComponent<BulletScript>().BulletType = "Red";

    }

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * 20 * Time.deltaTime, movementSpeed * Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * 3000);

            Destroy(bullet, 1.0f);
        }

        float rotateZ = ship.transform.eulerAngles.y;
        float horizontal = Input.GetAxis("Horizontal") * 10 * Time.deltaTime * 5;
        if (rotateZ > 180)
        {
            rotateZ = rotateZ - 360;
        }

        if (((horizontal < 0) && (rotateZ <= 45)) || ((horizontal > 0) && (rotateZ >= -45)))
        {
            ship.transform.Rotate(0, 0, -horizontal * 2, Space.Self);
        }

        if (horizontal == 0)
        {
            Quaternion target = Quaternion.Euler(ship.transform.eulerAngles.x, 0, ship.transform.eulerAngles.z);
            ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation, target, Time.deltaTime * 2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bulletPrefab.gameObject.GetComponent<BulletScript>().BulletType = "Red";
            bulletPrefab.transform.GetComponent<Renderer>().material = BulMaterial[0];
            ship.transform.GetComponent<Renderer>().material = ShipMaterial[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bulletPrefab.gameObject.GetComponent<BulletScript>().BulletType = "Blue";
            bulletPrefab.transform.GetComponent<Renderer>().material = BulMaterial[1];
            ship.transform.GetComponent<Renderer>().material = ShipMaterial[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bulletPrefab.gameObject.GetComponent<BulletScript>().BulletType = "Green";
            bulletPrefab.transform.GetComponent<Renderer>().material = BulMaterial[2];
            ship.transform.GetComponent<Renderer>().material = ShipMaterial[2];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Color")
        {
            gameMaster.gameObject.GetComponent<GameOver>().isGO = true;
            Destroy(collision.gameObject);
        }
    }
}
