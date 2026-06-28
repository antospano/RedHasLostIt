using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StateChanger(GameState newState);

public class GameStateManager
{
    public static GameStateManager instance { get; private set; } = new GameStateManager();
    public GameState currentState { get; private set; } = GameState.Play;
    public bool isPaused { get; private set; } = false;
    public bool isOver { get; private set; } = false;
    public bool hasWon { get; private set; } = false;
    public event StateChanger OnStateChange;
    //private GameObject pauseUI;

    public void ChangeGameState(GameState newState)
    {
        switch(newState)
        {
            case GameState.Pause:
                isPaused = true;
                break;
            case GameState.Play:
                isPaused = false;
                isOver = false;
                break;
            case GameState.Over:
                isPaused = true;
                isOver = true;
                break;
            case GameState.Win:
                isPaused = true;
                isOver = true;
                hasWon = true;
                break;
        }
        currentState = newState;
        //PauseMenu();
    }

    public void Invoke(GameState newState)
    {
        OnStateChange?.Invoke(newState);
    }
}
