using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleProjectile : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 vec = new Vector3(0.0f,  , 0.0f);
		transform.position += transform.forward * speed;
	}
}
