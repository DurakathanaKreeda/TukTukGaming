using UnityEngine;
using System.Collections;

public class carControler : MonoBehaviour {
	public float carSpeed = 50;
	public float maxPosition = 2;
	Vector3 position;
	public uiManager ui;
	public AudioManager am;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		am.carSound.Play ();
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime;
		position = transform.position;
		position.x = Mathf.Clamp (position.x, -maxPosition, maxPosition);
		transform.position = position;
	}

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "otherCar") {
			Destroy (gameObject);
			ui.GameOver ();
			am.carSound.Stop ();
		}
	}

	public void SteerLeft(){
		rb.velocity = new Vector2 (-carSpeed, 0);
	}

	public void SteerRight(){
		rb.velocity = new Vector2 (carSpeed, 0);
	}

	public void SetNoSteer(){
		rb.velocity = Vector2.zero;
	}
}
