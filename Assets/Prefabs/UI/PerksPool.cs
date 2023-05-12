using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerksPool : MonoBehaviour
{
    [SerializeField] private List<PerkData> _perkDatas;

    public PerkData GetRandomPerk()
    {
        return _perkDatas[Random.Range(0, _perkDatas.Count)];
    }
}
