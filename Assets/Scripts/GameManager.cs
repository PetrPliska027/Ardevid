using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    public static GameManager GetInstance()
    {
        return _instance;
    }
}
