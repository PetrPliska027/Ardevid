using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenu : UISubmenuBase
{
    public Action OnBackButtonPressed;

    [SerializeField]
    private SaveSlotBase[] _saveSlots;

    [SerializeField]
    private Button _backButton;

    private SaveSlotBase lastSelectedSaveSlot;

    private void Start()
    {
        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    public void SetupSaveSlots(int slot)
    {
        _saveSlots[slot].SetupSaveSlot(slot);
    }

    protected override void OnShowStarted()
    {
        SaveSlotBase[] saveSlots = _saveSlots;
        foreach (SaveSlotBase obj in saveSlots)
        {
            obj.OnSaveSlotPressed = (Action<int>)Delegate.Combine(obj.OnSaveSlotPressed, new Action<int>(OnTryLoadSaveSlot));
        }
    }

    private void OnTryLoadSaveSlot(int slot)
    {
        lastSelectedSaveSlot = _saveSlots[slot];
        if (lastSelectedSaveSlot.Occupied)
        {
            ContinueGame(slot);
        }
        else
        {
            PlayNewGame(slot);
        }
    }

    private void PlayNewGame(int slot)
    {
        // New Game
    }

    private void ContinueGame(int slot)
    {
        SetActiveStateForMenu(false);
        SceneManager.LoadScene("Game");
    }

    private void OnBackButtonClicked()
    {
        OnBackButtonPressed?.Invoke();
    }


}
