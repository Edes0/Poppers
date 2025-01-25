using UnityEngine;

public class GameManager : MonoBehaviour
{

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
		Debug.Log($"player {name} died");
		// ScoreManager.UpdateScore();
		// Animator.PlayerDeath();
		// Sound
		// Decide here if we want to check to go to victory screen or start next round? 
		// Next round method or reuse StartGame?
		// GameManager.StartGame(player1.Score, player2.Score); ??
	}

}
