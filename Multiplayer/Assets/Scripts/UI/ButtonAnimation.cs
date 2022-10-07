using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform myTrans;

    public void OnPointerEnter(PointerEventData data)
    {
        AnimateButton();
    }

    public void OnPointerExit(PointerEventData deta)
    {
        DOTween.KillAll();
        myTrans.localScale = new Vector3(1,1,1);
    }

    private void AnimateButton()
    {
        myTrans.localScale = new Vector3(1,1,1);
        myTrans.DOScale(1.25f,0.5f).SetLoops(2,LoopType.Yoyo).OnComplete(AnimateButton);
    }
}
