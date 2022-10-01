using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    //Components
    private PhotonView m_View;
    public CharacterController2D controller;
    private Rigidbody2D m_rb;
    [SerializeField] private SpriteRenderer m_myMesh;
    [SerializeField] private BoxCollider2D[] m_myCol;
    [SerializeField] private Animator m_anim;

    //Movement
    private const float f_speed = 70f;
    private bool b_jump = false;
    private bool b_crouch;
    private bool b_move = true;
    private float f_horizontalMove;
    private float f_speedDir;
    public Vector2 lastPos;

    //Detect Players
    [SerializeField] private Transform m_detectPos;
    [SerializeField] private LayerMask m_playerLayer;
    [SerializeField] private Vector2 f_sizeDetector;
    private bool b_havePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        m_View = GetComponent<PhotonView>();
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_View.IsMine && b_move == true)
        {
            f_horizontalMove = Input.GetAxisRaw("Horizontal") * f_speed; //Move axis

            if (Input.GetButtonDown("Jump") && b_jump == false && b_havePlayer == false)
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
        b_havePlayer = false;

        //Detect if I have a player on top of me 
        Collider2D[] detectPlayers = Physics2D.OverlapBoxAll(m_detectPos.position, f_sizeDetector, 0, m_playerLayer);

        foreach(Collider2D player in detectPlayers)
        {
            //If detect player cant jump
            b_havePlayer = true;
        }
    }

    public void DoorEnter()
    {
        m_myMesh.enabled = false;
        b_move = false;

        m_rb.bodyType = RigidbodyType2D.Static; //Enable gravity
        
        foreach(BoxCollider2D col in m_myCol)
        {
            col.enabled = false; //Enable collisions
        }
    }

    private void OnDrawGizmos() 
    {
            Gizmos.DrawCube(m_detectPos.position, f_sizeDetector);
    }
}
