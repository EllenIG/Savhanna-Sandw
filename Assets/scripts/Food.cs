using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private GameObject enemy;
    public float force;
    private float lifetime = 1f;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
        enemy = GameObject.FindGameObjectWithTag("enemy");
        

        Vector3 direction = transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
      
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            ScoreManager.instance.AddPoint();
            audioSource.Play();
        }

    }
}
