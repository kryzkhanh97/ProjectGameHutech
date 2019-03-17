using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmonster : MonoBehaviour
{

    public float lifetime = 3;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.SendMessageUpwards("Damage", 1);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
    
       

