using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders.Simulation;
using UnityEngine.UI;

public abstract class UIMenuBase : MonoBehaviour
{
    public static readonly List<UIMenuBase> ActiveMenus = new List<UIMenuBase>();

    public Action OnShow;

    [SerializeField]
    protected CanvasGroup _canvasGroup;

    protected Canvas _canvas;
    protected virtual bool _addToActiveMenus => true;
    protected virtual bool _releaseOnHide => false;

    public bool IsHiding { get; private set; }
    public bool IsShowing { get; private set; } 

    public CanvasGroup CanvasGroup => _canvasGroup;
    public Canvas Canvas => _canvas;

    public virtual void Awake()
    {
        if (TryGetComponent<Canvas>(out var component))
        {
            _canvas = component;
            UpdateSortingOrder();
        }
    }

    protected virtual void UpdateSortingOrder()
    {
        try
        {
            if (_canvas != null)
            {
                if (ActiveMenus.Count > 0)
                {
                    _canvas.sortingOrder = ActiveMenus.LastElement()._canvas.sortingOrder + 1;
                }
                else
                {
                    _canvas.sortingOrder = 100;
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void Show()
    {
        if (IsShowing || IsHiding)
        {
            return;
        }

        IsShowing = true;
        IsHiding = false;

        if (_addToActiveMenus)
        {
            ActiveMenus.Add(this);
        }

        if (_canvasGroup != null)
        {
            _canvasGroup.alpha = 1;
        }

        SetActiveStateForMenu(state: true);
        OnShowStarted();
        OnShow?.Invoke();
        OnShowCompleted();
        
    }

    public void Hide()
    {
        if (IsHiding || !IsShowing)
        {
            return;
        }

        IsHiding = true;
        IsShowing = false;

        if (_releaseOnHide)
        {
            ActiveMenus.Remove(this);
        }

        if (_canvasGroup != null)
        {
            _canvasGroup.alpha = 0;
        }

        SetActiveStateForMenu(state: false);
    }

    protected virtual void OnShowStarted()
    {

    }

    protected virtual void OnShowCompleted()
    {

    }

    public virtual T Push<T>(T menu) where T : UIMenuBase
    {
        T val = menu.Instantiate();
        val.Show();
        return PushInstance(val);
    }

    public virtual T PushInstance<T>(T menu) where T : UIMenuBase
    {
        SetActiveStateForMenu(state: false);
        return menu;
    }

    protected virtual void SetActiveStateForMenu(bool state)
    {
        if (_canvasGroup != null)
        {
            _canvasGroup.interactable = state;
            SetActiveStateForMenu(gameObject, state);
        }
    }

    protected virtual void SetActiveStateForMenu(GameObject target, bool state)
    {
        Selectable[] componentsInChildren = target.GetComponentsInChildren<Selectable>();
        for (int i = 0; i < componentsInChildren.Length; i++)
        {
            componentsInChildren[i].interactable = state;
        }
    }
}
