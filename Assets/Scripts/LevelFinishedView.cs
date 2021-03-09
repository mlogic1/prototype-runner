using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishedView : MonoBehaviour
{
	/// <summary>
	/// This function is assigned from the editor to be called when Back to main menu button is clicked
	/// </summary>
	public void ResetScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	/// <summary>
	/// Application.Quit() only works in built versions of projects. Does not work in Editor
	/// This function is assigned from the editor to be called when Quit button is clicked
	/// </summary>
	public void ExitGame()
	{
		Application.Quit();
	}
}
