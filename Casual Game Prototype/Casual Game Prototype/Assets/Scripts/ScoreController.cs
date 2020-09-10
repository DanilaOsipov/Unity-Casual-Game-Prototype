using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static int Score => (int)score;
    private static float score;
    private float waitTime = 5.0f, timer;
    private bool wait;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_RETRY, OnGameRetry);
    }

    private void Update()
    {
        score += Time.deltaTime;

        timer += Time.deltaTime;
        wait = waitTime > timer;

        if (wait) return;

        if (Score > 0 && Score % 5 == 0)
        {
            Messenger.Broadcast(GameEvent.CHANGE_SPEED);
            wait = true;
            timer = 0;
        }
    }

    private void OnGameRetry()
    {
        score = 0;
        timer = 0;
        wait = false;
    }
}
