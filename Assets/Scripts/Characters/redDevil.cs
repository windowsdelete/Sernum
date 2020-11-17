using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redDevil : EnemyController
{
    private Rigidbody2D mRB;
    public Transform target;
    public float spectateRadius;
    public float attackRadius;
    private Animator anim;
    private Vector3 rchange;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        mRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        CheckDistance();
        //this.gameObject.transform.position = new Vector3(hX, hY);
    }

    void CheckDistance()
    {
    	if(Vector3.Distance(target.position, transform.position) <= spectateRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
    	{
    		Vector3 temp = Vector3.MoveTowards(transform.position, target.position, mSpeed * Time.deltaTime);
    	   	changeAnim(temp - transform.position);
            mRB.MovePosition(temp);
        }
    }

    private void SetAnimFloat(Vector2 setVector){
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 direction){
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0){
                SetAnimFloat(Vector2.right);
            }else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

}
