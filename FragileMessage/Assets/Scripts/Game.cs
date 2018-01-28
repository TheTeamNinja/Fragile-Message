using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : Singleton<Game>
{
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
    public GameObject gamePanel;
    public Player player;
    public Environment environment;
    public Text scoreText;
    public Text highScoreText;
    public Text yourScoreText;
    public bool playing;

    private int score;
    private int highScore;

    void Start()
    {
        InitGame();
    }

    public void InitGame()
    {
        startPanel.SetActive(true);
        gameoverPanel.SetActive(false);
        gamePanel.SetActive(false);
        playing = false;
        cameraIntro.SetActive(true);
        cameraGameplay.SetActive(false);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (playing)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = cars[Random.Range(0, cars.Length)];
                Transform spawnCar = spawnCars[Random.Range(0, spawnCars.Length)];

                Instantiate(hazard, spawnCar.position, spawnCar.rotation);

                yield return new WaitForSeconds(spawnWait);
            }

            planeSpeed++;
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void GameIntro()
    {
        highScore = PlayerPrefs.GetInt("highScore", highScore);
        score = 0;
        scoreText.text = score.ToString();
        startPanel.SetActive(false);
        playing = false;
        player.PlayIntro();
    }

    public void StartGame()
    {
        gamePanel.SetActive(true);
        cameraIntro.SetActive(false);
        cameraGameplay.SetActive(true);
        playing = true;
        planeSpeed = 5;
        StartCoroutine(SpawnWaves());
    }

    public void GameOver()
    {
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(true);
        planeSpeed = 0;
        playing = false;

        if (score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt("highScore", highScore);
        }
        highScoreText.text = "High Score: " + highScore;
        yourScoreText.text = "Your Score: " + score;
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }
    
    public void RestartGame()
    {
        environment.InitGame();
        gameoverPanel.SetActive(false);
        player.Restart();
        GameIntro();
        cameraGameplay.SetActive(false);
        cameraIntro.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }    
}