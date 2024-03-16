using DG.Tweening;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup _gameOverUI;
    [SerializeField, Range(0f, 5f)] private float _fadeDuration = 2f;

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
        _gameOverUI.enabled = true;
        _gameOverUI.DOFade(1, _fadeDuration);
    }
}
