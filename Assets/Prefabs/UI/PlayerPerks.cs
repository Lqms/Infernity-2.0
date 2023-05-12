using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPerks : MonoBehaviour
{
    private List<PerkData> _perkDatas = new List<PerkData>();

    public List<PerkData> NotActivePerks { get; private set; } = new List<PerkData>();

    public event UnityAction<PerkData> ListChanged;

    public void AddNewPerk(PerkData data)
    {
        _perkDatas.Add(data);
        NotActivePerks.Add(data);
        ListChanged?.Invoke(data);
    }

    public void AddActivePerk(PerkData data)
    {
        NotActivePerks.Remove(data);
        ListChanged?.Invoke(data);

        print(data.Logic + " эффект активирован");
    }

    public void RemoveActivePerk(PerkData data)
    {
        NotActivePerks.Add(data);
        ListChanged?.Invoke(data);

        print(data.Logic + " эффект убран");
    }
}
