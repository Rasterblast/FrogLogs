using UnityEngine;
using System.Collections;

public class FlySpawner : MonoBehaviour {

	[SerializeField]
	private GameObject flyPrefab;

	[SerializeField]
	private int totalFlyMinimum = 12; 

	private float spawnArea = 25f;

	public static int totalFlies;

	// Use this for initialization
	void Start () {
		totalFlies = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//while the total nmber of flies is less than minimum
		while (totalFlies < totalFlyMinimum) {

			//then increment thew total number of flies
			 totalFlies++;
			// create a random position for a fly 
			 float positionX = Random.Range(-spawnArea, spawnArea);
			 float positionZ = Random.Range(-spawnArea, spawnArea);

			 Vector3 flyPosition = new Vector3(positionX, 2f, positionZ);

			// and create a new fly 
			 Instantiate(flyPrefab, flyPosition, Quaternion.identity); 

		}
  	}

}