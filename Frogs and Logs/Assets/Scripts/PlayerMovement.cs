using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;
	private float turningSpeed = 20f;
	private Rigidbody playerRigidBody;
	[SerializeField]
	private RandomSoundPlayer playerFootsteps;

	// Use this for initialization
	void Start () {
		//Gather the components from the Player game objects
		playerAnimator = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Gahter input from keyboard
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");

		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
	} 
	// Physics-based. Continiously updated.
	void FixedUpdate () {
		//If player's movement vector does not equal zero...
		if (movement != Vector3.zero) {

			//then create a target rotation based on the movement vector
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
		
			// .. and create another rotation that moves form the current rotation to target rotation .. 
			Quaternion newRotation = Quaternion.Lerp (playerRigidBody.rotation, targetRotation, turningSpeed*Time.deltaTime);

			//and change the player's rotation to the new incremnetal rotation
			playerRigidBody.MoveRotation(newRotation); 

			// .. play footstep sounds 	
			playerFootsteps.enabled = true;


			//Then play the jump animation
			playerAnimator.SetFloat ("Speed", 3f);
		  }	else {
			//Otherwise don't play jump animation
			playerAnimator.SetFloat ("Speed", 0f);

			// Dont play footstep sounds
			playerFootsteps.enabled = false;
			
		}

	}


}
