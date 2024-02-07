using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void OnEnable()
    {
        Health.OnHPUpdated += UpdateHPBar;
    }

    private void UpdateHPBar(Health target)
    {

    }
}
