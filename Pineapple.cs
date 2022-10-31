using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //adiciona um abacaxi ao inventario e destroi o objeto
            collision.GetComponent<Player>().IncreaseScore();
            Destroy(gameObject);
        }
    }
}
