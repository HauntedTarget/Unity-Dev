using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupEffect = null;
    [SerializeField] AudioClip pickupNoise = null;
    [SerializeField] AudioSource soundSource = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.AddPoints(10);
        }
        Instantiate(pickupEffect, transform.position, Quaternion.identity);
        if (pickupNoise != null)
        {
            soundSource.clip = pickupNoise;
            soundSource.Play();
        }
        Destroy(this.gameObject);
    }
}
