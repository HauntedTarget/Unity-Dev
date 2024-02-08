using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour, IDamagable
{
    [SerializeField, Range(0, 40)] float speed = 1;
    [SerializeField] float xClamp = 1, yClamp = 1;
    public float health = 100;
    float MAX_HEALTH;

    private void Start()
    {
        MAX_HEALTH = health;
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        Vector3 force = direction * speed * Time.deltaTime;

        transform.localPosition += force;

        float horizClamp = Mathf.Clamp(transform.localPosition.x, xClamp * -1, xClamp);
        float vertiClamp = Mathf.Clamp(transform.localPosition.y, yClamp * -1, yClamp);

        transform.localPosition = new(horizClamp, vertiClamp, transform.localPosition.z);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().OnPause();
        }

        if (health <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().OnOver();
        }
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
    }

    public void HealHealth(float healing)
    {
        health += healing;
        if (health > MAX_HEALTH + 20) { health = MAX_HEALTH + 20; }
    }
}
