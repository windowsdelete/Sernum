using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redDevil : EnemyController
{
    private Rigidbody2D mRB;
    public Transform target;
    public float spectateRadius;
    public float attackRadius;
    public Transform homePos;
    public Animator anim;
    private Vector3 rchange;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        mRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rchange = Vector2.zero;
        rchange.x = target.position.x;
        rchange.y = target.position.y;
        CheckDistance();
        pAnim();
    }

    void CheckDistance()
    {
    	if(Vector3.Distance(target.position, transform.position) <= spectateRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
    	{
    		Vector3 temp = Vector3.MoveTowards(transform.position, target.position, mSpeed * Time.deltaTime);
    	   
            mRB.MovePosition(temp);
        }
    }

    void pAnim()
    {
        anim.SetFloat("moveX", rchange.x); anim.SetFloat("moveY", rchange.y);
    }
}
