using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainObjectScript : MonoBehaviour
{
    public string nextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("Objective"))
            {
            GameManagerScript.instance.LoadLevel(nextLevel);
            }
        
    }
}
