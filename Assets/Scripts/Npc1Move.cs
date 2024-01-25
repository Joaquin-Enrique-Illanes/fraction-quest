using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc1Move : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    float velocity = 2;
    float distanciaCambio = 0.01f;
    byte siguientePosicion = 0;

    private void Start()
    {

    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[siguientePosicion].transform.position, velocity * Time.deltaTime);

        if (Vector3.Distance(transform.position, wayPoints[siguientePosicion].transform.position) < distanciaCambio)
        {
            siguientePosicion++;
            if (siguientePosicion >= wayPoints.Count)
            {
                siguientePosicion = 0;
            }

            // Girar 180 grados
            transform.Rotate(0, 180, 0);
        }
    }
}

