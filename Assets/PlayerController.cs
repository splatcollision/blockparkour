using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;


	// jump vars
	private float jump;
	private bool jumpState = false;
	private float jumpTime;

	// mouselook vars

	private Vector3 mousePosLast;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezeRotationZ;
		jump = 0.0f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		float mh = Input.GetAxis ("Horizontal");
		float mv = Input.GetAxis ("Vertical");

		Vector3 mousePos = Input.mousePosition; // actually a vec 3 interestingly

		Vector3 lookVec = mousePos - mousePosLast;

//		Debug.Log(lookVec.x); // left-right 
//		lookVec.y // up-down
		Vector3 lookTransform = new Vector3(transform.rotation.x - lookVec.x, transform.rotation.y - lookVec.y, 0.0f);

		Quaternion deltaRotation = Quaternion.Euler(lookTransform * Time.deltaTime);

		//		Debug.Log(deltaRotation);
		rb.MoveRotation (deltaRotation);

		if (Input.GetKeyDown (KeyCode.Space)) {
			jumpState = true;
			jumpTime = Time.time;
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			jumpState = false;
		}

		if (jumpState) {
			if ((Time.time - jumpTime) > 0.6) {
				jumpState = false;
			} else {
				jump += speed * Time.deltaTime;
			}

		} else {
			jump -= speed * Time.deltaTime;
			if (jump < 0) {
				jump = 0;
			}
		}

		Vector3 move = new Vector3 (mh, jump, mv);

		rb.MovePosition (transform.position + move * Time.deltaTime);

	}

	void LateUpdate() {
		mousePosLast = Input.mousePosition;
	}
}
