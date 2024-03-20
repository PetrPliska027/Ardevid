using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotBase : MonoBehaviour
{
    public Action<int> OnSaveSlotPressed;

    [SerializeField]
    protected Button _button;

    [SerializeField]
    protected TextMeshProUGUI _text;

    private int _slotIndex;
    private bool _occupied;

    // Data to SaveSLot

    public Button Button => _button;

    public bool Occupied => _occupied;

    private void Awake()
    {
        
    }

    public void SetupSaveSlot(int index)
    {
        _slotIndex = index;
        UpdateSaveSlot();
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(OnSaveSlotButtonClicked);
    }   

    public void UpdateSaveSlot()
    {
        if (_occupied)
        {
            _text.text = "Save Slot " + _slotIndex + " - Occupied";
        }
        else
        {
            _text.text = "Save Slot " + _slotIndex + " - Empty";
        }
    }

    private void OnSaveSlotButtonClicked()
    {
        OnSaveSlotPressed?.Invoke(_slotIndex);
    }
}
