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

    private void OnEnable()
    {
        HealthPlayer.OnHPUpdated += UpdateHPBar;
    }

    private void OnDisable()
    {
        HealthPlayer.OnHPUpdated -= UpdateHPBar;
    }

    private void UpdateHPBar(HealthPlayer target)
    {
        HPBar.maxValue = target.TotalHP;
        HPBar.value = target.HP;
    }
}
