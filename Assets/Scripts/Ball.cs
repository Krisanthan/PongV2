using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;

	}

    void ballCollisionMovement(Collider2D col)
    {
        Collider collider = GetComponent<Collider>();
        float y = whereBallHits(transform.position, col.transform.position, collider.bounds.size.y);

        Vector2 direction = new Vector2();
        if(col.gameObject.name == "Player1")
        {
            direction = new Vector2(1, y).normalized;
        }
        if(col.gameObject.name == "Player2")
        {
            direction = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = direction * speed;

        // ADD SOUND LATER
    }

    float whereBallHits(Vector2 ball, Vector2 player, float height)
    {
        return (ball.y - player.y) / height;
    }

    void onCollision(Collision2D col)
    {
        // Player 1 or 2
        if ((col.gameObject.name == "Player1" || col.gameObject.name == "Player2"))
        {

        }


        // Top or Bottom Wall
        if ((col.gameObject.name == "BottomWall" || col.gameObject.name == "TopWall"))
        {

        }


        // Left or Right Goal
        if ((col.gameObject.name == "LeftGoal" || col.gameObject.name == "RightGoal"))
        {
            transform.position = new Vector2(0, 0);
        }

    }
}
