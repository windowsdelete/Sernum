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
	public float hp;
	public string eName;
	public int bAttack;
	public float mSpeed;

    private void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            this.gameObject.SetActive(false);
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
}
