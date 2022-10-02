using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationStartEnd : MonoBehaviour
{
    [SerializeField] private GameObject m_endSphere;

    private void Start() 
    {
        StartSceneAnim();
    }
    
    private void OnEnable() 
    {
        DieButton.RestartSceneCallback += EndSceneAnim;    
    }

    private void StartSceneAnim()
    {

    }

    private void EndSceneAnim()
    {
        //Animate Sprite sphere
    }
}
