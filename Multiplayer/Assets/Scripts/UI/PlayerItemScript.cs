using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerItemScript : MonoBehaviourPunCallbacks
{
    //Player settings only canvas
    public TMP_Text playerName;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Color highlightColor;
    [SerializeField] private GameObject LeftArrow;
    [SerializeField] private GameObject RigthArrow;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    
    [SerializeField] private Image playerAvatar;
    [SerializeField] private PlayerItemData[] avatarsData;

    private Player m_player;

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName; //Current name to player
        m_player = _player; //Pass local data player
        UpdatePlayerInfo(_player); //Update
    }

    public void ApplyLocalChanges()
    {
        backgroundImage.color = highlightColor;
        LeftArrow.SetActive(true);
        RigthArrow.SetActive(true);
    }

    public void OnClickLeftArrow()
    {
        if ((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = avatarsData.Length - 1;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }

        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void OnClicRigthtArrow()
    {
        if ((int)playerProperties["playerAvatar"] == avatarsData.Length - 1)
        {
            playerProperties["playerAvatar"] = 0;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }

        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(m_player == targetPlayer)
        {
            UpdatePlayerInfo(targetPlayer);
        }
    }

    private void UpdatePlayerInfo(Player player)
    {
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            playerAvatar.sprite = avatarsData[(int)player.CustomProperties["playerAvatar"]].selectionImage; // Put image selection
            playerProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
        }
        else
        {
            playerProperties["playerAvatar"] = 0;
        }
    }
}
