using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PerkListDisplay : MonoBehaviour
{
    [SerializeField] private PerkDisplay _perkDisplayPrefab;
    [SerializeField] private ContentSizeFitter _content;

    public event UnityAction<PerkData> PerkSelected;

    public void AddNewPerk(PerkData data)
    {
        var newListItem = Instantiate(_perkDisplayPrefab, _content.transform);
        newListItem.Init(data);
        newListItem.PerkSelected += OnPerkSelected;
    }

    private void OnPerkSelected(PerkData data, PerkDisplay selectedPerk)
    {
        selectedPerk.PerkSelected -= OnPerkSelected;
        Destroy(selectedPerk.gameObject);
        PerkSelected?.Invoke(data);
    }
}
