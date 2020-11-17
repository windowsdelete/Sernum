using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.CompareTag("Player") && other.GetComponent<PlayerMove>().playerHP < (other.GetComponent<PlayerMove>().maxHP-0.5f))
    	{
    		other.GetComponent<PlayerMove>().Heal();
    		this.gameObject.SetActive(false);
    	}
    }
}
