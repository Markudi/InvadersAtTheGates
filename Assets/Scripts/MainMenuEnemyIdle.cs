using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEnemyIdle : MonoBehaviour
{



    public GameObject[] mainMenuEnemies;
    public int rows = 5;
    public int columns = 10;
    public Transform myGrid;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < rows; i++)
        {
            float width = 1f * (columns - 1);
            float height = 1f * (rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 myEnemyPosition = new Vector3(centering.x,centering.y + (i * 0.75f), 0.0f);
            
            for (int k = 0; k < columns; k++)
            {
                var groupEnemies = Instantiate(mainMenuEnemies[i], myGrid);
                Vector3 position = myEnemyPosition;
                position.x += k * 1f;
                groupEnemies.transform.localPosition = position;
            }
        }
        
    }

}
