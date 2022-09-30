using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public static void ResetPlayerPosition(GameObject player, Vector2 lastPos)
    {
        player.transform.position = new Vector2(lastPos.x,lastPos.y + 5);
    }
}
