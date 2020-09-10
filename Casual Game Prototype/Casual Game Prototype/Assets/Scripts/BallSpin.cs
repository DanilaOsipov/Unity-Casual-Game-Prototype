using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpin : MonoBehaviour
{
    [SerializeField] private float startSpeed = 2.0f;
    [SerializeField] private float endSpeed = 10.0f;
    private float speed;
    private bool spin;
    private BallController ballController;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_STARTED, OnGameStarted);
        Messenger.AddListener(GameEvent.GAME_RETRY, OnGameRetry);
        Messenger.AddListener(GameEvent.CHANGE_SPEED, OnSpeedChanged);
        Messenger.AddListener(GameEvent.GAME_PAUSED, OnGamePaused);
        Messenger.AddListener(GameEvent.GAME_UNPAUSED, OnGameUnpaused);
        Messenger.AddListener(GameEvent.GAME_OVER, OnGameOver);
    }

    private void Start()
    {
        speed = startSpeed;

        ballController = GetComponentInParent<BallController>();
    }

    private void Update()
    {
        if (spin)
        {
            if (ballController != null)
            {
                if (ballController.IsOnLowerPlatform)
                    transform.Rotate(Vector3.back * speed);
                else
                    transform.Rotate(Vector3.forward * speed);
            }
        }
    }

    private void OnGameOver()
    {
        spin = false;
    }

    private void OnGameUnpaused()
    {
        spin = true;
    }

    private void OnGamePaused()
    {
        spin = false;
    }

    private void OnGameStarted()
    {
        spin = true;
    }

    private void OnGameRetry()
    {
        spin = true;

        speed = startSpeed;
    }

    private void OnSpeedChanged()
    {
        speed++;
        speed = Mathf.Clamp(speed, startSpeed, endSpeed);
    }
}
