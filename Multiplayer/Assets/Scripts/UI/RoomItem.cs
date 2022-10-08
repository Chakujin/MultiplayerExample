using UnityEngine;
using TMPro;

public class RoomItem : MonoBehaviour
{
    [SerializeField] private TMP_Text roomName;
    private LobbyManager m_lobby;

    private void Start()
    {
        m_lobby = GameObject.FindGameObjectWithTag("LobbyManager").GetComponent<LobbyManager>();
    }
    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }

    public void OnClickItem()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayRandomPitch("Button");
        m_lobby.JoinRoom(roomName.text);
    }
}
