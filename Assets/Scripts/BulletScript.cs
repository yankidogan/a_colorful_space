using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{

    public string BulletType;
    private float Score;
    private float MaxScore;
    public Text ScoreText;
    public string NextColor;
    public GameObject gameMaster;
    private float VioletScore;
    private float YellowScore;
    private float CyanScore;
    public GameObject hitParticle;

    private void OnCollisionEnter(Collision collision)
    {
        var main = hitParticle.GetComponent<ParticleSystem>().main;
        if (collision.gameObject.tag == "Color" || collision.gameObject.tag == "AColor")
        {
            if (gameMaster.gameObject.GetComponent<MaterialSpawn>().isShootAny)
            {
                gameMaster.gameObject.GetComponent<MaterialSpawn>().YellowScore++;
                gameMaster.gameObject.GetComponent<MaterialSpawn>().VioletScore++;
                gameMaster.gameObject.GetComponent<MaterialSpawn>().CyanScore++;
                if (collision.gameObject.name == "Red(Clone)")
                {
                    main.startColor = Color.red;
                }
                if (collision.gameObject.name == "Green(Clone)")
                {

                    main.startColor = Color.green;
                }
                if (collision.gameObject.name == "Blue(Clone)")
                {
                    main.startColor = Color.blue;
                }
            }

            else
            {
                if (collision.gameObject.name == "Red(Clone)")
                {
                    main.startColor = Color.red;
                    if (BulletType == "Green")
                    {
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().YellowScore++;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().VioletScore--;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().CyanScore--;
                    }
                    if (BulletType == "Blue")
                    {
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().VioletScore++;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().YellowScore--;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().CyanScore--;
                    }

                }

                if (collision.gameObject.name == "Green(Clone)")
                {

                    main.startColor = Color.green;
                    if (BulletType == "Red")
                    {
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().YellowScore++;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().VioletScore--;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().CyanScore--;
                    }
                    if (BulletType == "Blue")
                    {
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().CyanScore++;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().VioletScore--;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().YellowScore--;
                    }
                }

                if (collision.gameObject.name == "Blue(Clone)")
                {
                    main.startColor = Color.blue;
                    if (BulletType == "Green")
                    {
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().CyanScore++;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().VioletScore--;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().YellowScore--;
                    }
                    if (BulletType == "Red")
                    {
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().VioletScore++;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().YellowScore--;
                        gameMaster.gameObject.GetComponent<MaterialSpawn>().CyanScore--;
                    }
                }
            }

            Instantiate(hitParticle, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(transform.gameObject);
        }

    }
}
