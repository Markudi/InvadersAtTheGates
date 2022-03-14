using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGroup : MonoBehaviour
{

    
    //REFERENCE ***** https://youtu.be/qWDQgmdUzWI  - Zigurous ******

    public Enemy[] myEnemies;
    public int rows = 5;
    public int columns =  10;
    public Transform myGrid;
    

    public float speed = 1.0f;
    private Vector3 direction = Vector2.right;
    

    // Start is called before the first frame update
    void Start()
    {
        //REFERENCE ***** https://youtu.be/qWDQgmdUzWI - Zigurous ******
        for (int i = 0; i < rows; i++)
        {
            float width = 1f * (columns - 1);
            float height = 1f * (rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 myEnemyPosition = new Vector3(centering.x,centering.y + (i * 0.75f), 0.0f);
            
            for (int k = 0; k < columns; k++)
            {
                Enemy groupEnemies = Instantiate(myEnemies[i], myGrid);
                Vector3 position = myEnemyPosition;
                position.x += k * 1f;
                groupEnemies.transform.localPosition = position;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //REFERENCE ***** https://youtu.be/qWDQgmdUzWI  - Zigurous ******
        myGrid.position += direction * speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);


        foreach (Transform enemy in myGrid )
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (direction.Equals(Vector2.right) && enemy.position.x >= rightEdge.x - 1.0f)
            {
                AdvanceRow();
            }else if (direction.Equals(Vector2.left) && enemy.position.x <= leftEdge.x + 1.0f)
            {
                AdvanceRow();
            }
            
        }

        //If all enemies are killed load credits
        if (myGrid.childCount <= 0)
        {
            SceneManager.LoadScene("Credits");
        }


    }

    private void AdvanceRow()
    {
        //REFERENCE ***** https://youtu.be/qWDQgmdUzWI - Zigurous ******
        direction.x *= -1.0f;

        Vector3 position = transform.position;
        position.y -= 0.5f;
        transform.position = position;
    }
    
    
    
}
