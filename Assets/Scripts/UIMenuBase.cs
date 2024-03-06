using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders.Simulation;
using UnityEngine.UI;

public abstract class UIMenuBase : MonoBehaviour
{
    public static readonly List<UIMenuBase> ActiveMenus = new List<UIMenuBase>();

    [SerializeField]
    protected CanvasGroup _canvasGroup;

    protected Canvas _canvas;
    protected virtual bool _addToActiveMenus => true;
    protected virtual bool _releaseOnHide => false;

    public bool IsShowing { get; private set; } 
    public bool IsHiding { get; private set; }

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
                    _canvas.sortingOrder = ActiveMenus[ActiveMenus.Count - 1]._canvas.sortingOrder + 1;
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
        IsShowing = true;
        if (_addToActiveMenus && _canvas != null && !ActiveMenus.Contains(this))
        {
            ActiveMenus.Add(this);
            UpdateSortingOrder();
        }
        gameObject.SetActive(true);
    }

    public virtual T Push<T>(T menu) where T : UIMenuBase
    {
        T val = menu.Instantiate();
        val.Show();
        return PushInstance(val);
    }

    public virtual T PushInstance<T>(T menu) where T : UIMenuBase
    {
        SetActiveForMenu(state: false);
        return menu;
    }

    protected virtual void SetActiveForMenu(bool state)
    {
        if (_canvasGroup != null)
        {
            _canvasGroup.interactable = state;
            SetActiveForMenu(gameObject, state);
        }
    }

    protected virtual void SetActiveForMenu(GameObject target, bool state)
    {
        Selectable[] componentsInChildren = target.GetComponentsInChildren<Selectable>();
        for (int i = 0; i < componentsInChildren.Length; i++)
        {
            componentsInChildren[i].interactable = state;
        }
    }
}
