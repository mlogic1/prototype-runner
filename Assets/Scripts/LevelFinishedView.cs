using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishedView : MonoBehaviour
{
  public void ResetScene()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void ExitGame()
  {
    Application.Quit();
  }
}
