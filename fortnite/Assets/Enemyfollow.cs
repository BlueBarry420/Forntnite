using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemyfollow : MonoBehaviour
{
    public float speed = 1.0f;
     Transform target;
    public int Health = 100;
    public GameObject Enemy;
     GameObject Spawner;


    // Update is called once per frame

    private void Start()
    {
        Spawner = GameObject.Find("Spawns"); 
        target = GameObject.Find("Player").transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Player")
        {
            collision.transform.GetComponent<PlayerMovement>().Health -= 15;
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target.position);
        if(Health<=0)
        {
            GetComponent<Animation>().Play();
            GetComponent<Enemyfollow>().enabled = false;
            for (int i = 0; i < 2; i++)
            {
                GameObject NewEnemy = Instantiate(Enemy);
                NewEnemy.transform.position = Spawner.transform.GetChild(Random.Range(0, Spawner.transform.childCount)).position;
                NewEnemy.GetComponent<Enemyfollow>().Health = 100;
                NewEnemy.GetComponent<Enemyfollow>().enabled = true;
            }

        }
    }
}