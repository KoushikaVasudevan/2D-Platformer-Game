using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed;
    public int damage;

    private Transform target;
    private Vector3 scale;

    private void Start()
    {
        target = pointB;
        scale = transform.localScale;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 1f && (target == pointB))
        {
            target = pointA;
            scale.x = -1f * Mathf.Abs(scale.x);

            transform.localScale = scale;

            
        }
        else if (Vector2.Distance(transform.position, target.position) < 1f && (target == pointA))
        {
            target = pointB;
            scale.x = Mathf.Abs(scale.x);

            transform.localScale = scale;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            playerController.TakeDamage(damage);
        }
    }
}
