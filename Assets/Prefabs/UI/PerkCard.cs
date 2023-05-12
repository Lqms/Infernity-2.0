using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkCard : MonoBehaviour
{
    [SerializeField] private PlayerPerksPool _playerPerksPool;
    [SerializeField] private PerkListDisplay _perkListDisplay;
    [SerializeField] private ActivePerkDisplay _activePerkDisplay;

    private void OnEnable()
    {
        _playerPerksPool.NewPerkAdded += OnPlayerNewPerkAdded;
        _perkListDisplay.PerkSelected += OnPerkSelected;
    }

    private void OnDisable()
    {
        _playerPerksPool.NewPerkAdded -= OnPlayerNewPerkAdded;
        _perkListDisplay.PerkSelected -= OnPerkSelected;
    }

    private void OnPlayerNewPerkAdded(PerkData data)
    {
        _perkListDisplay.AddNewPerk(data);
    }

    private void OnPerkSelected(PerkData data)
    {
        if (_activePerkDisplay.Data != null)
            _perkListDisplay.AddNewPerk(_activePerkDisplay.Data);

        _activePerkDisplay.Init(data);
    }
}
