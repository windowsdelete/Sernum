using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
	public GameObject dBox;
    public GameObject pressE;
    public GameObject devil;
    public GameObject text;
	public Text plText;
	public Text dText;
	public string dString;
	public bool dActive;
	public bool pf;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && dActive)
        {
        	if((GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerGold >= 1000) && (GameObject.FindWithTag("Player").GetComponent<PlayerMove>().lvl == 3))
        	{
        		//39.93 2.58
        		GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerGold = 0;
        		GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerHP = 6;
        		devil.transform.position = new Vector3(39.93f, 2.58f);
        		StartCoroutine(awakeDevil());
        	}
        	else
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.CompareTag("Player") && !pf)
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

    private IEnumerator awakeDevil()
    {
    	pf = true;
    	pressE.SetActive(false);
    	text.SetActive(true);
    	plText.text = "An ancient evil has awakened!";
    	yield return new WaitForSeconds(2f);
    	text.SetActive(false);
    	this.gameObject.SetActive(false);
    }
}