using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CameraTarget : MonoBehaviourPunCallbacks
{
    //Variables
    [SerializeField] private List<float> playerPos;
    [SerializeField] private Vector2 minPlayer, maxPlayer, midPos;

    private float f_min;
    private float f_max;

    //Player
    [SerializeField]private List<GameObject> m_currentPlayes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        UpdateList();

        f_min = transform.position.x;
        f_max = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Reset position
        f_min = transform.position.x;
        f_max = transform.position.x;

        //Calculate all time min pos player and max pos
        foreach (GameObject player in m_currentPlayes)
        {
            playerPos.Add(player.transform.position.x); //Take All x Pos
        }
        //Find min num
        for (int i = 0; i < playerPos.Count; i++)
        {
            if (playerPos[i] < f_min)
            {
                Debug.Log("SetMin");
                f_min = playerPos[i];
            }
        }

        //Find man num
        for (int i = 0; i < playerPos.Count; i++)
        {
            if (playerPos[i] > f_max)
            {
                Debug.Log("SetMax");
                f_max = playerPos[i];
            }
        }
        //Pass valor
        maxPlayer.x = f_max;
        minPlayer.x = f_min;
    }

    private void FixedUpdate()
    {
        midPos = Vector2.Lerp(minPlayer, maxPlayer, 0.5f); //Position Mid
        transform.position = new Vector2(midPos.x, transform.position.y); //Pass only X
    }

    private void LateUpdate()
    {
        playerPos.Clear();
    }

    public void UpdateList()
    {
        m_currentPlayes.AddRange(GameObject.FindGameObjectsWithTag("Player"));
    }
    //Players Enter and Back room
}
