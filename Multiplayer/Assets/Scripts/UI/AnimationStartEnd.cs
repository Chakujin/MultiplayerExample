using UnityEngine;
using DG.Tweening;

public class AnimationStartEnd : MonoBehaviour
{
    [SerializeField] private RectTransform m_endSphere;
    [SerializeField] private RectTransform m_startPos;
    [SerializeField] private RectTransform m_endPos;

    private void Start() 
    {
        StartSceneAnim();
    }
    
    private void OnEnable() 
    {
        DieButton.RestartSceneCallback += EndSceneAnim; //EndAmi,
    }

    private void StartSceneAnim()
    {
        m_endSphere.gameObject.SetActive(true);
        m_endSphere.DOMoveX(m_startPos.position.x, 0f); //ResetPos
        m_endSphere.DOMoveX(m_endPos.position.x, 3f).OnComplete(() => m_endSphere.gameObject.SetActive(false)); //Move
    }

    private void EndSceneAnim()
    {
        m_endSphere.gameObject.SetActive(true);
        m_endSphere.DOMoveX(-m_endPos.position.x, 0f); //ResetPos
        m_endSphere.DOMoveX(m_startPos.position.x, 3f); //Move
    }
}
