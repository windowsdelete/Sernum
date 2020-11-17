using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
	walk,
	attack,
	interact,
    stagger,
    idle
}
public class PlayerMove : MonoBehaviour
{
	public PlayerState currentState;
	public float speed;

    public float playerHP;
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public GameObject h4;

	private Rigidbody2D mRB;
	private Vector3 schange;
	private Animator anim;

    void Start()
    {
    	anim = GetComponent<Animator>();
        mRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HPUpdate();
        schange = Vector2.zero;
        schange.x = Input.GetAxisRaw("Horizontal");
        schange.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Fire1") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        	StartCoroutine(AttackPls());
        else if(currentState == PlayerState.walk || currentState == PlayerState.idle)
        	UpdateAnimAndMove();
    }

    private IEnumerator AttackPls()
    {
    	anim.SetBool("attacking", true);
    	currentState = PlayerState.attack;
    	yield return null;
    	anim.SetBool("attacking", false);
    	yield return new WaitForSeconds(.3f);
    	currentState = PlayerState.walk;
    }

    void UpdateAnimAndMove()
    {
    	if(schange != Vector3.zero)
        { MovePlayer(); anim.SetFloat("moveX", schange.x); anim.SetFloat("moveY", schange.y); anim.SetBool("moving", true); }
        else
        { anim.SetBool("moving", false); }
    }
    
    void MovePlayer()
    {
    	mRB.MovePosition(transform.position + schange * speed * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage)
    {
        StartCoroutine(KnockCour(knockTime));
        playerHP -= damage;
    }

    private IEnumerator KnockCour(float knockTime)
    {
        if (mRB != null)
        {
            yield return new WaitForSeconds(knockTime);
            mRB.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            mRB.velocity = Vector2.zero;
        }
    }

    public void Heal()
    {
        playerHP = playerHP + 1;
    }

    void HPUpdate()
    {
        switch(playerHP)
        {
            case 0: 
                h1.SetActive(false);
                h2.SetActive(false);
                h3.SetActive(false);
                h4.SetActive(false);
                GameObject.FindWithTag("Player").SetActive(false);
                break;
            case 1:
                h1.SetActive(true);
                h2.SetActive(false);
                h3.SetActive(false);
                h4.SetActive(false);
                break;
            case 2:
                h1.SetActive(true);
                h2.SetActive(true);
                h3.SetActive(false);
                h4.SetActive(false);
                break;
            case 3:
                h1.SetActive(true);
                h2.SetActive(true);
                h3.SetActive(true);
                h4.SetActive(false);
                break;
            case 4:
                h1.SetActive(true);
                h2.SetActive(true);
                h3.SetActive(true);
                h4.SetActive(true);
                break;          
        }
    }
}
