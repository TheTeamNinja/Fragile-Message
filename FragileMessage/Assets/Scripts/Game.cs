using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : Singleton<Game> {

	public float planeSpeed;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject[] cars;
	public Transform[] spawnCars;
	public GameObject cameraIntro;
	public GameObject cameraGameplay;
	public GameObject startPanel;
	public GameObject gameoverPanel;
	public Player player;
	public Environment environment;

	public bool playing;
	
	void Start ()
	{
		InitGame();
	}

	public void InitGame()
	{
		startPanel.SetActive(true);
		gameoverPanel.SetActive(false);
		playing = false;
		cameraIntro.SetActive (true);
		cameraGameplay.SetActive (false);
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
		}
	}

	public void GameIntro()
	{
		startPanel.SetActive(false);
		playing = false;
		player.PlayIntro();
	}

	public void StartGame()
	{
		cameraIntro.SetActive (false);
		cameraGameplay.SetActive (true);
		playing = true;
		planeSpeed = 5;
		StartCoroutine (SpawnWaves ());
	}

	public void GameOver()
	{
		gameoverPanel.SetActive(true);
		planeSpeed = 0;
		playing = false;
	}

	public void RestartGame()
	{
		environment.InitGame();
		gameoverPanel.SetActive(false);
		player.Restart();
		GameIntro();
		cameraGameplay.SetActive (false);
		cameraIntro.SetActive (true);
	}
}
