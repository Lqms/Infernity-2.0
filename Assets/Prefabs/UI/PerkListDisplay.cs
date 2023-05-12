using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PerkListDisplay : MonoBehaviour
{
    [SerializeField] private PerkDisplay _perkDisplayPrefab;
    [SerializeField] private ContentSizeFitter _content;
    [SerializeField] private Button _openListButton;
    [SerializeField] private Button _closeListButton;
    [SerializeField] private Image _list;

    public event UnityAction<PerkData> PerkSelected;

    private void OnEnable()
    {
        _openListButton.onClick.AddListener(OnOpenListButtonClicked);
        _closeListButton.onClick.AddListener(OnCloseListButtonClicked);
    }

    private void OnDisable()
    {
        _openListButton.onClick.RemoveListener(OnOpenListButtonClicked);
        _closeListButton.onClick.RemoveListener(OnCloseListButtonClicked);
    }

    private void OnOpenListButtonClicked()
    {
        _list.gameObject.SetActive(true);
    }

    private void OnCloseListButtonClicked()
    {
        _list.gameObject.SetActive(false);
    }

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
        _list.gameObject.SetActive(false);
    }
}
