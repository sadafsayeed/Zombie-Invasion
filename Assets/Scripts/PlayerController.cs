using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public InputAction MoveAction;
    public InputAction RotateLeftAction;
    public InputAction RotateRightAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 4.0f;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        RotateLeftAction.Enable();
        RotateRightAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        Vector2 position = (Vector2)transform.position + move * speed * Time.deltaTime;
        transform.position = position;

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }

        if (RotateRightAction.triggered)
        {
            transform.Rotate(Vector3.forward * -90f);
        }
        if(RotateLeftAction.triggered)
        {
            transform.Rotate(Vector3.forward * 90f);
        }
    }
    void FireBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
    }
}
