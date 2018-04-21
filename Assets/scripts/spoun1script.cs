using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spoun1script : MonoBehaviour {

	public Transform enemyspountr;
	public float speed;

	public enum	Team {red, blue}
	public Team team;

	bool Key1Pressed;
	bool Key2Pressed;

	public float timeout;
	float t = 0;

    public Transform Warriors;

	bool[] activity = {true, true, true};

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		t -= Time.deltaTime;

		if (t > 0)
			return;

		int key1 = -1;
		int key2 = -1;

		if (Input.GetKeyDown("r"))
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);

		if (team == Team.red)
		{
			if (Input.GetButton("Team1A")) key1 = 0;
			if (Input.GetButton("Team1B")) key1 = 1;
			if (Input.GetButton("Team1C")) key1 = 2;
			if (Input.GetButton("Team1X")) key2 = 0;
			if (Input.GetButton("Team1Y")) key2 = 1;
			if (Input.GetButton("Team1Z")) key2 = 2;
			if (key1 >= 0 && key2 >= 0)
			{
				Napravlenie(key1, key2);
				t = timeout;
			}
		}
		if (team == Team.blue)
		{
			if (Input.GetButton("Team2A")) key1 = 0;
			if (Input.GetButton("Team2B")) key1 = 1;
			if (Input.GetButton("Team2C")) key1 = 2;
			if (Input.GetButton("Team2X")) key2 = 0;
			if (Input.GetButton("Team2Y")) key2 = 1;
			if (Input.GetButton("Team2Z")) key2 = 2;
			if (key1 >= 0 && key2 >= 0)
			{
				Napravlenie(key1, key2);
				t = timeout;
			}
		}
	}

	void Napravlenie (int from, int to)
		{
			if (!activity[from])
				return;

			Vector3 direction = enemyspountr.GetChild(to).position - transform.GetChild(from).position;
			direction.Normalize();
			transform.GetChild(from).gameObject.SetActive(true);
			Warriors.transform.GetChild(from).gameObject.SetActive(true);

			for (int i = 0; i < transform.GetChild(from).childCount; i++)
			{
				transform.GetChild(from).GetChild(i).GetComponent<GoAheadScript>().Go(direction,speed);
			}
			StartCoroutine(delayDisable(from));
		}	

	IEnumerator delayDisable(int index)
	{
		activity[index] = false;
		yield return new WaitForSecondsRealtime(5f);
		transform.GetChild(index).gameObject.SetActive(false);
		Warriors.transform.GetChild(index).gameObject.SetActive(false);
		activity[index] = true;
	}


}
