using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public void PrepareForTeleportation()
    {
        GetComponent<NavMeshAgent>().enabled = false;
    }

    public void EndTeleportation()
    {
        GetComponent<NavMeshAgent>().enabled = true;
    }
}
