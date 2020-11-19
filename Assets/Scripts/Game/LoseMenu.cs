using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void Retry()
    {
    	SceneManager.LoadScene("SampleScene");
    }

    public void ExitMainMenu()
    {
    	SceneManager.LoadScene("MainMenu");
    }
}
