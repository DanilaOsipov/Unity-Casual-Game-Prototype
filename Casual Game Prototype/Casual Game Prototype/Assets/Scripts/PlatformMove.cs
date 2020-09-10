using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float startSpeed = 2.0f;
    [SerializeField] private float endSpeed = 2.0f;
    private float speed;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_RETRY, OnGameRetry);
        Messenger.AddListener(GameEvent.CHANGE_SPEED, OnSpeedChanged);
    }

    private void Start()
    {
        speed = startSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnGameRetry()
    {
        speed = startSpeed;
    }

    private void OnSpeedChanged()
    {
        speed++;
        speed = Mathf.Clamp(speed, startSpeed, endSpeed);
    }
}
