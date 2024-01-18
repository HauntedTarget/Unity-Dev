using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 5;
    [SerializeField] bool constDam = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!constDam && other.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.Damage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (constDam && other.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.Damage(damage * Time.deltaTime);
        }
    }
}
