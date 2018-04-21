using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour {
float inihp =100;
Transform hp;
Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		hp = transform.GetChild(0).GetComponent<Transform>();
        // hp.localScale = new Vector3(inihp, transform.localScale.y, transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		void OnCollisionEnter (Collision other)
	{
	
		if (other.collider.tag == "Unit")
		{
			hp.localScale = new Vector3(hp.transform.localScale.x-0.75f, hp.transform.localScale.y, hp.transform.localScale.z);	
		}
		if (hp.transform.localScale.x <= 0)
		{
			
			anim.SetTrigger("deathtrigger");
			// gameObject.SetActive(false);
		}
	}
}
