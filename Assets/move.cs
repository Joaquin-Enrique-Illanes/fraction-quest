using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform objetivo; // El objeto hacia donde se mueve
    public float velocidad = 5f;
    public float distanciaUmbral = 0.1f;

    void Update()
    {
        // Calcula la dirección hacia el objetivo
        Vector3 direccion = objetivo.position - transform.position;

        // Calcula la distancia al objetivo
        float distanciaAlObjetivo = direccion.magnitude;

        // Si la distancia es mayor que la distancia umbral, mueve el objeto
        if (distanciaAlObjetivo > distanciaUmbral)
        {
            direccion.Normalize();
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
        else
        {
            Debug.Log("Objeto ha llegado al objetivo.");
        }
    }
}
