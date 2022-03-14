using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  
  //Public variables
  public GameObject bullet;
  public float speed = 7f;
  public Transform shottingOffset;

  public AudioClip shootSound;
  public AudioClip deathSound;
  
  //Private variables
  private float axis;
  private Rigidbody2D rbody;
  private Animator myAni;
  private Collider2D myCollider2D;
  private AudioSource myAudio;
  private static readonly int Death = Animator.StringToHash("Death");

  //Start
  private void Start()
  {
    rbody = GetComponent<Rigidbody2D>();
    myAni = GetComponent<Animator>();
    myCollider2D = GetComponent<Collider2D>();
    myAudio = GetComponent<AudioSource>();
  }

  // Update is called once per frame
    void Update()
    {


      //Player movemement
      axis = Input.GetAxis("Horizontal");
      float xMovement = axis * speed;
      rbody.velocity = new Vector2(xMovement, 0f);


      
      //Shooting
      if (Input.GetKeyDown(KeyCode.Space))
      {
        // bullet
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        
        //play shooting sound
        myAudio.PlayOneShot(shootSound);
        
        // Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.name == "EnemyBullet(Clone)")
      {
        
        //destroy bullet
        Destroy(col.gameObject);
        
        //disable collider
        myCollider2D.enabled = !myCollider2D.enabled;
        
        //play death animation
        myAni.SetTrigger(Death);
        
        //play death sound
        myAudio.PlayOneShot(deathSound);
        
        //load credits scene 2 seconds after death
        Invoke("LoadCredits", 2f);
      }
    }

    

    
    public void LoadCredits()
    {
      SceneManager.LoadScene("Credits");
    }
}
