using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float speed = 5;
    public Rigidbody2D rigidbody2D;
    public Vector2 direction;
    public Vector2 spawItem = new Vector2(0, 0);
    private Camera mainCamera;
    public Inventory inventory;
    private BoxCollider2D playerCollider;
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        horizontal = Mathf.RoundToInt(horizontal);
        vertical = Mathf.RoundToInt(vertical);

        Vector2 direction = new Vector2(horizontal, vertical);
        Debug.Log(direction);
        rigidbody2D.MovePosition(rigidbody2D.position + direction * speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.J))
        {
            direction.Normalize();
            Vector2 spawItem = (Vector2)rigidbody2D.position + (Vector2.up * playerCollider.size);
            inventory.dropItem(0, spawItem);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.gameObject.CompareTag("blockObject"))
            {
                Debug.Log("colission");
                inventory.addItem(collision.gameObject);
            }
        }
    }
}
