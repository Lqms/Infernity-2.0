using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PerkLogic : MonoBehaviour
{
    [SerializeField] private PerkData[] _datas;

    private PerkRarities _currentRarity;
    private PerkData _currentData;

    public PerkData Data => _currentData;

    private void Start()
    {
        _currentRarity = _currentData.Rarity;
    }

    public void UpgradeRarity()
    {
        switch (_currentRarity)
        {
            case PerkRarities.Common:
                _currentRarity = PerkRarities.Rare;
                break;

            case PerkRarities.Rare:
                _currentRarity = PerkRarities.Epic;
                break;

            case PerkRarities.Epic:
                _currentRarity = PerkRarities.Legendary;
                break;
        }

        _currentData = _datas.FirstOrDefault(d => d.Rarity == _currentRarity);
    }
}
