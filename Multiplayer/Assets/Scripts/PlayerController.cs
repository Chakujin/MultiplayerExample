using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private PhotonView m_View;

    private const float f_speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        m_View = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_View.IsMine)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            transform.position = input.normalized * f_speed * Time.deltaTime;
        }
    }
}
