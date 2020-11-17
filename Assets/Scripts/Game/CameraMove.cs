using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public Transform target;
	public float smoof;
	public Vector2 mPos;
	public Vector2 lPos;

    void LateUpdate()
    {
        if(transform.position != target.position)
        {
        	Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        	targetPos.x = Mathf.Clamp(targetPos.x, lPos.x, mPos.x);
        	targetPos.y = Mathf.Clamp(targetPos.y, lPos.y, mPos.y);
        	transform.position = Vector3.Lerp(transform.position, targetPos, smoof);

        }
    }
}
