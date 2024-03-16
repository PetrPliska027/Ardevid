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
    public Action OnShown;
    public Action OnHide;
    public Action OnFirstMenuShow;
    public Action OnFirstMenuShown;
    public Action OnShownCompleted;

    [SerializeField]
    protected Animator _animator;

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

    public void Show(bool immediate = false)
    {
        IsShowing = true;
        if (_addToActiveMenus && _canvas != null && !ActiveMenus.Contains(this))
        {
            ActiveMenus.Add(this);
            UpdateSortingOrder();
        }
        base.gameObject.SetActive(value: true);
        if (immediate)
        {
            if(_animator != null)
            {
                //_animator.Play("Shown");
            }
            else
            {
                _canvasGroup.alpha = 1f;
            }
            SetActiveStateForMenu(state: true);
            OnShowStarted();
            if (_addToActiveMenus && _canvas != null && ActiveMenus.Count == 1)
            {
                OnFirstMenuShow?.Invoke();
            }
            OnShow?.Invoke();
            if (_addToActiveMenus && _canvas != null && ActiveMenus.Count == 1)
            {
                OnFirstMenuShow?.Invoke();
            }
            OnShown?.Invoke();
            OnShowCompleted();
            OnShownCompleted?.Invoke();
            IsShowing = false;
        }
        else
        {
            StartCoroutine(DoShow());
        }
    }

    protected virtual IEnumerator DoShow()
    {
        yield return null;
        SetActiveStateForMenu(state: true);
        OnShowStarted();
        if (_addToActiveMenus && _canvas != null && ActiveMenus.Count == 1)
        {
            OnFirstMenuShow?.Invoke();
        }
        OnShow?.Invoke();
        yield return DoShowAnimation();
        if (_addToActiveMenus && _canvas != null && ActiveMenus.Count == 1)
        {
            OnFirstMenuShown?.Invoke();
        }
        OnShown?.Invoke();
        OnShowCompleted();
        OnShownCompleted?.Invoke();
        IsShowing = false;
    }

    protected virtual IEnumerator DoShowAnimation()
    {
        if (_animator != null)
        {
            yield return _animator.YieldForAnimation("Show");
            yield break;
        }
        while (_canvasGroup.alpha < 1f)
        {
            _canvasGroup.alpha += Time.unscaledDeltaTime * 10f;
            yield return null;
        }
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
