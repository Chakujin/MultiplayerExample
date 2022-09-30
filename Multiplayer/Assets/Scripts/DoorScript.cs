using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private static List<GameObject> currentPlayers;

    private bool b_open = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Key")
        {
            b_open = true;
            Destroy(other);
        }    
    }

    public static void UpdatePlayerTotal(GameObject player)
    {
        currentPlayers.Add(player);
    }
}
