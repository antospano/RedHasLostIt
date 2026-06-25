using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void LoadNewScene()
    {
        GameStateManager.instance.ChangeGameState(GameState.Play);
        SceneManager.LoadScene(sceneName);
    }
}
