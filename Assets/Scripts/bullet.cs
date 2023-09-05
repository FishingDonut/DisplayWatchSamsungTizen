using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D picole;
    public int speedBullet = 7;
    public Vector2 lookDirection = new Vector2(1, 0);
    public Rigidbody2D bulletClone = null;
    public Link link;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        if (!Mathf.Approximately(link.horizontal, 0f) || !Mathf.Approximately(link.vertical, 0f))
        {
            lookDirection = new(link.horizontal, link.vertical);
            lookDirection.Normalize();
        }

        if (Input.GetButtonDown("Jump"))
        {
            // Remova a declaração 'Rigidbody2' aqui.
            bulletClone = Instantiate(picole, transform.position, picole.transform.rotation);
            bulletClone.AddForce(lookDirection * speedBullet, ForceMode2D.Impulse);
            Destroy(bulletClone.gameObject, 2f);
        }


    }
}
