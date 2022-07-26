using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameOverUI;
    GameStateManager inst = GameStateManager.instance;
    private void Start()
    {
        inst.OnStateChange += inst.ChangeGameState;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inst.currentState != GameState.Over)
        {
            inst.Invoke(inst.currentState == GameState.Play ? GameState.Pause : GameState.Play);
            pauseUI.SetActive(inst.isPaused);
        }
        if (inst.currentState == GameState.Over)
        {
            inst.Invoke(GameState.Over);
            gameOverUI.SetActive(true);
        }
    }
}
