using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 1f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
        }
        myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);


    }

    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(0.15f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == 5)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRoutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CoinScript coin = collision.GetComponent<CoinScript>();

        print($"coin != null : {coin != null}");

        if (coin != null)
        {
            coin.Hit();
        }


    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
