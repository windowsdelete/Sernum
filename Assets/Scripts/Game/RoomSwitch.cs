using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSwitch : MonoBehaviour
{

	public Vector2 camChange;
	public Vector3 playerChange;
	private CameraMove cam;
	public bool nText;
	public string plName;
	public GameObject text;
	public Text plText;
    private bool teleportCD;

	void Start()
	{
		cam = Camera.main.GetComponent<CameraMove>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.CompareTag("Player"))
    	{
            if(!teleportCD)
            {
    		cam.lPos += camChange;
    		cam.mPos += camChange;
    		other.transform.position += playerChange;
    		if(nText)
    		{
    			StartCoroutine(plNamePls());
    		}
        }
    	}
    }

    private IEnumerator plNamePls()
    {
    	text.SetActive(true);
    	plText.text = plName;
        teleportCD = !teleportCD;
    	yield return new WaitForSeconds(1f);
    	text.SetActive(false);
        teleportCD = !teleportCD;
    }
}
