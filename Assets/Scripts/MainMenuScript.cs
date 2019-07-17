using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void ChallengeButton()
    {
        SceneManager.LoadScene("Challenge");
    }

    public void DiscoveryButton()
    {
        SceneManager.LoadScene("Discovery");
    }

    public void ShopButton()
    {
        SceneManager.LoadScene("Shop");
    }

    public void HTPButton()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
