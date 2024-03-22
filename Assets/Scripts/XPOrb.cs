using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrb : MonoBehaviour
{
    public delegate void XPAction(int _XPvalue);

    [SerializeField] private int _XPValue;
    private Player player;

    public static event XPAction OnXPGet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            OnXPGet?.Invoke(_XPValue);
            Destroy(gameObject);
        }
    }
}
