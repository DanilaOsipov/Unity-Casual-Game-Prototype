using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsSpawner : MonoBehaviour
{
    [SerializeField] private float minPlatformLength = 3.0f;
    [SerializeField] private float maxPlatformLength = 9.0f;
    [SerializeField] private float platformsStartVertOffset = 4.0f;
    private float platformsVertOffset;
    private Transform lastSpawned;
    private Vector3 startPos;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_RETRY, OnGameRetry);
    }

    private void Start()
    {
        platformsVertOffset = platformsStartVertOffset;

        if (!ObjectsPool.IsEmpty)
        {
            lastSpawned = ObjectsPool.GetItem().transform;

            startPos = lastSpawned.position;

            while (!ObjectsPool.IsEmpty)
                SpawnPlatform();
        }
    }

    private void Update()
    {
        if (!ObjectsPool.IsEmpty)
            SpawnPlatform();
    }

    private void OnGameRetry()
    {
        StartCoroutine(OnGameRetryCoroutine());
    }

    private IEnumerator OnGameRetryCoroutine()
    {
        yield return null;

        if (!ObjectsPool.IsEmpty)
        {
            lastSpawned = ObjectsPool.GetItem().transform;

            lastSpawned.position = startPos;

            Vector3 scale = lastSpawned.localScale;
            scale.x = maxPlatformLength;
            lastSpawned.localScale = scale;

            platformsVertOffset = platformsStartVertOffset;
        }
    }

    private void SpawnPlatform()
    {
        Transform current = ObjectsPool.GetItem().transform;

        Vector3 scale = current.localScale;
        scale.x = Random.Range(minPlatformLength, maxPlatformLength);
        current.localScale = scale;

        float offsetX = lastSpawned.localScale.x * 0.45f;

        current.position = new Vector3(lastSpawned.position.x + offsetX + current.localScale.x / 2,
                                                lastSpawned.position.y + platformsVertOffset,
                                                lastSpawned.position.z);

        platformsVertOffset = -platformsVertOffset;
        lastSpawned = current;
    }
}
