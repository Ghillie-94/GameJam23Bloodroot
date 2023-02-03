using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    SpriteRenderer spriteRenderer;

    Rigidbody2D MyRigidbody;
   
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (IsFacingRight())
        {
            MyRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            MyRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-2.5f, transform.localScale.y);
    }

}
