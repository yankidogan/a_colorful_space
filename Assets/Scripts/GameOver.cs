using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public Canvas GOCanvas;
    public bool isGO;
    public Button startOver;
    public Button keepGoing;
    public Button mainMenu;
    public GameObject ship;

    public float kgCount;
    public float atCount;
    public float saCount;


    public float violetCount;
    public float yellowCount;
    public float cyanCount;

    public float highScore;

    public Text highScoreValue;
    public Text currentScoreValue;
    public Text description;
    public Text description_pause;

    void Start()
    {
        isGO = false;
        GOCanvas.gameObject.SetActive(isGO);

        startOver.onClick.AddListener(StartOver);
        keepGoing.onClick.AddListener(KeepGoing);
        mainMenu.onClick.AddListener(MainMenu);

        DataStore data = DataSave.LoadData();
        if (data == null)
        {
            cyanCount = 0;
            yellowCount = 0;
            violetCount = 0;

            kgCount = 0;
            atCount = 0;
            saCount = 0;

            highScore = 0;
        }

        else
        {
            cyanCount = data.cyanCount;
            yellowCount = data.yellowCount;
            violetCount = data.violetCount;

            kgCount = data.kgCount;
            atCount = data.atCount;
            saCount = data.saCount;

            highScore = data.highScore;
        }

        description.text = "";
        description_pause.text = "";
    }

    void Update()
    {
        GOCanvas.gameObject.SetActive(isGO);
        ship.transform.gameObject.SetActive(!isGO);
        if (isGO)
        {
            CheckHighcore();
        }

    }

    void StartOver()
    {
        SceneManager.LoadScene("Challenge");
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void KeepGoing()
    {
        if (kgCount > 0)
        {
            isGO = false;
            transform.gameObject.GetComponent<MaterialSpawn>().counter = transform.gameObject.GetComponent<MaterialSpawn>().counter + 20;
            transform.gameObject.GetComponent<MaterialSpawn>().reverseCounter = transform.gameObject.GetComponent<MaterialSpawn>().reverseCounter - 20;
            transform.gameObject.GetComponent<MaterialSpawn>().SpawnAcColor();
            kgCount--;
            DataSave.SaveGO(this);
        }

    }

    void CheckHighcore()
    {
        float currentScore = transform.gameObject.GetComponent<MaterialSpawn>().Wave;
        currentScoreValue.text = currentScore.ToString();

        if (currentScore > highScore)
        {
            highScore = currentScore;
            DataSave.SaveGO(this);
        }
        highScoreValue.text = "HIGHSCORE: " + highScore.ToString();
    }

    public void DescStartOver()
    {
        description.text = "START OVER";
        description_pause.text = "START OVER";
    }

    public void DescQuit()
    {
        description.text = "QUIT THE MAIN MENU";
        description_pause.text = "QUIT THE MAIN MENU";
    }

    public void DescKG()
    {
        description.text = "KEEP GOING" + "\n" + "(" + kgCount + " LEFT)";
    }

    public void DescKG_Pause()
    {
        description_pause.text = "KEEP GOING";
    }

    public void DescClear()
    {
        description.text = "";
        description_pause.text = "";
    }
}
