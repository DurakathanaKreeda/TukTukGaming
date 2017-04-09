using UnityEngine;
using System.Collections;

public class carSpawner : MonoBehaviour {
	public GameObject[] otherCars;
	int carNo;
	public float spawnDelay = 1;
	Vector3 spawnPosition;
	Quaternion spawnRotation;
	float timer;
	// Use this for initialization
	void Start () {
		timer = spawnDelay;	
	}
	
	// Update is called once per frame
	void Update () {

		spawnPosition = new Vector3(Random.Range (-1.84f,1.84f), transform.position.y, transform.position.z);

		if (spawnPosition.x < 0) {
			spawnRotation.z = 0;
		}
		else{
			spawnRotation.z = 180;
		}

		timer -= Time.deltaTime;

		if (timer <= 0) {
			carNo = Random.Range (0, 2);
			Instantiate (otherCars[carNo], spawnPosition, spawnRotation);
			spawnDelay = 1;
			timer = spawnDelay;
		}
	}
}
