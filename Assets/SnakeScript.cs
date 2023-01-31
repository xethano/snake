using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    int DirX = 0;
    int DirY = 0;
    float LocX;
    float LocY;
    float Speed = 0.01f;
    float LastLocX;
    float LastLocY;

    public static SnakeScript Singleton;

    bool IsStarted = false;
    void LateStart()
    {
        LocX = GameControllerScript.GridSize / 2.0f;
        LocY = GameControllerScript.GridSize / 2.0f;
        DirX = 1;
        DirY = 0;
        LastLocX = LocX;
        LastLocY = LocY;
        transform.position = new Vector3(LocX, 0, -LocY);

        Singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        if( !IsStarted )
        {
            if( !GameControllerScript.IsStarted )
            {
                return;
            }
            LateStart();
            IsStarted = true;
        }

        LocX += Speed * DirX;
        LocY += Speed * DirY;
        transform.position = new Vector3(LocX, 0, -LocY);

        // only allow player to change direction when snake has moved over a certain distance from
        // the last point
        float deltaX = LocX - LastLocX;
        float deltaY = LocY - LastLocY;
        float fDist = Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);
        if( fDist > 1.0f )
        {
            CheckKeys();
        }
    }

    void CheckKeys( )
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if( Input.GetKey(KeyCode.RightArrow ) )
        {
            DirX = 1;
            DirY = 0;
        }
        if( Input.GetKey(KeyCode.DownArrow))
        {
            DirX = 0;
            DirY = 1;
        }
        if( Input.GetKey(KeyCode.LeftArrow))
        {
            DirX = -1;
            DirY = 0;
        }
        if( Input.GetKey(KeyCode.UpArrow))
        {
            DirX = 0;
            DirY = -1;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if( collision.collider.tag == "NonEdible" )
        {
            // you're dead.
        }
        else
        {
            // grow the snake?
            GameControllerScript.Singleton.GenerateNewFoodPosition();
        }
    }

}
