using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPerksPool : MonoBehaviour
{
    private List<PerkData> _perkDatas = new List<PerkData>();

    public event UnityAction<PerkData> NewPerkAdded;

    public void AddNewPerk(PerkData data)
    {
        _perkDatas.Add(data);
        NewPerkAdded?.Invoke(data);
    }
}
