using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuController : UIMenuBase
{
    [SerializeField]
    private MainMenu _mainMenu;
    [SerializeField]
    private LoadMenu _loadMenu;

    [SerializeField]
    private CanvasGroup cg;

    private UIMenuBase _currentMenu;

    public MainMenu MainMenu => _mainMenu;
    public LoadMenu LoadMenu => _loadMenu;

    private void Start()
    {
        _currentMenu = _mainMenu;
        UIMenuBase.ActiveMenus.Add(this);
        MainMenu mainMenu = _mainMenu;
        mainMenu.OnPlayButtonPressed += (Action)Delegate.Combine(mainMenu.OnPlayButtonPressed, (Action)delegate
        {
            cg.DOFade(0f, 0.25f);
            SetActiveStateForMenu(cg.gameObject, false);
            PerformMenuTransition(_mainMenu, _loadMenu);
        });
        LoadMenu loadMenu = _loadMenu;
        loadMenu.OnBackButtonPressed += (Action)Delegate.Combine(loadMenu.OnBackButtonPressed, (Action)delegate
        {
            PerformMenuTransition(_loadMenu, _mainMenu);
            cg.DOFade(1f, 0.25f).SetDelay(0.25f);
            SetActiveStateForMenu(cg.gameObject, true);
        });
    }

    private void PerformMenuTransition(UISubmenuBase from, UISubmenuBase to)
    {
        _currentMenu = to;
        from.Hide();
        to.Show();
    }
}
