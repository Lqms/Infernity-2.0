using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PerksPool : MonoBehaviour
{
    [SerializeField] private List<PerkData> _perkDatas;

    public PerkData GetRandomPerk(PerkRarities requiredRarity)
    {
        var filteredPerks = _perkDatas.Where(p => p.Rarity== requiredRarity).ToList();

        return filteredPerks[Random.Range(0, filteredPerks.Count)];
    }
}
