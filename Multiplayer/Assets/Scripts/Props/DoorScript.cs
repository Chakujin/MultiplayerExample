using UnityEngine;
using Photon.Pun;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private  int i_currentPlayers;
    [SerializeField] private int i_enterPlayers;

    [SerializeField]private bool b_open = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Key")
        {
            b_open = true;
            m_animator.SetBool("Open",true); // Animation
            AddPlayer(); //Take total players current ingame
            Destroy(other);
        } 
        if(other.tag == "Player" && b_open == true)
        {
            other.GetComponent<PlayerController>().DoorEnter();
            i_currentPlayers++; // Add player total enter on the door
            
            if(i_currentPlayers == i_enterPlayers) //If all players enter
            {
                //Termina el nivel
            }
        }   
    }

    private void AddPlayer()
    {
        /*
        No encuentro la manera de usar algun evento que me update el numero total cada vez que 
        entre o salga un jugador (Almenos sin el PUN2 que tiene eventos para esto)
        */
        i_currentPlayers = PhotonNetwork.PlayerList.Length;
    }
}
