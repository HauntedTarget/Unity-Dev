using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemyHitable : MonoBehaviour
{
	[SerializeField] public float enemyHealth = 100;
	[SerializeField] bool oneTime = true;
	[SerializeField] AudioClip hitNoise = null;
	[SerializeField] AudioSource soundSorce = null;
	[SerializeField] UnityEvent deathEvent = null;

	private void Start()
	{
		if (soundSorce == null) soundSorce = GameObject.Find("playerShipObject").GetComponent<AudioSource>();
	}

    private void Update()
    {
        if (deathEvent != null && enemyHealth <= 0)
        {
			deathEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
	{
		if (oneTime && other.gameObject.TryGetComponent<ProjectileAmmo>(out ProjectileAmmo pa))
		{
			soundSorce.PlayOneShot(hitNoise);
			enemyHealth -= pa.GetDamage();
			Destroy(other);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (oneTime && other.gameObject.TryGetComponent<ProjectileAmmo>(out ProjectileAmmo pa))
		{
			soundSorce.PlayOneShot(hitNoise);
			enemyHealth -= pa.GetDamage();
			Destroy(other);
		}
	}
}
