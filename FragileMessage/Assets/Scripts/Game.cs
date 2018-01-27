using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Singleton<Game> {

	public float planeSpeed;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject[] cars;
	public Transform[] spawnCars;
	public GameObject cameraIntro;
	public GameObject cameraGamePlay;
	public GameObject startPanel;
	public Player player;

	public bool playing;
	
	void Start ()
	{
		startPanel.SetActive(true);
		playing = false;
		cameraIntro.SetActive (true);
		cameraGamePlay.SetActive (false);
	}
	
	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);

		while (playing) {
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = cars[Random.Range(0, cars.Length)];
				Transform spawnCar = spawnCars[Random.Range(0, spawnCars.Length)];
				
				Instantiate (hazard, spawnCar.position, spawnCar.rotation);

				yield return new WaitForSeconds (spawnWait);
			}

			yield return new WaitForSeconds (waveWait);

			/*if (gameOver) {
				restartButton.SetActive (true);
				restart = true;
				break;
			}*/
		}
	}

	public void InitGame()
	{
		startPanel.SetActive(false);
		playing = false;
		player.PlayIntro();
	}

	public void StartGame()
	{
		cameraIntro.SetActive (false);
		cameraGamePlay.SetActive (true);
		playing = true;
		planeSpeed = 5;
		StartCoroutine (SpawnWaves ());
	}
}
