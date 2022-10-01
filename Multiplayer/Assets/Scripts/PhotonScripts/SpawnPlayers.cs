using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    [SerializeField] private float f_minX, f_maxX, f_minY, f_maxY;

    private void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(f_minX, f_maxX), Random.Range(f_minY, f_maxY));
        PhotonNetwork.Instantiate(playerPrefab.name,randomPos, Quaternion.identity);
    }
}
