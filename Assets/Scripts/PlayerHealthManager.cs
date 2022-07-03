using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private DisplayValue healthValueDisplay;

    private void Update()
    {
        if (player.health.value <= 0)
        {
            player.health.SetHealth(0);
            Destroy(player.GetPlayer());
        }
        else if (player.health.value > maxHealth)
        {
            player.health.SetHealth(maxHealth);
        }

        healthValueDisplay.value = player.health.value;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
