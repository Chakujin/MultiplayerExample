using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private PhotonView m_View;
    public CharacterController2D controller;

    [SerializeField]private float f_speed = 4f;
    private bool b_jump = false;
    private bool b_crouch;

    private float f_horizontalMove;
    private float f_speedDir;
    public Vector2 lastPos;
    [SerializeField] private Animator m_anim;

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
            f_horizontalMove = Input.GetAxisRaw("Horizontal") * f_speed;

            if (Input.GetButtonDown("Jump") && b_jump == false)
            {
                lastPos = transform.position;
                b_jump = true;
            }

            //Animation
            f_speedDir = Mathf.Abs(f_horizontalMove);
            m_anim.SetFloat("Walk", f_speedDir);
        }
    }
    private void FixedUpdate()
    {
        //Movement
        controller.Move(f_horizontalMove * Time.fixedDeltaTime, b_crouch, b_jump);
        b_jump = false;
    }
}
