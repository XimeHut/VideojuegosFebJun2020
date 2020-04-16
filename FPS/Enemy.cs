using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy; //El objeto que persigue.
    public GameObject track; //El que va ser perseguido. (En este caso es el FPS)
    //Estas variables son publicas para que se modifiquen dependiendo de las caractersisticas que quieran que tenga su enemigo
    //Recomendamos : MaxDist: 20
                   //MinDist:  5
                   //velocity : 0.05
    public float MaxDist = 20f; //Es la distancia en la que te empieza a seguir * te sigue en un radio de 20 a 5 *
    public float MinDist = 5f; //Es la distancia hasta la que se te pega.
    public float velocity = 0.05f;//Es la velocidad a la que te sigue 

    private Vector3 EnemyPos;
    private Vector3 TrackPos;
    private float Distancia;
    

    public void EnemyMovement()
    {
        EnemyPos = enemy.transform.position;// Es la posicion del enemigo
        TrackPos = track.transform.position; //Es la posicion de a quien se le va seguir (En este caso es el FPS)

        Distancia = Vector3.Distance(EnemyPos, TrackPos); //Distancia entre ellos 

        Debug.Log(Distancia);

        if (Distancia >= MinDist && Distancia <= MaxDist)
        {
            enemy.transform.position = Vector3.MoveTowards(EnemyPos, TrackPos, velocity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
}