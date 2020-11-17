using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
	public float thrust;
    public float knockTime;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("breakable"))
        {
            other.GetComponent<KuvwinController>().Killed();
        }

        if (other.gameObject.CompareTag("heal"))
        {
            other.GetComponent<PlayerMove>().Heal();
        }

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    hit.isKinematic = false;
                    Vector2 difference = hit.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    hit.AddForce(difference, ForceMode2D.Impulse);
                    hit.isKinematic = true;
                    hit.GetComponent<EnemyController>().currentState = EnemyState.stagger;
                    other.GetComponent<EnemyController>().Knock(hit, knockTime, GameObject.FindWithTag("Player").GetComponent<PlayerMove>().damage);
                }
                if(other.gameObject.CompareTag("Player"))
                {
                    Vector2 difference = hit.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    hit.AddForce(difference, ForceMode2D.Impulse);
                    hit.GetComponent<PlayerMove>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerMove>().Knock(knockTime, damage);
                }
            }
        }
    }
}
