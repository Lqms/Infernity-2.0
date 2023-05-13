using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActivePerkDisplay : MonoBehaviour
{
    [SerializeField] private Image _wrapper;
    [SerializeField] private Text _header;
    [SerializeField] private Text _description;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _background;
    [SerializeField] private Button _removePerkButton;

    private PerkData _data;

    public event UnityAction<PerkData> PerkRemoved;

    private void OnEnable()
    {
        _removePerkButton.onClick.AddListener(OnRemovePerkButtonClicked);
    }

    private void OnDisable()
    {
        _removePerkButton.onClick.RemoveListener(OnRemovePerkButtonClicked);
    }

    private void OnRemovePerkButtonClicked()
    {
        PerkRemoved?.Invoke(_data);

        _wrapper.gameObject.SetActive(false);
    }

    public void Init(PerkData data)
    {
        _data = data;

        _header.text = data.Header;
        _description.text = data.Description;
        _icon.sprite = data.Icon;
        _background.color = data.RarityColor;

        _wrapper.gameObject.SetActive(true);
    }
}
