using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaterialSpawn : MonoBehaviour
{

    public GameObject[] SpawnPoints;
    public GameObject[] Materials;
    string[] AccentColors;
    public Text Counter;
    public Text WaveText;
    private string AccentColor;
    public Image TimeRemaining;
    public int counter;
    public int reverseCounter;
    public float VioletScore;
    public float YellowScore;
    public float CyanScore;
    private float Score;
    private float MaxScore;
    public Text ScoreText;
    private string NextColor;
    public float Wave;
    private float SpawnRate;
    private Color targetCol;
    float currentTime;
    public bool isShootAny;

    public float kgCount;
    public float atCount;
    public float saCount;


    public float violetCount;
    public float yellowCount;
    public float cyanCount;

    public float highScore;

    float t;

    public Text Text_SA;
    public Text Text_AT;

    void Start()
    {
        AccentColors = new string[] {"Yellow", "Violet", "Cyan"};
        AccentColor = AccentColors[Random.Range(0, AccentColors.Length)];
        counter = 60;
        reverseCounter = 0;
        MaxScore = 15;
        Score = 0;
        VioletScore = 0;
        YellowScore = 0;
        CyanScore = 0;
        Wave = 1;
        SpawnRate = 2.0f;
        currentTime = 0f;
        ScoreText.text = "Score: " + Score + " / " + MaxScore;
        Counter.text = counter.ToString();
        WaveText.text = "Wave " + Wave;
        InvokeRepeating("SpawnMaterial", 0, SpawnRate);
        Invoke("SpawnAcColor", counter);
        InvokeRepeating("TimeCounter", 1, 1);
        NextColor = AccentColor;

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

        isShootAny = false;
    }

    void Update()
    {
        counter = Mathf.Clamp(counter, 0, 60);
        reverseCounter = Mathf.Clamp(reverseCounter, 0, 60);
        currentTime += Time.deltaTime;

        t = (float)reverseCounter / 60;
        TimeRemaining.transform.localScale = new Vector3(Mathf.Lerp(3, 0, t), TimeRemaining.transform.localScale.y, 1);

        Text_SA.text = saCount.ToString();
        Text_AT.text = atCount.ToString();


        if (NextColor == "Yellow")
        {
            Score = YellowScore;
            targetCol = new Color32(212, 212, 37, 255);
            TimeRemaining.color = Color.yellow;
        }

        if (NextColor == "Cyan")
        {
            Score = CyanScore;
            targetCol = new Color32(37, 212, 212, 255);
            TimeRemaining.color = Color.cyan;
        }

        if (NextColor == "Violet")
        {
            Score = VioletScore;
            targetCol = new Color32(212, 37, 212, 255);
            TimeRemaining.color = Color.magenta;
        }

        if (YellowScore <= 0)
        {
            YellowScore = 0;
        }

        if (CyanScore <= 0)
        {
            CyanScore = 0;
        }

        if (VioletScore <= 0)
        {
            VioletScore = 0;
        }

        if (YellowScore >= MaxScore)
        {
            YellowScore = MaxScore;
        }

        if (CyanScore >= MaxScore)
        {
            CyanScore = MaxScore;
        }

        if (VioletScore >= MaxScore)
        {
            VioletScore = MaxScore;
        }

        ScoreText.text = "Score: " + Score + " / " + MaxScore;
        WaveText.text = "Wave " + Wave;

        if (Input.GetKeyDown(KeyCode.W)&&(!transform.gameObject.GetComponent<GameOver>().isGO))
        {
            if (atCount > 0)
            {
                counter = counter + 10;
                if (counter >= 60)
                {
                    counter = 60;
                }

                reverseCounter = reverseCounter - 10;
                if (reverseCounter <= 0)
                {
                    reverseCounter = 0;
                }
                atCount--;
                DataSave.SaveChallenge(this);
            }
        }

        if (Input.GetKeyDown(KeyCode.S)&&(!transform.gameObject.GetComponent<GameOver>().isGO))
        {
            if (saCount > 0)
            {
                isShootAny = true;
                saCount--;
                DataSave.SaveChallenge(this);
            }
        }
    }

    void SpawnMaterial()
    {
        if ((!transform.gameObject.GetComponent<GameOver>().isGO) && (!transform.gameObject.GetComponent<PauseMenu>().isPaused))
        {
            GameObject SpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            GameObject Material = Materials[Random.Range(0, Materials.Length)];

            Instantiate(Material, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }

    public void SpawnAcColor()
    {
        if (counter > 0)
        {
            Invoke("SpawnAcColor", counter);
        }

        else
        {
            if (Score < MaxScore)
            {
                transform.gameObject.GetComponent<GameOver>().isGO = true;
            }
            else
            {
                AccentColor = AccentColors[Random.Range(0, AccentColors.Length)];
                counter = 60;
                reverseCounter = 0;
                VioletScore = 0;
                YellowScore = 0;
                CyanScore = 0;
                currentTime = 0;
                NextColor = AccentColor;
                Wave = Wave + 1;
                MaxScore = MaxScore + 5;
                SpawnRate = SpawnRate - (0.2f);
                InvokeRepeating("SpawnMaterial", 0, SpawnRate);
                isShootAny = false;
                Invoke("SpawnAcColor", counter);
            }
        }
    }

    void TimeCounter()
    {
        if ((counter > 0) && (!transform.gameObject.GetComponent<GameOver>().isGO) && (!transform.gameObject.GetComponent<PauseMenu>().isPaused))
        {
            counter--;
            reverseCounter++;
            Counter.text = counter.ToString();
        }
    }
}
