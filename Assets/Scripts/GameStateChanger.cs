using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    GameStateManager inst = GameStateManager.instance;
    private void Start()
    {
        inst.OnStateChange += inst.ChangeGameState;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //GameStateManager.instance.ChangeGameState(GameStateManager.instance.currentState == GameState.Play ? GameState.Pause : GameState.Play);
            inst.Invoke(inst.currentState == GameState.Play ? GameState.Pause : GameState.Play);
            pauseUI.SetActive(inst.isPaused);
            //Debug.Log("coc: " + inst.currentState);
        }
    }
}
