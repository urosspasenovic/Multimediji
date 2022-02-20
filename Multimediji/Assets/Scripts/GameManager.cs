using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
	public static GameManager gm;
	public int score = 0;
	public bool canBeatLevel = false;
	public int beatLevelScore = 0;
	public float startTime = 5.0f;
	public Text mainScoreDisplay;
	public Text mainTimerDisplay;
	public GameObject gameOverScoreOutline;
	public AudioSource musicAudioSource;
	public bool gameIsOver = false;
	public GameObject playAgainButtons;
	public string playAgainLevelToLoad;
	public GameObject nextLevelButtons;
	public string nextLevelToLoad;
	public GameObject restartButton;
	public string levelLoadOnRestart;
	private float currentTime;

	void Start()
	{
		currentTime = startTime;
		if (gm == null)
			gm = this.gameObject.GetComponent<GameManager>();
		mainScoreDisplay.text = "0";
		gameOverScoreOutline.SetActive(false);
		playAgainButtons.SetActive(false);
		if(nextLevelButtons)
			nextLevelButtons.SetActive(false);
		if(restartButton)
			restartButton.SetActive(false);

	}

	void Update()
	{
		if (!gameIsOver)
		{
			if (canBeatLevel && (score >= beatLevelScore))
			{  
				BeatLevel();
			}
			else if (currentTime < 0)
			{ 
				EndGame();
			}
			else
			{ 
				currentTime -= Time.deltaTime;
				mainTimerDisplay.text = currentTime.ToString("0.00");
			}
		}
	}

	void EndGame()
	{
		gameIsOver = true;
		mainTimerDisplay.text = "GAME OVER";
		gameOverScoreOutline.SetActive(true);
		playAgainButtons.SetActive(true);
		musicAudioSource.pitch = 0.5f; 
		if(restartButton)
			restartButton.SetActive(true);
	}

	void BeatLevel()
	{
		gameIsOver = true;
		mainTimerDisplay.text = "LEVEL COMPLETE";
		gameOverScoreOutline.SetActive(true);
		if (nextLevelButtons)
			nextLevelButtons.SetActive(true);
	}
	public void targetHit(int scoreAmount, float timeAmount)
	{
		score += scoreAmount;
		mainScoreDisplay.text = score.ToString();
		currentTime += timeAmount;
		if (currentTime < 0)
			currentTime = 0.0f;
		mainTimerDisplay.text = currentTime.ToString("0.00");
	}
	public void RestartGame()
	{
		if (playAgainButtons) 
			SceneManager.LoadScene(playAgainLevelToLoad);
	}
	public void NextLevel()
	{
		if (nextLevelButtons)
			SceneManager.LoadScene(nextLevelToLoad);
	}

	public void RestartToLevel1()
	{
		if(restartButton)
			SceneManager.LoadScene(levelLoadOnRestart);
	}
}

