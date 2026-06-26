using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    public void LoadNewScene()
    {
        GameStateManager.instance.ChangeGameState(GameState.Play);
        SceneManager.LoadScene(sceneName);
    }
}
