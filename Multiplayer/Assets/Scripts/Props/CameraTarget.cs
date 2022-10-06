using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CameraTarget : MonoBehaviourPunCallbacks
{
    //Variables
    [SerializeField] private List<float> m_playerPos;
    [SerializeField] private Vector2 v_minPlayer, v_maxPlayer, v_midPos;

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
            if (player == null)
            {
                UpdateList();
                return;
            }
            m_playerPos.Add(player.transform.position.x); //Take All x Pos
        }
        //Find min num
        for (int i = 0; i < m_playerPos.Count; i++)
        {
            if (m_playerPos[i] < f_min)
            {
                f_min = m_playerPos[i];
            }
        }
        
        //Find man num
        for (int i = 0; i < m_playerPos.Count; i++)
        {
            if (m_playerPos[i] > f_max)
            {
                f_max = m_playerPos[i];
            }
        }
        
        //Pass valor
        v_maxPlayer.x = f_max;
        v_minPlayer.x = f_min;
    }

    private void FixedUpdate()
    {
        v_midPos = Vector2.Lerp(v_minPlayer, v_maxPlayer, 0.5f); //Position Mid
        transform.position = new Vector2(v_midPos.x, transform.position.y); //Pass only X
    }

    private void LateUpdate()
    {
        m_playerPos.Clear();
    }

    public void UpdateList()//Llamar cuando los player caundo empieza el game
    {
        m_currentPlayes.Clear();
        m_currentPlayes.AddRange(GameObject.FindGameObjectsWithTag("Player"));
    }
    //Players Enter and Back room

    public override void OnPlayerLeftRoom(Player otherPlayer) //Va cuando se sale
    {
        Debug.Log("Back");
        UpdateList();
    }
}
