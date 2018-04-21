using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAheadScript : MonoBehaviour {

	Vector3 direction;
	float speed;

	public static float redD;
	public static float blueD;
	
	public void Go(Vector3 dir, float sp)
	{
		direction = dir;
		sp = speed;
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
			GetComponent<Rigidbody>().AddForce(Vector3.up * vel.magnitude * 0.1f, ForceMode.Impulse);

		}
	}
}
