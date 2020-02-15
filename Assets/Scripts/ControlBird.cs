using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBird : MonoBehaviour
{
    public float jumpForce;
    public float forwardVelocity;
    public float slerpAngleSpeed;
    private Rigidbody2D rigidBody;
    private UIManager uiManager;
    private float theta;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector2.up * jumpForce);
        }

        float newTheta = Mathf.Atan(rigidBody.velocity.y / forwardVelocity) * 180 / Mathf.PI;
        theta = Mathf.SmoothStep(theta, newTheta, slerpAngleSpeed);
        gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * theta);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
            uiManager.InstantiateRetryButton();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            ScoreManager.score += 1;
            uiManager.UpdateScore();
        }
    }
}
