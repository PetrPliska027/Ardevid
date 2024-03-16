using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField]
    private Slider HPBar;

    [SerializeField]
    private Slider XPBar;

    private void OnEnable()
    {
        HealthPlayer.OnHPUpdated += UpdateHPBar;
        LevelManager.OnLevelUp += UpdateXPBar;
        LevelManager.OnXPUpdated += UpdateXPBar;
    }

    private void OnDisable()
    {
        HealthPlayer.OnHPUpdated -= UpdateHPBar;
        LevelManager.OnLevelUp -= UpdateXPBar;
        LevelManager.OnXPUpdated -= UpdateXPBar;
    }

    private void UpdateHPBar(HealthPlayer target)
    {
        HPBar.maxValue = target.TotalHP;
        HPBar.value = target.HP;
    }

    private void UpdateXPBar(LevelManager target)
    {
        XPBar.maxValue = target.ExpereinceToNextLevel;
        XPBar.value = target.XP;
    }
}
