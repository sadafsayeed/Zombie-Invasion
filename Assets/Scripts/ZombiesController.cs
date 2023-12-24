using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombiesController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2d;
    public int health = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody2d.position;
        position.y = position.y - (speed * Time.deltaTime);
        rigidbody2d.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Background back = collision.gameObject.GetComponent<Background>();
        if (back != null)
        {
            back.ChangeHealth(-1);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health == 0)
        {
            Destroy(gameObject);

        }
    }

    
}
