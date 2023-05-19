using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinigamePerks : MonoBehaviour
{
    [SerializeField] private PerkCard[] _perkCards;

    private void OnEnable()
    {
        LevelChangerTest.PlayerEnteredNewFloor += OnPLayerEnteredNewFloor;
    }
    private void OnDisable()
    {
        LevelChangerTest.PlayerEnteredNewFloor -= OnPLayerEnteredNewFloor;
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
}
