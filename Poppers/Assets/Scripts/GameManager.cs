using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

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

	}
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
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
        }
		else
		{
            //player1Score++;
            healthPlayer2--;
            lifesPlayer2[healthPlayer2].gameObject.SetActive(false);
        }

		if (healthPlayer1 < 0)
		{
			//Player 2 wins
		}
		else if (healthPlayer2 < 0)
		{
			//player 1 wins
		}

		// ScoreManager.UpdateScore();
		// Animator.PlayerDeath();
		// Sound
		// Decide here if we want to check to go to victory screen or start next round? 
		// Next round method or reuse StartGame?
		// GameManager.StartGame(player1.Score, player2.Score); ??

	}
}