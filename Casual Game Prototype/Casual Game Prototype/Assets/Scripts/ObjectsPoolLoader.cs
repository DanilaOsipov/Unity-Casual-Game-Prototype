using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPoolLoader : MonoBehaviour
{
    [SerializeField] private ObjectsPoolItem[] items;

    private void Start()
    {
        ObjectsPool.Initialize(items);
    }
}
