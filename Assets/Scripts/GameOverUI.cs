using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameOverUI;
    [SerializeField, Range(0f, 5f)] private float fadeDuration = 2f;

    private void OnEnable()
    {
        HealthPlayer.OnPlayerDied += Fade;
    }

    private void OnDisable()
    {
        HealthPlayer.OnPlayerDied -= Fade;
    }

    private void Fade(HealthPlayer target)
    {
        gameOverUI.DOFade(1, fadeDuration);
    }
}
