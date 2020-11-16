using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuvwinController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void Killed()
    {
    	anim.SetBool("killed", true);
    	StartCoroutine(breakKuv());
    }

    IEnumerator breakKuv()
    {
    	yield return new WaitForSeconds(.3f);
    	this.gameObject.SetActive(false);
    }
}
