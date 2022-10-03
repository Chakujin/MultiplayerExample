using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListScript : MonoBehaviourPunCallbacks
{
    //Create itemlist players
    public List<PlayerItemScript> playerItemList = new List<PlayerItemScript>();
    public PlayerItemScript playerItemPrefab;
    public Transform playerItemParent;

    private void Start()
    {
        LobbyManager.PlayerJoinedRoomCallback += UpdatePlayerList;
    }

    private void UpdatePlayerList()
    {
        foreach (PlayerItemScript item in playerItemList)
        {
            Destroy(item.gameObject);
            playerItemList.Clear();
        }

        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItemScript newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);
            
            if(player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
            }

            playerItemList.Add(newPlayerItem);
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
