using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListScript : MonoBehaviourPunCallbacks
{
    //Create itemlist players
    [SerializeField] private List<PlayerItemScript> m_playerItemList = new List<PlayerItemScript>();
    public PlayerItemScript playerItemPrefab;
    public Transform playerItemParent;

    private void Start()
    {
        LobbyManager.PlayerJoinedRoomCallback += UpdatePlayerList;
    }

    public void UpdatePlayerList()
    {
        //Clean All players
        foreach (PlayerItemScript item in m_playerItemList) 
        {
            Destroy(item.gameObject);
        }
        m_playerItemList.Clear();

        //If is not this room return
        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItemScript newPlayerItem = Instantiate(playerItemPrefab, playerItemParent); //Instantiate player

            newPlayerItem.SetPlayerInfo(player.Value);//Set info

            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges(); //If is your player apply changes
            }

            m_playerItemList.Add(newPlayerItem); //Add player room list
        }
    }

    //Players Enter and Back room
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }
}
