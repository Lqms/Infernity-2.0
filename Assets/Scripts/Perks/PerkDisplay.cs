using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PerkDisplay : MonoBehaviour
{
    [SerializeField] private Text _header;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _background;
    [SerializeField] private Button _button;

    private PerkData _data;

    public event UnityAction<PerkData> PerkSelected;

    public void Init(PerkData data)
    {
        _data = data;

        _header.text = data.Header;
        _icon.sprite = data.Icon;
        _background.color = data.RarityColor;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        PerkSelected?.Invoke(_data);
    }
}
