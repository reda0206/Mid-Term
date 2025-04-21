using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Transform groundCheck;

    public LayerMask groundLayers;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayers);

        if(!hit.collider)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 localScalePlaceholder = transform.localScale;

        localScalePlaceholder.x *= -1;

        transform.localScale = localScalePlaceholder;

        moveSpeed *= -1;
    }
}
