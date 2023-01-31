using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static int GridSize = 32;
    public float Speed = 1;
    public static bool IsStarted = false;
    public GameObject Food;

    public GameObject BorderBlock;

    public static GameControllerScript Singleton;
    void Start()
    {
        for( int y = 0; y <= GridSize; y++ )
        {
            GameObject newBlock = GameObject.Instantiate<GameObject>(BorderBlock);
            newBlock.transform.position = new Vector3(0, 0, y);
            newBlock = GameObject.Instantiate(BorderBlock);
            newBlock.transform.position = new Vector3(GridSize, 0, y);

            newBlock = GameObject.Instantiate(BorderBlock);
            newBlock.transform.position = new Vector3(y, 0, 0);

            newBlock = GameObject.Instantiate(BorderBlock);
            newBlock.transform.position = new Vector3(y, 0, GridSize);

            IsStarted = true;
        }

        float MiddleX = (GridSize / 2.0f);
        float MiddleZ = (GridSize / 2.0f);
        Camera.main.transform.position = new Vector3(MiddleX, 40, MiddleZ);
        Camera.main.transform.rotation = Quaternion.LookRotation( new Vector3( 0, -1, 0 ), Vector3.up );

        GenerateNewFoodPosition();

        Singleton = this;
    }
    public void GenerateNewFoodPosition()
    {
        int foodx = (int)Random.RandomRange(1, GridSize - 1);
        int foody = (int)Random.RandomRange(1, GridSize - 1);
        Food.transform.position = new Vector3(foodx, 0, -foody);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
