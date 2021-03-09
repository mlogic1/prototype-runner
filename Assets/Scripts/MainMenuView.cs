using UnityEngine;

public class MainMenuView : MonoBehaviour
{
  public CanvasGroup canvasGroup;

  public void OnPlayButtonClicked()
  {
    canvasGroup.alpha = 0.0f;
    canvasGroup.blocksRaycasts = false;
    GameController.GameControllerInstance.gameState = GameState.Active;
  }

  public void OnExitButtonClicked()
  {
    Application.Quit();
  }
}
