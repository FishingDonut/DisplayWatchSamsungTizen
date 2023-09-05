using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Link link;
    public Rigidbody2D rigidbody2D;
    public int speed = 4;
    public int speedDead = 6;
    public Vector2 direction;
    public bool dead = false;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (!dead)
        {
            Vector2 direction = link.rigidbody2D.position - rigidbody2D.position;
            direction.Normalize();

            rigidbody2D.MovePosition(rigidbody2D.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    public void ConfigEnemy(Link link, int speed)
    {
        this.link = link;
        this.speed = speed;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            dead = true;

            direction = -link.rigidbody2D.position;
            direction.Normalize();
            rigidbody2D.AddForce(direction * speedDead, ForceMode2D.Impulse);

            Destroy(other.gameObject);
            Destroy(gameObject, 1f);
        }
    }
}
