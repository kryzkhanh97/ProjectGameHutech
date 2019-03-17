using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX1 : MonoBehaviour {

    public int Health = 150;
    public AudioSource audiosrc;
    public AudioClip box;
    public Player player;
    public GameObject deatheffect;

    private void Start()
    {

        audiosrc = gameObject.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            Destroy(Instantiate(deatheffect, this.transform.position, this.transform.rotation) as GameObject, 2);
        }
    }

    void Damage(int damage)
    {
        audiosrc.PlayOneShot(box, 0.8f);
        Health -= damage;
    }
}
