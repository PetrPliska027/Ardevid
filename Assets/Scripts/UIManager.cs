using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.SettingsMenu;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private UISettingsMenuController _settingsMenuControllerTemplate;

    public UISettingsMenuController SettingsMenuControllerTemplate => _settingsMenuControllerTemplate;

    private UIMenuBase _currentInstance;

    public PlayerInputHandler InputHandler { get; private set; }

    public bool MenusBlocked
    {
        get
        {
            //TODO: Implement logic (Count of Blocked Menus)
            return true;
        }
    }

    public bool IsPaused { get; private set; }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
    }

    public void Update()
    {
        GameManager instance = GameManager.GetInstance();
        if(!MenusBlocked && instance != null && _currentInstance != null)
        {
            if (InputHandler.EscapeInput)
            {
                ShowPauseMenu();
            }
        }
    }

    public void ShowPauseMenu()
    {
        IsPaused = true;

    }
}
