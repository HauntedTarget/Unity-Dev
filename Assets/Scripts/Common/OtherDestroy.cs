using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OtherDestroy : MonoBehaviour
{
    [SerializeField] string targetTag = null;
    [SerializeField] bool destroySelf = false;
    [SerializeField] UnityEvent destroyEvent = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            Destroy(other.gameObject);
            if (destroyEvent != null) destroyEvent.Invoke();
            if (destroySelf) Destroy(this.gameObject);
        }
    }
}
