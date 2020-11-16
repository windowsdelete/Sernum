using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
	// public float thrust;
	// public float knockTime;

 //    void Start()
 //    {
        
 //    }

 //    void Update()
 //    {
        
 //    }

 //    public void OnTriggerEnter2D(Collider2D other)
 //    {
 //    	if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
 //    	{
 //    		Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
 //    		if(enemy != null)
 //    		{
 //    			enemy.isKinematic = false;
 //    			Vector2 dif = enemy.transform.position - transform.position;
 //    			dif = dif.normalized * thrust;
 //    			enemy.AddForce(dif, ForceMode2D.Impulse);
 //    			StartCoroutine(KnockCour(enemy));
 //    		}
 //    	}
 //    }

 //    private IEnumerator KnockCour(Rigidbody2D enemy)
 //    {
 //    	if(enemy != null)
 //    	{
 //    		yield return new WaitForSeconds(knockTime);
 //    		enemy.velocity = Vector2.zero;
 //    		enemy.isKinematic = true;
 //    	}
 //    }

	public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("breakable"))
        {
            other.GetComponent<KuvwinController>().Killed();
        }
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
            	hit.isKinematic = false;
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                hit.isKinematic = true;
                if (other.gameObject.CompareTag("Enemy"))
                {
                    hit.GetComponent<EnemyController>().currentState = EnemyState.stagger;
                    other.GetComponent<EnemyController>().Knock(hit, knockTime);
                }
                if(other.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<PlayerMove>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerMove>().Knock(knockTime);
                }
            }
        }
    }
}
