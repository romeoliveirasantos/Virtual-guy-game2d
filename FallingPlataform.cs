using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    public float fallingTime;
    public BoxCollider2D boxcollider;
    public TargetJoint2D joint;

    void Falling()
    {
        boxcollider.enabled = false;
        joint.enabled = false;
        Destroy(gameObject, 3);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Invoke("Falling", fallingTime);
            
        }
    }
}
