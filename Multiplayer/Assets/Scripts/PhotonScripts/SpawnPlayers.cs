using System.Collections;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    //Variables
    public GameObject[] playerPrefab;
    [SerializeField] private CameraTarget m_cameraTarget;

    [SerializeField] private float f_minX, f_maxX, f_minY, f_maxY;

    private void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(f_minX, f_maxX), Random.Range(f_minY, f_maxY));
        GameObject playerToSpawn = playerPrefab[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name,randomPos, Quaternion.identity);
        StartCoroutine(AddPlayers());
    }

    private IEnumerator AddPlayers()
    {
        yield return new WaitForSeconds(1f);
        m_cameraTarget.UpdateList();
    }
}
