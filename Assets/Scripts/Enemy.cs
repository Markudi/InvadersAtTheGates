using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{

    public int pointsForKill;
    public Transform shottingOffset;
    public GameObject bullet;
    public AudioClip deathSound;


    private Animator myAni;
    private Collider2D myCollider2D;
    private AudioSource myAudio;
    private static readonly int Death = Animator.StringToHash("Death");
    


    private void Start()
    {
        myAni = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
        myAudio = GetComponent<AudioSource>();
        StartCoroutine(shootBullet());
    }
    


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            //destroy bullet
            Destroy(col.gameObject);
            //disable collider
            myCollider2D.enabled = !myCollider2D.enabled;
            //update score
            ScoreManager.score += pointsForKill;
            //play death sound
            myAudio.PlayOneShot(deathSound);
            //death animation
            myAni.SetTrigger(Death);
            //destory this
            Destroy(this.gameObject, 1f);
        }
    }
    

    IEnumerator shootBullet()
    {

        float randomTime = UnityEngine.Random.Range(5, 25);
        
        yield return new WaitForSeconds(randomTime);
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

        StartCoroutine(shootBullet());
    }
    
}
