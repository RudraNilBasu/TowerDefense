using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public Transform spawnPoint;
	public Text waveCountdownText;


	public float timeBetweenWaves = 5.5f;
	private float countdown = 2f;



	private int waveIndex = 0;



	void Update()
	{
		if (countdown <= 0f) {
			StartCoroutine (SpawnWaves());
			countdown = timeBetweenWaves;
		}

		countdown -= Time.deltaTime;

		waveCountdownText.text = Mathf.Round (countdown).ToString ();
	}

	IEnumerator SpawnWaves()
	{
		// determine better algo to determine no of enemies for each waves
		// current algo = no of enemy = wave number
		waveIndex++;
		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}

	}

	void SpawnEnemy()
	{
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
