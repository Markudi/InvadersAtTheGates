using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  
  //Public variables
  public GameObject bullet;
  public float speed = 7f;
  
  //Private variables
  private float axis;
  private Rigidbody2D rbody;
  public Transform shottingOffset;

  //Start
  private void Start()
  {
    rbody = GetComponent<Rigidbody2D>();
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
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
    }


    //Death
    private void OnCollisionEnter2D(Collision2D col)
    {
      if (col.gameObject.name == "EnemyBullet(Clone)")
      {
        Destroy(this.gameObject);
      }
    }
}
