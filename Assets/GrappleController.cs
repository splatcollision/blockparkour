using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour {


	public GameObject grapple;
	public GameObject cannon;
	public GameObject camera;
//	public Transform shootPos;

	private GameObject firedGrapple;
//	private Rigidbody grappleRb;
	// Use this for initialization
	void Start () {
//		grappleRb = grapple.GetComponent<Rigidbody> ();
//		Debug.Log (cannon);
	}
	
	// Update is called once per frame
	void Update () {

		float oldYRotation = cannon.transform.eulerAngles.y;
		// get x from camera eulerAngles.x
		float oldXRotation = camera.transform.eulerAngles.x;

//		Debug.Log (oldXRotation);

		if (Input.GetMouseButtonDown (0)) {
//			Debug.Log ("Fire Grapple");
			// whats our orientation of the grapple cannon

			GameObject firedGrapple = Instantiate(grapple, cannon.transform.position, cannon.transform.rotation);

		}
		if (Input.GetMouseButtonDown (1)) {
//			Debug.Log ("Retract Grapple");
		}
	}
}
