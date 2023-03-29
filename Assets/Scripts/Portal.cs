using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : InteractableObject
{
    public override void Use(Player player)
    {
        player.transform.position = new Vector3(0, 1, 0);
        print("puf");
    }
}
