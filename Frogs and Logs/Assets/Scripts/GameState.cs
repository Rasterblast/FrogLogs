using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : MonoBehaviour {
	private bool gameStarted = false;
	[SerializeField]
	private Text gameStateText;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private BirdMovement birdMovement;
	[SerializeField]
	private FollowCamera followCamera;
	private float restartDelay = 3f;
	private float restartTimer;
	private PlayerMovement playerMovement;
	private PlayerHealrh playerHealrh;


	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		playerMovement = player.GetComponent<PlayerMovement> ();
		playerHealrh = player.GetComponent<PlayerHealrh> (); 

		//Prevent the player from moving 
		playerMovement.enabled = false;


	    //Prevent Bird from moving
		birdMovement.enabled = false;
	

		//Prevent the follow camera from moving to its Game Position
		followCamera.enabled = false; 


	}
	
	// Update is called once per frame
	void Update () {
		//If the game has not started and the player pressesd the spcae bar then start game
		if (gameStarted == false && Input.GetKeyUp 	(KeyCode.Space)) {
			StartGame();

		}
		//If player is no longer alive then end the game
		if (playerHealrh.alive == false) {
		   

			EndGame();
			//...increment a timer to count up to restarting 
			restartTimer = restartTimer + Time.deltaTime;
			//And if it reaches the restart delay
			if (restartTimer >= restartDelay) {
				//reload the currently reloadly level
				Application.LoadLevel (Application.loadedLevel);
			}

			}
	}
	private void StartGame() {
		//set game state
		gameStarted = true;

	    //remove the start text
		gameStateText.color = Color.clear;  

		//Allow the player the move
		playerMovement.enabled = true;
	
		birdMovement.enabled = true;

		followCamera.enabled = true;

	}





	private void EndGame() {
		gameStarted = false; 

		//Show the game over text
		gameStateText.color = Color.white;
		gameStateText.text = "Game Over!";
		  
		//Remove player from existence
		player.SetActive (false);


	}

}







