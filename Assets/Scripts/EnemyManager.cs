using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private AudioClip winAudioClip;
    public static EnemyManager instance; //singleton instance
    
    private int enemyAmount = 0;
    public bool isLevelGenerated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevelGenerated && enemyAmount <= 0)
        {
            SoundFXManager.instance.PlaySoundFX(winAudioClip, transform, 1f);
            GameStateManager.instance.ChangeGameState(GameState.Win);
            isLevelGenerated = false;
        }
    }

    public void addEnemy(int amount)
    {
        enemyAmount += amount;
    }

    public void removeEnemy(int amount)
    {
        enemyAmount -= amount;
    }

    public int getEnemyAmount()
    {
        return enemyAmount;
    }
}
