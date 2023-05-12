using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPerkTest : MonoBehaviour
{
    [SerializeField] private PerksPool _perksPool;
    [SerializeField] private PlayerPerksPool _playerPerksPool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            var perk = _perksPool.GetRandomPerk();
            _playerPerksPool.AddNewPerk(perk);
        }
    }
}
