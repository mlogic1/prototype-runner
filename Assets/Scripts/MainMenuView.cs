using UnityEngine;

public class MainMenuView : MonoBehaviour
{
	public CanvasGroup canvasGroup;

	/// <summary>
	/// This function hides the main menu and starts the game
	/// This function is assigned from the editor to be called when Play button is clicked
	/// </summary>
	public void OnPlayButtonClicked()
	{
		canvasGroup.alpha = 0.0f;
		canvasGroup.blocksRaycasts = false;
		GameController.GameControllerInstance.gameState = GameState.Active;
	}

	/// <summary>
	/// Application.Quit() only works in built versions of projects. Does not work in Editor
	/// This function is assigned from the editor to be called when Quit button is clicked
	/// </summary>
	public void OnExitButtonClicked()
	{
		Application.Quit();
	}
}
