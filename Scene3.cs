using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // chama metodo que passa de fase
            SceneManager.LoadScene("Scene4");
        }
    }
}

