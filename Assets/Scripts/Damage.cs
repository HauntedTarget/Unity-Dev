using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
    [SerializeField] bool isTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTrigger && other.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.OnDeath();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isTrigger && other.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.OnDeath();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
