using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UISubmenuBase : UIMenuBase
{
    protected UIMenuBase _parent;
    public override void Awake()
    {
        base.Awake();
        _parent = GetComponentInParent<UIMenuBase>();
    }
    public override T Push<T>(T menu)
    {
        if (_parent != null)
        {
            return _parent.Push(menu);
        }
        return base.Push(menu);
    }
    public override T PushInstance<T>(T menu)
    {
        if (_parent != null)
        {
            return _parent.PushInstance(menu);
        }
        return base.PushInstance(menu);
    }
}
