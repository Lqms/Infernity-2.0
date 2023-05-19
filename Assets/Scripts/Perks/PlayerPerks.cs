using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPerks : MonoBehaviour
{
    private List<PerkData> _perkDatas = new List<PerkData>();
    private List<PerkData> _notActivePerks = new List<PerkData>();

    public event UnityAction<List<PerkData>> ListChanged;

    public void AddNewPerk(PerkData data)
    {
        _perkDatas.Add(data);
        _notActivePerks.Add(data);

        ListChanged?.Invoke(_notActivePerks);
    }

    public void AddActivePerk(PerkData data)
    {
        _notActivePerks.Remove(data);
        ListChanged?.Invoke(_notActivePerks);

        print(data.Logic + " эффект активирован");
    }

    public void RemoveActivePerk(PerkData data)
    {
        _notActivePerks.Add(data);
        ListChanged?.Invoke(_notActivePerks);

        print(data.Logic + " эффект убран");
    }
}
