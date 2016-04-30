using UnityEngine;
using System.Collections;

public class PlayerHealrh : MonoBehaviour {
	public bool alive;
	[SerializeField]
	private GameObject pickupPreFab;



	// Use this for initialization
	void Start () {
		alive = true;
	}


	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Enemy") && alive == true) {
			alive = false;




				//Create the pickup particle
			Instantiate(pickupPreFab, transform.position, Quaternion.identity);



		}
	}
}
