using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float startGravity;
    private bool invertGravity;
    private CharacterController characterController;
    private bool hit;
    private Vector3 startPos;
    private float gravity;

    public bool IsOnLowerPlatform { get; private set; }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_RETRY, OnGameRetry);
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        startPos = transform.position;
        gravity = startGravity;
    }

    private void Update()
    {
        IsOnLowerPlatform = Physics.Raycast(transform.position, Vector3.down, 1.2f * (characterController.height / 2));

        if (!invertGravity && Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject())
            StartCoroutine(InvertGravity());

        Vector3 motion = new Vector3(0, gravity, 0) * Time.deltaTime;

        characterController.Move(motion);
    }

    private void OnGameRetry()
    {
        StartCoroutine(OnGameRetryCoroutine());
    }

    private IEnumerator OnGameRetryCoroutine()
    {
        hit = false;
        invertGravity = false;
        gravity = startGravity;

        yield return null;

        characterController.enabled = false;

        transform.position = startPos;

        characterController.enabled = true;
    }

    private IEnumerator InvertGravity()
    {
        invertGravity = true;

        gravity = -gravity;

        while (!hit)
        {
            hit = Physics.Raycast(transform.position, 
                                  gravity > 0 ? Vector3.up : Vector3.down, 
                                  1.2f * (characterController.height / 2));

            yield return null;
        }

        hit = false;

        invertGravity = false;
    }
}
