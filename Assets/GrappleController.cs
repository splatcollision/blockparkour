using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour {


	public GameObject grapple;
	public GameObject cannon;
	public GameObject player;
	public float flySpeed;

	private bool isRetract = false;
	private GameObject firedGrapple;
	private bool didFireGrapple = false;
	private GrappleProjectile firedGrappleController;
	private Vector3 flyTarget;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		if (isRetract) {
			float step = flySpeed * Time.deltaTime;
			player.transform.position = Vector3.MoveTowards(player.transform.position, flyTarget, step);
			if (player.transform.position == flyTarget) {
				isRetract = false;
				firedGrapple = GameObject.FindGameObjectWithTag ("FiredGrapple");
				Destroy (firedGrapple);
			}
		}

		if (Input.GetMouseButtonDown (0)) {
			
			if (didFireGrapple) {
					
				// tell the player FPS controller to move towards the firedGrapple
				//					Debug.Log(firedGrapple.transform.position);
				if (firedGrappleController.didHitTarget) {
					Debug.Log("destroy fired grapple");
					
					didFireGrapple = false;
					
					isRetract = true;	
//						player.transform.position = firedGrappleController.hitPosition;

					flyTarget = firedGrappleController.hitPosition;

				}


				
			} else {
				
				GameObject firedGrapple = (GameObject) Instantiate (grapple, cannon.transform.position, cannon.transform.rotation);
				didFireGrapple = true;
				firedGrappleController = GameObject.FindGameObjectWithTag ("FiredGrapple").GetComponent<GrappleProjectile>();

			}


		}

	}
}
