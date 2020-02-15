using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public float moveDistance;
    private Renderer spriteRenderer;
    private bool hasBeenSeen = false;
    private float multiplier = 1;

    void Start()
    {
        spriteRenderer = GetComponent<Renderer>();
        if (transform.eulerAngles.z == 180) multiplier = -1;
    }

    void FixedUpdate()
    {
        transform.Translate(multiplier * Vector3.left * moveDistance);

        if (!hasBeenSeen && spriteRenderer.isVisible)
        {
            hasBeenSeen = true;
        }
        else if (hasBeenSeen && !spriteRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
