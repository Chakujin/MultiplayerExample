using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    private static List<GameObject> currentPlayers;

    [SerializeField]private bool b_open = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Key")
        {
            b_open = true;
            m_animator.SetBool("Open",true); // Animation
            Destroy(other);
        } 
        if(other.tag == "Player" && b_open == true)
        {
            other.GetComponent<PlayerController>().DoorEnter();
        }   
    }

    //Add spawned players to total player list
    public static void UpdatePlayerTotal(GameObject player)
    {
        currentPlayers.Add(player);
    }
}
