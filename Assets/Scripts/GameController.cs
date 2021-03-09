using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
  Idle,
  Active,
  PostGameWin,
  PostGameLose
}

public class GameController : MonoBehaviour
{
  public static GameController GameControllerInstance;

  [HideInInspector]
  public GameState gameState = GameState.Idle;

  void Start()
  {
    if (GameControllerInstance == null)
    {
      GameControllerInstance = this;
    }
  }

  void Update()
  {

  }
}
