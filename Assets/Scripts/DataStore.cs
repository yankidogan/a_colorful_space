using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataStore
{

    public float kgCount;
    public float atCount;
    public float saCount;


    public float violetCount;
    public float yellowCount;
    public float cyanCount;

    public float highScore;

    public DataStore(ShopScript shop)
    {
        kgCount = shop.kgCount;
        atCount = shop.atCount;
        saCount = shop.saCount;

        violetCount = shop.violet_count;
        yellowCount = shop.yellow_count;
        cyanCount = shop.cyan_count;

        highScore = shop.highScore;
    }

    public DataStore(ShipMovement_D discovery)
    {
        kgCount = discovery.kgCount;
        atCount = discovery.atCount;
        saCount = discovery.saCount;

        violetCount = discovery.violetCounter;
        yellowCount = discovery.yellowCounter;
        cyanCount = discovery.cyanCounter;

        highScore = discovery.highScore;
    }

    public DataStore(MaterialSpawn challenge)
    {
        kgCount = challenge.kgCount;
        atCount = challenge.atCount;
        saCount = challenge.saCount;

        violetCount = challenge.violetCount;
        yellowCount = challenge.yellowCount;
        cyanCount = challenge.cyanCount;

        highScore = challenge.highScore;
    }

    public DataStore(GameOver go)
    {
        kgCount = go.kgCount;
        atCount = go.atCount;
        saCount = go.saCount;

        violetCount = go.violetCount;
        yellowCount = go.yellowCount;
        cyanCount = go.cyanCount;

        highScore = go.highScore;

    }

}
