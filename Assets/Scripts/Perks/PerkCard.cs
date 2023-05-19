using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkCard : MonoBehaviour
{
    [SerializeField] private PlayerPerks _playerPerks;

    [Header("UI")]
    [SerializeField] private Image _cardStatus;
    [SerializeField] private Button _openPerkListButton;
    [SerializeField] private Sprite _unlockedIcon;

    [Header("Systems")]
    [SerializeField] private PerkListDisplay _perkListDisplay;
    [SerializeField] private ActivePerkDisplay _activePerkDisplay;

    public bool IsOpened { get; private set; }

    private void OnEnable()
    {
        _playerPerks.ListChanged += OnPlayerPerkListChanged;

        _perkListDisplay.PerkSelected += OnPerkSelected;
        _activePerkDisplay.PerkRemoved += OnPerkRemoved;
    }

    private void OnDisable()
    {
        _playerPerks.ListChanged -= OnPlayerPerkListChanged;

        _perkListDisplay.PerkSelected -= OnPerkSelected;
        _activePerkDisplay.PerkRemoved -= OnPerkRemoved;
    }

    private void OnPlayerPerkListChanged(List<PerkData> notActivePerksList)
    {
        _perkListDisplay.Refresh(notActivePerksList);
    }

    private void OnPerkSelected(PerkData data)
    {
        _playerPerks.AddActivePerk(data);
        _activePerkDisplay.Init(data);
    }

    private void OnPerkRemoved(PerkData data)
    {
        _playerPerks.RemoveActivePerk(data);
    }

    public void UnlockCard()
    {
        _openPerkListButton.interactable = true;
        _cardStatus.sprite = _unlockedIcon;
        IsOpened = true;
    }
}
