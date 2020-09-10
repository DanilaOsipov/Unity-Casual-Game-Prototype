using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_STARTED, StartTime);
        Messenger.AddListener(GameEvent.GAME_PAUSED, StopTime);
        Messenger.AddListener(GameEvent.GAME_UNPAUSED, StartTime);
        Messenger.AddListener(GameEvent.GAME_OVER, StopTime);
        Messenger.AddListener(GameEvent.GAME_RETRY, StartTime);
    }

    private void Start()
    {
        StopTime();
    }

    private void StartTime()
    {
        Time.timeScale = 1;
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }
}
