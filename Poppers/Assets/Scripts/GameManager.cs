using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public int player1Score;
	public int player2Score;
	public GameObject player1;
	public GameObject player2;

	[SerializeField] private int healthPlayer1;
	[SerializeField] private int healthPlayer2;

	[SerializeField] private List<GameObject> lifesPlayer1;
	[SerializeField] private List<GameObject> lifesPlayer2;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
        DontDestroyOnLoad(this.gameObject);
    }
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(instance);
		}
		
        
    }

	// Update is called once per frame
	void Update()
	{

	}

	public void PlayerDeath(string name) // string? maybe need gameObject
	{
		Debug.Log($"player " + name + "died");

		if (player1.name == name)
		{
			//player2Score++;
			healthPlayer1--;
			lifesPlayer1[healthPlayer1].gameObject.SetActive(false);
           // SceneManager.LoadScene("InGameScene");
        }
		else
		{
			//player1Score++;
			healthPlayer2--;
			lifesPlayer2[healthPlayer2].gameObject.SetActive(false);
			//SceneManager.LoadScene("InGameScene");
		}

		if (healthPlayer1 <= 0)
		{
			Player2Wins();
            SceneManager.LoadScene("InGameScene");
        }
		else if (healthPlayer2 <= 0)
		{
			Player1Wins();
            SceneManager.LoadScene("InGameScene");
        }

		// ScoreManager.UpdateScore();
		// Animator.PlayerDeath();
		// Sound
		// Decide here if we want to check to go to victory screen or start next round? 
		// Next round method or reuse StartGame?
		// GameManager.StartGame(player1.Score, player2.Score); ??

	}

	private void Player2Wins()
	{
		Debug.Log("Player2Wins");
		
	}

	private void Player1Wins()
	{
		Debug.Log("Player1Wins");
	}

    
    public void RestartGame()
    {
        SceneManager.LoadScene("InGameScene");
    }
}