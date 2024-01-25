using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldMan : MonoBehaviour
{

    [SerializeField] private GameObject dialogoMark;
    [SerializeField] private GameObject dialogoBackground;


    public int npcPregunta;
    private ArrayList suma;
    private ArrayList multi;
    private ArrayList divi;
    private DialogoBackground texto;
    private bool isPlayerNear;
    private int actual;

    private void Awake()
    {
        npcPregunta = PlayerPrefs.GetInt("valor", 0);
        suma = new ArrayList();
        suma.Add("¡Hola aventurero!");
        suma.Add("En esta ocasión vamos a sumar fracciones.");
        suma.Add("Cuando sumamos fracciones, simplemente combinamos partes de algo.");
        suma.Add("Imagina que tienes una pizza, ¿puedes sumar las porciones?");
        suma.Add("Ejemplo: Tienes 1/4 de pizza y luego tomas otros 1/4. ¿Cuánta pizza tienes ahora?");
        suma.Add("Puedes sumar los numeradores (1 + 1) y dejar el denominador igual (4).");
        suma.Add("¡La respuesta es 2/4 o 1/2!");
        suma.Add("Si tienes problemas, recuerda encontrar un denominador común y luego sumar los numeradores. ¡Buena suerte!");

        suma.Add("¡Vamos a restar fracciones!");
        suma.Add("Restar es como quitar piezas de algo. Imagina que tienes una barra de chocolate y decides compartir, ¿puedes restar las porciones?");
        suma.Add("Ejemplo: Tienes 3/4 de tu chocolate y decides comer 1/4. ¿Cuánto chocolate te queda?");
        suma.Add("Resta los numeradores (3 - 1) y deja el denominador igual (4).");
        suma.Add("¡La respuesta es 2/4 o 1/2!");
        suma.Add("Si te sientes confundido, recuerda que restar fracciones es como restar números normales, solo necesitas un denominador común. ¡Sigue intentándolo!");

        multi = new ArrayList();
        multi.Add("¡Bienvenido a la siguiente etapa!");
        multi.Add("Esta vez, vamos a multiplicar fracciones.");
        multi.Add("Ejemplo: Imagina que tienes 1/3 de una barra de chocolate, y decides compartir eso con 2 amigos igualmente. ¿Cuánto chocolate obtiene cada amigo?");
        multi.Add("Multiplica los numeradores (1 * 1) y los denominadores (3 * 2).");
        multi.Add("¡La respuesta es 1/6 para cada amigo!");
        multi.Add("¡Recuerda, multiplicar fracciones es simplemente multiplicar los numeradores y luego los denominadores! ¡Tú puedes hacerlo!");

        divi = new ArrayList();
        divi.Add("¡Vamos a explorar la división de fracciones! ¿Listo para dividir y conquistar?");
        divi.Add("Ejemplo: Si tienes 2/3 de una pizza y quieres dividirlo en partes iguales para 3 amigos, ¿cuánta pizza obtiene cada amigo?");
        divi.Add("Primero tienes que intercambiar el numerador con el denominador de la fracción que está dividiendo.");
        divi.Add("Simplemente multiplica los numeradores (2 * 1) y los denominadores (3 * 3).");
        divi.Add("¡La respuesta es 2/9 para cada amigo!");
        divi.Add("¡No te preocupes si al principio parece complicado!");
        divi.Add("La división de fracciones es como multiplicar, solo que necesitas invertir la segunda fracción. ¡Tú puedes hacerlo!");

        texto = dialogoBackground.GetComponent<DialogoBackground>();
        actual = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Cambiartexto();
        }
        if (isPlayerNear == false)
        {
            dialogoBackground.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;
            dialogoMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;
            dialogoMark.SetActive(false);
        }
    }

    public void Cambiartexto()
    {
        actual += 1;
        if ( npcPregunta < 1)
        {
            if (actual >= 0 && actual < suma.Count)
            {
                texto.modificarTexto(suma[actual].ToString());
                dialogoBackground.SetActive(true);
            }
            else
            {
                dialogoBackground.SetActive(false);
                actual = -1;
            }
        }
        if (npcPregunta == 1)
        {
            if (actual >= 0 && actual < multi.Count)
            {
                texto.modificarTexto(multi[actual].ToString());
                dialogoBackground.SetActive(true);
            }
            else
            {
                dialogoBackground.SetActive(false);
                actual = -1;
            }
        }
        if (npcPregunta == 2)
        {
            if (actual >= 0 && actual < divi.Count)
            {
                texto.modificarTexto(divi[actual].ToString());
                dialogoBackground.SetActive(true);
            }
            else
            {
                dialogoBackground.SetActive(false);
                actual = -1;
            }
        }
    }
}
