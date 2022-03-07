using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{


    public int hitsLeft = 3;

    public Sprite[] mySprites;

    private SpriteRenderer mySpriteRenderer;
    private Collider2D myCollider2D;
    
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)" || col.gameObject.name == "EnemyBullet(Clone)")
        {
            hitsLeft--;
            if (hitsLeft < 0)
            {
                myCollider2D.enabled = !myCollider2D.enabled;
                mySpriteRenderer.enabled = !mySpriteRenderer.enabled;
            }
            else
            {
                mySpriteRenderer.sprite = mySprites[hitsLeft];
            }
            
            Destroy(col.gameObject);
        }


    }
}
