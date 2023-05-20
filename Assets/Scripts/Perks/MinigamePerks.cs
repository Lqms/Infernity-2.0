using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MinigamePerks : MonoBehaviour
{
    [SerializeField] private PerkCard[] _perkCards;
    [SerializeField] private HorizontalLayoutGroup _perkCardsWrapper;

    private void OnEnable()
    {
        LevelChangerTest.PlayerEnteredNewFloor += OnPLayerEnteredNewFloor;
        PlayerInput.OpenPerkCardsKeyPressed += OnOpenPerkCardsKeyPressed;
    }
    private void OnDisable()
    {
        LevelChangerTest.PlayerEnteredNewFloor -= OnPLayerEnteredNewFloor;
        PlayerInput.OpenPerkCardsKeyPressed += OnOpenPerkCardsKeyPressed;
    }

    private void OnPLayerEnteredNewFloor(int floor)
    {
        if (floor == 10)
        {
            LevelChangerTest.PlayerEnteredNewFloor -= OnPLayerEnteredNewFloor;
            return;
        }

        if (floor % 2 == 0)
        {
            var closedCard = _perkCards.FirstOrDefault(p => !p.IsOpened);
            closedCard.UnlockCard();
        }
    }

    private void OnOpenPerkCardsKeyPressed()
    {
        _perkCardsWrapper.gameObject.SetActive(!_perkCardsWrapper.gameObject.activeSelf);
    }
}
