using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int player1Score;
	public int player2Score;
	public GameObject player1;
	public GameObject player2;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

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
			player2Score += player2Score;
		}
		else if (player2.name == name)
		{
			{
				player1Score += player1Score;
			}

			// ScoreManager.UpdateScore();
			// Animator.PlayerDeath();
			// Sound
			// Decide here if we want to check to go to victory screen or start next round? 
			// Next round method or reuse StartGame?
			// GameManager.StartGame(player1.Score, player2.Score); ??


		}

	}
}

