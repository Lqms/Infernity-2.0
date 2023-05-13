using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkCard : MonoBehaviour
{
    [SerializeField] private PlayerPerks _playerPerks;

    [Header("Systems")]
    [SerializeField] private PerkListDisplay _perkListDisplay;
    [SerializeField] private ActivePerkDisplay _activePerkDisplay;

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

    private void OnPlayerPerkListChanged(PerkData data)
    {
        _perkListDisplay.Refresh(_playerPerks.NotActivePerks);
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
}
