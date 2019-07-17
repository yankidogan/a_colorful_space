using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public Text violetCount;
    public Text yellowCount;
    public Text cyanCount;

    public Text kg_count;
    public Text kg_violet;
    public Text kg_yellow;
    public Text kg_cyan;

    public Text at_count;
    public Text at_violet;
    public Text at_yellow;
    public Text at_cyan;

    public Text sa_count;
    public Text sa_violet;
    public Text sa_yellow;
    public Text sa_cyan;

    public float violet_count;
    public float yellow_count;
    public float cyan_count;

    float kg_violetCost;
    float kg_yellowCost;
    float kg_cyanCost;

    float at_violetCost;
    float at_yellowCost;
    float at_cyanCost;

    float sa_violetCost;
    float sa_yellowCost;
    float sa_cyanCost;

    public Button keepGoing;
    public Button addTime;
    public Button shootAny;

    public Button mainMenu;

    public float kgCount;
    public float atCount;
    public float saCount;

    public float highScore;

    void Start()
    {
        DataStore data = DataSave.LoadData();

        if (data == null)
        {
            kgCount = 0;
            atCount = 0;
            saCount = 0;

            violet_count = 0;
            yellow_count = 0;
            cyan_count = 0;

            highScore = 0;
        }

        else
        {
            kgCount = data.kgCount;
            atCount = data.atCount;
            saCount = data.saCount;

            violet_count = data.violetCount;
            yellow_count = data.yellowCount;
            cyan_count = data.cyanCount;

            highScore = data.highScore;

        }

        kg_violetCost = 1;
        kg_yellowCost = 2;
        kg_cyanCost = 1;

        at_violetCost = 2;
        at_yellowCost = 1;
        at_cyanCost = 1;

        sa_violetCost = 1;
        sa_yellowCost = 1;
        sa_cyanCost = 2;

        violetCount.text = violet_count.ToString();
        yellowCount.text = yellow_count.ToString();
        cyanCount.text = cyan_count.ToString();

        kg_count.text = kgCount.ToString();
        kg_violet.text = kg_violetCost.ToString();
        kg_yellow.text = kg_yellowCost.ToString();
        kg_cyan.text = kg_cyanCost.ToString();

        at_count.text = atCount.ToString();
        at_violet.text = at_violetCost.ToString();
        at_yellow.text = at_yellowCost.ToString();
        at_cyan.text = at_cyanCost.ToString();

        sa_count.text = saCount.ToString();
        sa_violet.text = sa_violetCost.ToString();
        sa_yellow.text = sa_yellowCost.ToString();
        sa_cyan.text = sa_cyanCost.ToString();

        keepGoing.onClick.AddListener(KeepGoing);
        addTime.onClick.AddListener(AddTime);
        shootAny.onClick.AddListener(ShootAny);
        mainMenu.onClick.AddListener(MainMenu);

    }

    void AddTime()
    {
        if (isEnough(at_yellowCost, at_violetCost, at_cyanCost))
        {
            atCount++;
            at_count.text = atCount.ToString();
            Transaction(at_yellowCost, at_violetCost, at_cyanCost);
            DataSave.SaveShop(this);
        }
    }

    void KeepGoing()
    {
        if (isEnough(kg_yellowCost, kg_violetCost, kg_cyanCost))
        {
            kgCount++;
            kg_count.text = kgCount.ToString();
            Transaction(kg_yellowCost, kg_violetCost, kg_cyanCost);
            DataSave.SaveShop(this);
        }

    }

    void ShootAny()
    {
        if (isEnough(sa_yellowCost, sa_violetCost, sa_cyanCost))
        {
            saCount++;
            sa_count.text = saCount.ToString();
            Transaction(sa_yellowCost, sa_violetCost, sa_cyanCost);
            DataSave.SaveShop(this);
        }
    }

    void Transaction(float yellow, float violet, float cyan)
    {
        yellow_count = yellow_count - yellow;
        violet_count = violet_count - violet;
        cyan_count = cyan_count - cyan;

        violetCount.text = violet_count.ToString();
        yellowCount.text = yellow_count.ToString();
        cyanCount.text = cyan_count.ToString();
    }

    bool isEnough(float yellow, float violet, float cyan)
    {
        if ((yellow_count >= yellow) && (violet_count >= violet) && (cyan_count >= cyan))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }




}
