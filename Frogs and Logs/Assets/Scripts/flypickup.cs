using UnityEngine;
using System.Collections;

public class flypickup : MonoBehaviour {

	[SerializeField]
	private GameObject pickupPrefab;

	void OnTriggerEnter(Collider other) {

		// if the collider other is tagged with "Player"...execute

		if (other.CompareTag ("Player")) {

			//add the pickup particles
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);


			// we must decrement the total number of flies 
			FlySpawner.totalFlies--;
			// update the score
			ScoreCounter.score++; 

			Destroy (gameObject); 
		   }
	}
}