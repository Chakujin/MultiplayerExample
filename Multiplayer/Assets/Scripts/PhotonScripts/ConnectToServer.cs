using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TMP_InputField usuarnameInput;
    public TMP_Text buttonText;

    // Start is called before the first frame update
    public void OnClickConnect()
    {
        if( usuarnameInput.text.Length >= 1)
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayRandomPitch("Button");
            PhotonNetwork.NickName = usuarnameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}
