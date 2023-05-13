using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPerkTest : MonoBehaviour
{
    [SerializeField] private PerksPool _perksPool;
    [SerializeField] private PlayerPerks _playerPerks;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            var perk = _perksPool.GetRandomPerk(RandomPerkRarity());
            _playerPerks.AddNewPerk(perk);
        }
    }

    private PerkRarities RandomPerkRarity()
    {
        float playerLuckPercentTest = 50; // PlayerStats

        float randomNumber = Random.Range(0, 100 - playerLuckPercentTest);

        // 10, 25, 50, 100 - Constants
        if (randomNumber <= 10)
        {
            return PerkRarities.Legendary;
        }
        else if (randomNumber <= 25)
        {
            return PerkRarities.Epic;
        }
        else if (randomNumber <= 50)
        {
            return PerkRarities.Rare;
        }
        else
        {
            return PerkRarities.Common;
        }
    }
}
