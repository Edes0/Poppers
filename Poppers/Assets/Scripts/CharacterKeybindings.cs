using UnityEngine;

public class CharacterKeybindings : MonoBehaviour
{
	// Keybindings for movement
	public KeyCode moveUpKey;
	public KeyCode moveLeftKey;
	public KeyCode moveDownKey;
	public KeyCode moveRightKey;
	public KeyCode expandKey;

	public CharacterKeybindings(
		KeyCode up,
		KeyCode left,
		KeyCode down,
		KeyCode right,
		KeyCode expand)
	{
		moveUpKey = up;
		moveLeftKey = left;
		moveDownKey = down;
		moveRightKey = right;
		expandKey = expand;
	}
}

