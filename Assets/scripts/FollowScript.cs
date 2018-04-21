using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

	Transform leader;

	void Awake ()
	{
		if (transform.parent.parent.name == "WarriorsRed")
		{
			leader = GameObject.Find("TeamRed").transform.GetChild(transform.parent.GetSiblingIndex()).transform.GetChild(transform.GetSiblingIndex());
			print(leader.position.x + " " + leader.position.y + " " + leader.position.z);
		}
		if (transform.parent.parent.name == "WarriorsBlue")
		{
			leader = GameObject.Find("TeamBlue").transform.GetChild(transform.parent.GetSiblingIndex()).transform.GetChild(transform.GetSiblingIndex());
			print(leader.position.x + " " + leader.position.y + " " + leader.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = leader.position + Vector3.up * 3.5f;
	}
}
