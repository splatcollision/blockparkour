using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleProjectile : MonoBehaviour {

	public float speed;
	public Rigidbody rb;
	public bool didHitTarget;
	public Vector3 hitPosition;

	private float timeout = 3f; // 3 seconds of projectile travel time otherwise destroy self...
//	private GameObject go;
	// Use this for initialization
	void Start () {
//		speed = 4;
		rb = GetComponent<Rigidbody>();
//		go = GetComponent<GameObject> ();
//		rb.velocity = transform.forward * speed;
		Debug.Log("Projectile Started");
		StartCoroutine(CheckForTimeout());
	}
	
	// Update is called once per frame
	void Update () {

		if (!didHitTarget) {
			rb.transform.position += transform.forward * speed;

		} else {
			transform.localScale = new Vector3(0.4f, 0.4f, 2.0f);
			hitPosition = rb.transform.position;
		}



	}

	void OnTriggerEnter(Collider other) 
	{
		
		if (other.tag == "grapple_target") {
			// 
			Debug.Log (other.tag);
			//- stop moving
			didHitTarget = true;

		}
	}

	public IEnumerator CheckForTimeout() {
		Debug.Log ("Check for Timeout");

		yield return new WaitForSeconds(timeout); // waits 3 seconds
		Debug.Log("after 3 seconds");
		if (!didHitTarget) {
			// have to tell grapple controller we timed out
			Debug.Log (this.gameObject);
			GameObject.Destroy (this.gameObject);
		}
	}
}
