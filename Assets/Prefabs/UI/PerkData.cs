using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PerkRarities
{
    Common,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "New Perk Data", menuName = "Create New Perk Data", order = 54)]
public class PerkData : ScriptableObject
{
    [SerializeField] private string _header;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private PerkRarities _rarity;

    [SerializeField] private string _logic;

    public string Header => _header;
    public string Description => _description;
    public Sprite Icon => _icon;
    public PerkRarities Rarity => _rarity;
    public Color RarityColor => RarityToColor();
    public float ChanceToDrop => CalculateDropChanse();

    public string Logic => _logic;

    private float CalculateDropChanse()
    {
        float chanseToDrop;

        // 10, 25, 50, 100 - Constants
        switch (_rarity)
        {
            default:
                chanseToDrop = 100;
                break;

            case PerkRarities.Rare:
                chanseToDrop = 50;
                break;

            case PerkRarities.Epic:
                chanseToDrop = 25;
                break;

            case PerkRarities.Legendary:
                chanseToDrop = 10;
                break;
        }

        return chanseToDrop;
    }

    private Color RarityToColor()
    {
        Color color;

        switch (_rarity)
        {
            default:
                color = Color.grey;
                break;

            case PerkRarities.Rare:
                color = Color.green;
                break;

            case PerkRarities.Epic:
                color = Color.blue;
                break;

            case PerkRarities.Legendary:
                color = Color.magenta;
                break;
        }

        return color;
    }
}
