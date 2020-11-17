using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	private bool isPaused;
	public GameObject pause;
	public string mainMenu;
    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
        	isPaused = !isPaused;
        	if(isPaused)
        	{
        		pause.SetActive(true);
        		Time.timeScale = 0f;
        	}
        	else
        	{
        		pause.SetActive(false);
        		Time.timeScale = 1f;
        	}
        }
    }

    public void Resume()
    {
    	isPaused = !isPaused;
    	pause.SetActive(false);
    	Time.timeScale = 1f;
    }

    public void ExitMainMenu()
    {
    	isPaused = !isPaused;
    	SceneManager.LoadScene(mainMenu);
    	Time.timeScale = 1f;
    }
}
