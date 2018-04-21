using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAheadScript : MonoBehaviour {

	Vector3 direction;
	float speed = 0;

	public static float redD;
	public static float blueD;

	Vector3 iniPos;
	
	void Awake ()
	{
		iniPos = transform.position;
	}

	public void Go(Vector3 dir, float sp)
	{
		GetComponent<Collider>().enabled = true;
		transform.position = iniPos;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		direction = dir;
		speed = sp;
	}

	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody>().AddForce(direction.normalized * speed, ForceMode.VelocityChange);
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.collider.tag == "Unit")
		{
			speed = 0;
			
			Vector3 vel = GetComponent<Rigidbody>().velocity;
			GetComponent<Rigidbody>().AddForce(Vector3.up * vel.magnitude * 0.5f, ForceMode.Impulse);
			StartCoroutine(disableCollider());
		}

	

	}

	IEnumerator disableCollider ()
	{
		yield return new WaitForSecondsRealtime(1);
		GetComponent<Collider>().enabled = false;
	}
}
