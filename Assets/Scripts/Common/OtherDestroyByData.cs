using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OtherDestroyByData : MonoBehaviour
{
    [SerializeField] string targetTag = null;
    [SerializeField] List<string> targetData;
    [SerializeField] bool destroySelf = false;
    [SerializeField] UnityEvent destroyEvent = null;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var dataStep in targetData)
        {
            try
            {
                if (other.gameObject.tag == targetTag && other.gameObject.GetComponent<objectData>().CheckExistance(dataStep))
                {
                    Destroy(other.gameObject);
                    if (destroyEvent != null) destroyEvent.Invoke();
                    if (destroySelf) Destroy(this.gameObject);
                }
            }
            catch (Exception)
            {
                Debug.Log("Target (" + other.name + ") doesn't have an objectData component.");
            }
        }
    }
}
