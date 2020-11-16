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
	public int hp;
	public string eName;
	public int bAttack;
	public float mSpeed;

    public void Knock(Rigidbody2D mRB, float knockTime)
    {
        StartCoroutine(KnockCo(mRB, knockTime));
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
