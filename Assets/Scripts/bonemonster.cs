using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonemonster : MonoBehaviour
{

    public int health = 100;
    public float timer = 1, shotdelay = 0, speed = 4f;
    public Vector3 direction;

    public GameObject player;
    public GameObject bullet;
    public SoundManager sound;
    public GameObject deatheffect;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        shotdelay += Time.deltaTime;
        if (health < 0)
        {
            sound.Playsound("destroy");
            Destroy(Instantiate(deatheffect, this.transform.position, this.transform.rotation) as GameObject, 2);
            Destroy(gameObject);
        }

        transform.Translate(direction * Time.deltaTime / 0.4f);

        if (timer > 1)
        {
            timer = 0;
            newposition();

        }

        if (shotdelay >= 3)
        {
            shotdelay = 0;
            Vector3 playerdirection = player.transform.position - this.transform.position;
            playerdirection.Normalize();
            var rotationAngle = Quaternion.LookRotation(player.transform.position - transform.position);
            rotationAngle.y = 0;

            GameObject bulletclone = Instantiate(bullet, this.transform.position, rotationAngle) as GameObject;
            bulletclone.GetComponent<Rigidbody2D>().velocity = playerdirection * speed;

            Destroy(bulletclone, 4f);

        }

    }

    void Damage(int dmg)
    {
        health -= dmg;
    }
    void newposition()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);

    }
}