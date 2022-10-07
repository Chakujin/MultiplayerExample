using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData")]
public class PlayerItemData : ScriptableObject
{
    public RuntimeAnimatorController animator;
    public Sprite selectionImage;
}
