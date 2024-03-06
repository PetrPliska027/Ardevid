using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : UISubmenuBase
{
    public Action OnPlayButtonPressed;

    [Header("Buttons")]
    [SerializeField]
    private Button _playButton;

    [SerializeField]
    private Button _settingsButton;

    [SerializeField]
    private Button _quitButton;

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);
        _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        _quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        OnPlayButtonPressed?.Invoke();
    }

    private void OnSettingsButtonClicked()
    {
        Push(MonoSingleton<UIManager>.Instance.SettingsMenuControllerTemplate);
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
