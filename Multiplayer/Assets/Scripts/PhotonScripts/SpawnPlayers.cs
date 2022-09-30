using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    [SerializeField] private float f_minX, f_maxX, f_minY, f_maxY;

    private void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(f_minX, f_maxX), Random.Range(f_minY, f_maxY));
        GameObject newPlayer =  PhotonNetwork.Instantiate(playerPrefab.name,randomPos, Quaternion.identity);

        //DoorScript.UpdatePlayerTotal(newPlayer); //Add player door list total players
    }
}
