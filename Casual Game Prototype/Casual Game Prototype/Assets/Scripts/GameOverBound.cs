using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var item = other.transform.GetComponent<BallController>();
        if (item != null)
            Messenger.Broadcast(GameEvent.GAME_OVER);
    }
}
