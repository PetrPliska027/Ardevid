using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CheckPointUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup _checkPointUI;
    [SerializeField, Range(0f, 5f)] private float _fadeDuration = 2.5f;
    [SerializeField, Range(0f, 5f)] private float _unFadeDuration = 2.5f;

    private void OnEnable()
    {
        Fountain.OnSkillTreeInteracted += Fade;
        Fountain.OnSkillTreeInteractEnded += UnFade;
    }

    private void OnDisable()
    {
        Fountain.OnSkillTreeInteracted -= Fade;
        Fountain.OnSkillTreeInteractEnded -= UnFade;
    }

    private void Fade()
    {
        _checkPointUI.enabled = true;
        _checkPointUI.DOFade(1, _fadeDuration);
    }

    private void UnFade()
    {
        _checkPointUI.DOFade(0, _unFadeDuration);
    }
}
