using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void LevelAction(LevelManager target);

    [SerializeField]
    private int _level = 1;
    [SerializeField]
    private int _skillPoints;
    [SerializeField]
    private int _XP;
    [SerializeField]
    private int _expereinceToNextLevel = 100;

    public int Level
    {
        get => _level;
        set
        {
            _level = value;
        }
    }
    public int SkillPoints
    {
        get => _skillPoints;
        set
        {
            _skillPoints = value;
        }
    }
    public int XP
    {
        get => _XP;
        set
        {
            _XP = value;
            OnXPUpdated?.Invoke(this);
            if (_XP >= _expereinceToNextLevel)
            {
                LevelUp();
            }
        }
    }
    public int ExpereinceToNextLevel
    {
        get => _expereinceToNextLevel;
        set
        {
            _expereinceToNextLevel = value;
            OnXPUpdated?.Invoke(this);
        }
    }

    public static event LevelAction OnLevelUp;
    public static event LevelAction OnXPUpdated;

    private void OnEnable()
    {
        XPOrb.OnXPGet += GetXP;
    }

    private void OnDisable()
    {
        XPOrb.OnXPGet -= GetXP;
    }

    public void GetXP(int _XPvalue)
    {
        XP += _XPvalue;
    }

    public void LevelUp()
    {
        XP -= ExpereinceToNextLevel;
        ExpereinceToNextLevel += Mathf.FloorToInt(ExpereinceToNextLevel * 1.3f);
        Level++;
        SkillPoints += 2;
    }
}
