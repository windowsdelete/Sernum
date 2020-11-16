using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.CompareTag("Player"))
    	{
    		other.GetComponent<PlayerMove>().Heal();
    		this.gameObject.SetActive(false);
    	}
    }
}
