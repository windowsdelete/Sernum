using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignComp : MonoBehaviour
{
	public GameObject dBox;
    public GameObject pressE;
	public Text dText;
	public string dString;
	public bool dActive;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && dActive)
        {
        	if(dBox.activeInHierarchy)
        	{
        		dBox.SetActive(false);
        	}
        	else
        	{
        		dBox.SetActive(true);
        		dText.text = dString;
        	}
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.CompareTag("Player"))
    	{
    		dActive = true;
            pressE.SetActive(true);
    	}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    	if(other.CompareTag("Player"))
    	{
    		dActive = false;
    		dBox.SetActive(false);
            pressE.SetActive(false);
    	}
    }
}
