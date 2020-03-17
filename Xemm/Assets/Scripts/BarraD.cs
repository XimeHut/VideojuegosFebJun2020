using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraD : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            //vida--;
            //if (vida == 0)
            Destroy(collision.gameObject);

            Debug.Log("Juego Terminado");
        }
    }
}
