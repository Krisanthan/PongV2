using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;

	}

    void ballCollisionMovement(Collision2D col)
    {
        Collider collider = GetComponent<Collider>();
        float y = whereBallHits(transform.position, col.transform.position, col.collider.bounds.size.y);

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
        // If the LeftPaddle or RightPaddle hit the
        // ball simulate the ricochet
        if ((col.gameObject.name == "Player1") || (col.gameObject.name == "Player2"))
        {
            ballCollisionMovement(col);
        }

        // WallBottom or WallTop
        if ((col.gameObject.name == "BottomWall") || (col.gameObject.name == "TopWall"))
        {

        }

        // LeftGoal or RightGoal
        if ((col.gameObject.name == "LeftGoal") || (col.gameObject.name == "RightGoal"))
        {

            gameObject.transform.position = new Vector2(0, 0);

        }

    }

    void uIScoreUpdate(string UItext)
    {
        var UIComp = GameObject.Find(UItext).GetComponent<Text>();
        int score = int.Parse(UIComp.text);
        score++;

        UIComp.text = score.ToString();
    }
}
