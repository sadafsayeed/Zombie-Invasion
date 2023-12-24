using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public int damage = 1;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        ZombiesController zombie = collision.gameObject.GetComponent<ZombiesController>();

        if (zombie != null)
        {
            zombie.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
