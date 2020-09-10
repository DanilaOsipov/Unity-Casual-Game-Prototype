using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPoolItem : MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_RETRY, OnGameRetry);
    }

    private void OnGameRetry()
    {
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        ObjectsPool.AddItem(this);
    }
}
