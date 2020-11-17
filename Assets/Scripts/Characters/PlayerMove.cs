using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public int playerGold;
	public int lvl;
	public Text goldText;

    public float playerHP;
    public float maxHP;
    public float damage;
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public GameObject h4;
    public GameObject h5;
    public GameObject h6;

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
        goldText.text = playerGold.ToString();
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
        playerHP++;
        playerGold++;
    }

    public void GetEnemyGold(int num)
    {
    	switch(num)
    	{
    	case 1:
    		playerGold += 10;
    		break;
    	case 2:
    		playerGold += 20;
    		break;
    	case 3:
    		playerGold += 30;
    		break;
    	}
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
                h5.SetActive(false);
                h6.SetActive(false);
                GameObject.FindWithTag("Player").SetActive(false); //refactor
                break;
            case 1:
                h1.SetActive(true);
                h2.SetActive(false);
                h3.SetActive(false);
                h4.SetActive(false);
                h5.SetActive(false);
                h6.SetActive(false);
                break;
            case 2:
                h1.SetActive(true);
                h2.SetActive(true);
                h3.SetActive(false);
                h4.SetActive(false);
                h5.SetActive(false);
                h6.SetActive(false);
                break;
            case 3:
                h1.SetActive(true);
                h2.SetActive(true);
                h3.SetActive(true);
                h4.SetActive(false);
                h5.SetActive(false);
                h6.SetActive(false);
                break;
            case 4:
                h1.SetActive(true);
                h2.SetActive(true);
                h3.SetActive(true);
                h4.SetActive(true);
                h5.SetActive(false);
                h6.SetActive(false);
                break;
            case 5:
                h1.SetActive(true);
                h2.SetActive(true);
                h3.SetActive(true);
                h4.SetActive(true);
                h5.SetActive(true);
                h6.SetActive(false);
                break;
            case 6:
                h1.SetActive(true);
                h2.SetActive(true);
                h3.SetActive(true);
                h4.SetActive(true);
                h5.SetActive(true);
                h6.SetActive(true);
                break;          
        }
    }
}
