using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointsManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private DisplayValue pointsValueDisplay;
    [SerializeField] private DisplayValue finalPointsValueDisplay;
    private void Update()
    {
        if (GameStateManager.instance.isPaused)
        {
            return;
        }
        pointsValueDisplay.value = player.points.value;
        finalPointsValueDisplay.value = player.points.value;
    }
}
