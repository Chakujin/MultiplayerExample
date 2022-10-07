using DG.Tweening;
using UnityEngine;

public class NormalButton : MonoBehaviour
{
    [SerializeField] private GameObject m_itemMove;
    [SerializeField] private Vector2 v_finishPosition;
    private bool b_pressed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && b_pressed == false)
        {
            m_itemMove.transform.DOMove(v_finishPosition,1f).SetEase(Ease.InQuart);
            b_pressed = true;
        }    
    }
}
