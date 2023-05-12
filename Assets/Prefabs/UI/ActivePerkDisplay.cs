using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivePerkDisplay : MonoBehaviour
{
    [SerializeField] private Text _header;
    [SerializeField] private Text _description;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _background;

    public PerkData Data { get; private set; }

    public void Init(PerkData data)
    {
        Data = data;

        _header.text = data.Header;
        _description.text = data.Description;
        _icon.sprite = data.Icon;
        _background.color = data.RarityColor;
    }
}
