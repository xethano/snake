using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int Stop = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        SnakeScript.Singleton.OnCollisionEnter(collision);
    }
}
