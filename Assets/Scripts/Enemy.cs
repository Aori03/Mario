using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int count;
    public float speed;
    public Vector3[] position;

    private int currentTarget;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, position[currentTarget], speed);
        if(transform.position == position[currentTarget])
        {
            if(currentTarget < position.Length - 1)
            {
                currentTarget++;
            }
            else
            {
                currentTarget = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Игрок убит");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerContoller>().AddCoin(count);
            Debug.Log("Враг убит");
            Destroy(gameObject);
        }
    }
}
