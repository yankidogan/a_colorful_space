using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipMovement_D : MonoBehaviour
{
    private float movementSpeed;
    public GameObject ShipMesh;
    public Material[] ShipMaterial;
    string currentColor;
    public float cyanCounter;
    public float yellowCounter;
    public float violetCounter;

    public float kgCount;
    public float atCount;
    public float saCount;

    public Text cyanText;
    public Text yellowText;
    public Text violetText;

    public float highScore;

    void Start()
    {
        movementSpeed = 10;
        currentColor = "red";

        DataStore data = DataSave.LoadData();

        if (data == null)
        {
            cyanCounter = 0;
            yellowCounter = 0;
            violetCounter = 0;

            kgCount = 0;
            atCount = 0;
            saCount = 0;

            highScore = 0;
        }

        else
        {
            cyanCounter = data.cyanCount;
            yellowCounter = data.yellowCount;
            violetCounter = data.violetCount;

            kgCount = data.kgCount;
            atCount = data.atCount;
            saCount = data.saCount;

            highScore = data.highScore;
        }
    }

    void Update()
    {
        transform.Translate(0, 0, movementSpeed * Time.deltaTime);
        cyanText.text = cyanCounter.ToString();
        yellowText.text = yellowCounter.ToString();
        violetText.text = violetCounter.ToString();

        float rotateZ = ShipMesh.transform.localEulerAngles.z;
        float rotateX = transform.eulerAngles.x;
        if (rotateZ > 180)
        {
            rotateZ = rotateZ - 360;
        }
        if (rotateX > 180)
        {
            rotateX = rotateX - 360;
        }

        float horizontal = Input.GetAxis("Horizontal") * 10 * Time.deltaTime * 2;
        float vertical = Input.GetAxis("Vertical") * 10 * Time.deltaTime * 2;
        transform.Rotate(vertical, horizontal, 0);

        if (((horizontal < 0) && (rotateZ <= 45)) || ((horizontal > 0) && (rotateZ >= -45)))
        {
            ShipMesh.transform.Rotate(0, 0, -horizontal * 2, Space.Self);
        }


        if (horizontal == 0)
        {
            Quaternion target = Quaternion.Euler(ShipMesh.transform.localEulerAngles.x, ShipMesh.transform.localEulerAngles.y, 0);
            ShipMesh.transform.localRotation = Quaternion.Lerp(ShipMesh.transform.localRotation, target, Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShipMesh.transform.GetComponent<Renderer>().material = ShipMaterial[0];
            currentColor = "red";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShipMesh.transform.GetComponent<Renderer>().material = ShipMaterial[1];
            currentColor = "blue";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShipMesh.transform.GetComponent<Renderer>().material = ShipMaterial[2];
            currentColor = "green";
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if (tag.Equals("sphere_g"))
        {
            if (currentColor.Equals("red"))
            {
                yellowCounter++;
            }

            if (currentColor.Equals("blue"))
            {
                cyanCounter++;
            }
        }

        if (tag.Equals("sphere_r"))
        {
            if (currentColor.Equals("green"))
            {
                yellowCounter++;
            }

            if (currentColor.Equals("blue"))
            {
                violetCounter++;
            }
        }

        if (tag.Equals("sphere_b"))
        {
            if (currentColor.Equals("green"))
            {
                cyanCounter++;
            }

            if (currentColor.Equals("red"))
            {
                violetCounter++;
            }
        }
        Destroy(other.gameObject);
    }

    void MainMenu()
    {
        DataSave.SaveDiscovery(this);
        SceneManager.LoadScene("MainMenu");
    }
}
