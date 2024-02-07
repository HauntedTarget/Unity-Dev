using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
	[SerializeField] float damage = 1;
	[SerializeField] bool oneTime = true;
	[SerializeField] AudioClip hitNoise = null;
	[SerializeField] AudioSource soundSorce = null;

    private void Start()
    {
		if (soundSorce == null) soundSorce = GameObject.Find("playerShipObject").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
	{
		if (oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
		{
			soundSorce.PlayOneShot(hitNoise);
			damagable.ApplyDamage(damage);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
		{
			soundSorce.PlayOneShot(hitNoise);
			damagable.ApplyDamage(damage * Time.deltaTime);
		}
	}
}


public interface IDamagable
{
	void ApplyDamage(float damage);
}