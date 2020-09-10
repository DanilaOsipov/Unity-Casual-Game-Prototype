using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsEater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var item = other.transform.GetComponent<ObjectsPoolItem>();
        if (item != null)
            item.ReturnToPool();
    }
}
