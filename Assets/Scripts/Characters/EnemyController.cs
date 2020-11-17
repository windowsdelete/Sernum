using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}

public class EnemyController : MonoBehaviour
{

    public EnemyState currentState;
    //public GameObject tPlayer;
	public float hp;
    public float respawnHP;
	public string eName;
	public int bAttack;
	public float mSpeed;
    public float hX;
    public float hY;
    public int enemyClass;

    void Start()
    {
        //tPlayer = GameObject.FindWithTag("Player");
    }

    private void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            StartCoroutine(respawn());
            //this.gameObject.SetActive(false);
            this.gameObject.transform.position = new Vector3(hX, -300);
            //StartCoroutine(respawn());
            GameObject.FindWithTag("Player").GetComponent<PlayerMove>().GetEnemyGold(enemyClass);
        }
    }

    public void Knock(Rigidbody2D mRB, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(mRB, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D mRB, float knockTime)
    {
        if (mRB != null)
        {
            yield return new WaitForSeconds(knockTime);
            mRB.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            mRB.velocity = Vector2.zero;
        }
    }

    private IEnumerator respawn()
    {
        hp = respawnHP;
        yield return new WaitForSeconds(5f);
        this.gameObject.transform.position = new Vector3(hX, hY);
        //this.gameObject.SetActive(true);
    }
}
