using UnityEngine;
using System.Collections;

public class oppositeCar : MonoBehaviour {
	public float carSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < 0) {
			carSpeed = 1;
		} else {
			carSpeed = 2;
		}
		transform.Translate (new Vector3 (0, 1, 0) * carSpeed * Time.deltaTime);
	}
}
