using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	public GameObject dBox;
    public GameObject pressE;
    public GameObject buyButton;

    public Text hpCur;
    public Text damageCur;
    public Text lvlCur;
 	public Text costText;
    public Text hpNew;
    public Text damageNew;
    public Text lvlNew;

	public bool dActive;
	private int cost;

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
        		switch(GameObject.FindWithTag("Player").GetComponent<PlayerMove>().lvl)
        		{
        			case 1:
        				hpCur.text = "HP: 4";
        				damageCur.text = "DMG: 1";
        				lvlCur.text = "LVL: 1";
        				hpNew.text = "5";
        				damageNew.text = "2";
        				lvlNew.text = "2";
        				costText.text = "Cost: 100";
        				cost = 100;
        				break;
        			case 2:
        				hpCur.text = "HP: 5";
        				damageCur.text = "DMG: 2";
        				lvlCur.text = "LVL: 2";
        				hpNew.text = "6";
        				damageNew.text = "3";
        				lvlNew.text = "3";
        				costText.text = "Cost: 300";
        				cost = 300;
        				break;
        			case 3:
        				hpCur.text = "HP: 6";
        				damageCur.text = "DMG: 3";
        				lvlCur.text = "LVL: 3";
        				hpNew.text = "MAX";
        				damageNew.text = "MAX";
        				lvlNew.text = "MAX";
        				costText.text = "MAX LVL";
        				buyButton.SetActive(false);
        				break;
        		}
        		dBox.SetActive(true);
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

    public void buyLevel()
    {
    	if(GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerGold >= cost)
    	{
    		    switch(cost)
        		{
        			case 100:
        				GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerGold -= 100;
        				break;
        			case 300:
        				GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerGold -= 300;
        				break;
        		}
        				GameObject.FindWithTag("Player").GetComponent<PlayerMove>().maxHP++;
        				GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerHP = GameObject.FindWithTag("Player").GetComponent<PlayerMove>().maxHP;
        				GameObject.FindWithTag("Player").GetComponent<PlayerMove>().damage += 0.5f;
        				GameObject.FindWithTag("Player").GetComponent<PlayerMove>().lvl++;
        				dBox.SetActive(false);
    	}
    	else
    	{
    		StartCoroutine(NoMoney());
    	}
    }

    private IEnumerator NoMoney()
    {
    	costText.text = "No money!";
    	yield return new WaitForSeconds(1f);
    	costText.text = "Cost: " + cost;
    }
}
