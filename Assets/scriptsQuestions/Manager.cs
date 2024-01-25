using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Dictionary<string, ProblemaMatematico> problemas = new Dictionary<string, ProblemaMatematico>();
    //-------------------------------------------------------------------------------------------------------------
    public Dictionary<string, RespuestasAlAzar> respuestasMalas = new Dictionary<string, RespuestasAlAzar>();


    public TextMeshProUGUI textoPregunta;
    public string textoRespuestaCorrecta;
    public int indiceATM;
    //-------------------------------------------------------------------------
    public TextMeshProUGUI respuestaText;
    public TextMeshProUGUI respuestaText2;
    public TextMeshProUGUI respuestaText3;
    public TextMeshProUGUI respuestaText4;
    //---------------------------------------------------------------------------
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "preguntas")
        {
            // Preguntas de Suma con el Mismo Denominador
            problemas.Add("problema1", new ProblemaMatematico("¿Cuánto es 1/3 + 2/3?", "3/3"));
            problemas.Add("problema2", new ProblemaMatematico("Si tienes 2/5 de un pastel y luego agregas 3/5 más, ¿cuánto pastel tienes ahora?", "5/5"));
            problemas.Add("problema3", new ProblemaMatematico("¿Cuánto es 4/7 + 1/7?", "5/7"));
            problemas.Add("problema4", new ProblemaMatematico("Imagina que tienes 3/8 de un juguete. Si alguien te da 1/8 más, ¿cuánto juguete tienes en total?", "4/8"));
            problemas.Add("problema5", new ProblemaMatematico("Tienes 5/6 de una piscina. Luego, añades 1/6 más. ¿Cuánta agua tienes ahora?", "6/6"));
            problemas.Add("problema6", new ProblemaMatematico("Si tienes 1/2 de una torta y luego agregas 1/2 más, ¿cuánta torta tienes en total?", "2/2"));
            //problemas.Add("problema7", new ProblemaMatematico("Imagina que tienes 3/4 de un parque para perros. Si otro perro se une y ocupa 1/4 del parque, ¿cuánto espacio queda libre?", "2/4"));
            problemas.Add("problema7", new ProblemaMatematico("Si tienes 2/3 de un videojuego y luego obtienes 1/3 más como regalo, ¿cuánto del juego tienes ahora?", "3/3"));
            problemas.Add("problema8", new ProblemaMatematico("¿Cuánto es 5/9 + 2/9?", "7/9"));
            problemas.Add("problema9", new ProblemaMatematico("Tienes 4/5 de una canasta de frutas. Después, agregas 1/5 más. ¿Cuánta fruta hay en la canasta ahora?", "5/5"));

            // Preguntas de Resta con el Mismo Denominador
            problemas.Add("problema11", new ProblemaMatematico("Si tienes 2/4 de una pizza y le das a tu amigo 1/4, ¿cuánta pizza te queda?", "1/4"));
            problemas.Add("problema12", new ProblemaMatematico("¿Cuánto es 3/5 - 1/5?", "2/5"));
            problemas.Add("problema13", new ProblemaMatematico("Imagina que tienes 4/6 de caramelos. Si comes 2/6, ¿cuántos caramelos te quedan?", "2/6"));
            problemas.Add("problema14", new ProblemaMatematico("Si tienes 5/8 de una barra de chocolate y decides compartir 3/8, ¿cuánto chocolate te queda?", "2/8"));
            problemas.Add("problema15", new ProblemaMatematico("Tienes 6/7 de un libro. Después de leer 1/7, ¿cuánto del libro te queda por leer?", "5/7"));
            problemas.Add("problema16", new ProblemaMatematico("Si tienes 3/6 de una barra de chocolate y decides comer 2/6, ¿cuánto chocolate te queda?", "1/6"));
            //problemas.Add("problema17", new ProblemaMatematico("Imagina que tienes 4/7 de tus deberes terminados. Si decides tomarte un descanso y no haces 1/7, ¿cuántos deberes te quedan por hacer?", "3/7"));
            problemas.Add("problema17", new ProblemaMatematico("Si tienes 2/4 de una pizza y decides compartir 1/4 con tu hermano, ¿cuánta pizza le das a tu hermano?", "1/4"));
            problemas.Add("problema18", new ProblemaMatematico("¿Cuánto es 6/8 - 2/8?", "4/8"));
            problemas.Add("problema19", new ProblemaMatematico("Tienes 5/6 de una hoja de papel y decides arrancar 3/6 para hacer una nota. ¿Cuánta hoja de papel te queda?", "2/6"));

            //// Agrega respuestas matemáticos al Dictionary.-------------------
            respuestasMalas.Add("respuestamala1", new RespuestasAlAzar("1/8"));
            respuestasMalas.Add("respuestamala2", new RespuestasAlAzar("3/16"));
            respuestasMalas.Add("respuestamala3", new RespuestasAlAzar("2/7"));
            respuestasMalas.Add("respuestamala4", new RespuestasAlAzar("5/12"));
            respuestasMalas.Add("respuestamala5", new RespuestasAlAzar("7/14"));
            respuestasMalas.Add("respuestamala6", new RespuestasAlAzar("1/5"));
            respuestasMalas.Add("respuestamala7", new RespuestasAlAzar("4/9"));
            respuestasMalas.Add("respuestamala8", new RespuestasAlAzar("6/11"));
            respuestasMalas.Add("respuestamala9", new RespuestasAlAzar("3/10"));
            respuestasMalas.Add("respuestamala10", new RespuestasAlAzar("2/6"));
            // Respuestas Incorrectas adicionales para Preguntas de Suma y Resta con el Mismo Denominador
            respuestasMalas.Add("respuestamala11", new RespuestasAlAzar("5/7"));
            respuestasMalas.Add("respuestamala12", new RespuestasAlAzar("2/3"));
            respuestasMalas.Add("respuestamala13", new RespuestasAlAzar("4/8"));
            respuestasMalas.Add("respuestamala14", new RespuestasAlAzar("1/6"));
            respuestasMalas.Add("respuestamala15", new RespuestasAlAzar("3/4"));
            respuestasMalas.Add("respuestamala16", new RespuestasAlAzar("7/9"));
            respuestasMalas.Add("respuestamala17", new RespuestasAlAzar("6/10"));
            respuestasMalas.Add("respuestamala18", new RespuestasAlAzar("4/7"));
            respuestasMalas.Add("respuestamala19", new RespuestasAlAzar("5/8"));
            respuestasMalas.Add("respuestamala20", new RespuestasAlAzar("2/5"));


            nextQ();
        }
        else if (SceneManager.GetActiveScene().name == "preguntas2")
        {

            // Preguntas de Multiplicación de Fracciones (Faciles)
            problemas.Add("problema1", new ProblemaMatematico("¿Cuánto es 1/3 * 2/5?", "2/15"));
            problemas.Add("problema2", new ProblemaMatematico("Si tienes 1/2 de una pizza y la divides en 3 partes iguales, ¿cuánta pizza es cada parte?", "1/6"));
            problemas.Add("problema3", new ProblemaMatematico("¿Cuánto es 3/4 * 1/2?", "3/8"));
            problemas.Add("problema4", new ProblemaMatematico("Si tienes 2/3 de una barra de chocolate y decides compartirlo en mitades, ¿cuánto chocolate tiene cada mitad?", "1/3"));
            problemas.Add("problema5", new ProblemaMatematico("Tienes 3/5 de una caja de juguetes. Si decides regalar la mitad de eso, ¿cuántos juguetes regalas?", "3/10"));
            problemas.Add("problema6", new ProblemaMatematico("¿Cuánto es 2/7 * 5/6?", "10/42"));
            problemas.Add("problema7", new ProblemaMatematico("Imagina que tienes 1/4 de una canasta de frutas y decides duplicarlo. ¿Cuánta canasta de frutas tienes ahora?", "1/2"));
            problemas.Add("problema8", new ProblemaMatematico("Si compras 2/3 de un álbum de pegatinas y decides darle 1/3 a tu amigo, ¿cuánto del álbum le das a tu amigo?", "2/9"));
            problemas.Add("problema9", new ProblemaMatematico("¿Cuánto es 4/5 * 3/4?", "12/20"));
            problemas.Add("problema10", new ProblemaMatematico("Tienes 2/3 de un jardín plantado con flores y decides plantar 1/2 más. ¿Cuánto del jardín está plantado ahora?", "3/6"));
            problemas.Add("problema11", new ProblemaMatematico("¿Cuánto es 2/5 * 4/7?", "8/35"));
            problemas.Add("problema12", new ProblemaMatematico("Si tienes 3/4 de un paquete de pegatinas y decides dividirlo igualmente entre 2 amigos, ¿cuánto recibe cada amigo?", "3/8"));
            problemas.Add("problema13", new ProblemaMatematico("Imagina que tienes 2/3 de una pecera llena de peces y decides vender 1/3 de ellos. ¿Cuántos peces vendes?", "2/9"));
            problemas.Add("problema14", new ProblemaMatematico("Si tienes 1/2 de un cuaderno y decides doblar esa cantidad, ¿cuánto cuaderno tienes ahora?", "1"));
            problemas.Add("problema15", new ProblemaMatematico("¿Cuánto es 3/8 * 2/5?", "6/40"));
            problemas.Add("problema16", new ProblemaMatematico("Tienes 4/5 de una pizza y decides cortarla en 4 porciones iguales. ¿Cuánto representa cada porción?", "1/5"));
            problemas.Add("problema17", new ProblemaMatematico("¿Cuánto es 2/3 * 3/4?", "6/12"));
            problemas.Add("problema18", new ProblemaMatematico("Si tienes 1/6 de una bolsa de caramelos y decides compartirlo en 2 partes iguales, ¿cuánto caramelo tiene cada parte?", "1/12"));
            problemas.Add("problema19", new ProblemaMatematico("Imagina que tienes 2/4 de una mochila llena de libros y decides tomar 1/2 de ellos. ¿Cuántos libros tomas?", "1/4"));
            problemas.Add("problema20", new ProblemaMatematico("¿Cuánto es 3/7 * 4/5?", "12/35"));




            //// Agrega respuestas matemáticos al Dictionary.-------------------
            respuestasMalas.Add("respuestamala1", new RespuestasAlAzar("1/8"));
            respuestasMalas.Add("respuestamala2", new RespuestasAlAzar("3/16"));
            respuestasMalas.Add("respuestamala3", new RespuestasAlAzar("2/7"));
            respuestasMalas.Add("respuestamala4", new RespuestasAlAzar("5/12"));
            respuestasMalas.Add("respuestamala5", new RespuestasAlAzar("7/14"));
            respuestasMalas.Add("respuestamala6", new RespuestasAlAzar("1/5"));
            respuestasMalas.Add("respuestamala7", new RespuestasAlAzar("4/9"));
            respuestasMalas.Add("respuestamala8", new RespuestasAlAzar("6/11"));
            respuestasMalas.Add("respuestamala9", new RespuestasAlAzar("3/10"));
            respuestasMalas.Add("respuestamala10", new RespuestasAlAzar("2/6"));
            // Respuestas Incorrectas adicionales para Preguntas de Suma y Resta con el Mismo Denominador
            respuestasMalas.Add("respuestamala11", new RespuestasAlAzar("5/7"));
            respuestasMalas.Add("respuestamala12", new RespuestasAlAzar("2/3"));
            respuestasMalas.Add("respuestamala13", new RespuestasAlAzar("4/8"));
            respuestasMalas.Add("respuestamala14", new RespuestasAlAzar("1/6"));
            respuestasMalas.Add("respuestamala15", new RespuestasAlAzar("3/4"));
            respuestasMalas.Add("respuestamala16", new RespuestasAlAzar("7/9"));
            respuestasMalas.Add("respuestamala17", new RespuestasAlAzar("6/10"));
            respuestasMalas.Add("respuestamala18", new RespuestasAlAzar("4/7"));
            respuestasMalas.Add("respuestamala19", new RespuestasAlAzar("5/8"));
            respuestasMalas.Add("respuestamala20", new RespuestasAlAzar("2/5"));

            nextQ();
        }
        else if (SceneManager.GetActiveScene().name == "preguntas3")
        {
            // Preguntas de División de Fracciones (Fáciles)
            problemas.Add("problema1", new ProblemaMatematico("¿Cuánto es 1/2 ÷ 1/4?", "2/1"));
            problemas.Add("problema2", new ProblemaMatematico("Si tienes 3/4 de una pizza y decides compartirla en mitades, ¿cuánta pizza tiene cada mitad?", "3/8"));
            problemas.Add("problema3", new ProblemaMatematico("¿Cuánto es 2/3 ÷ 1/3?", "2/1"));
            problemas.Add("problema4", new ProblemaMatematico("Tienes 5/6 de una barra de chocolate y decides dividirla en tres partes iguales. ¿Cuánta chocolate tiene cada parte?", "5/18"));
            problemas.Add("problema5", new ProblemaMatematico("Imagina que tienes 2/5 de un recipiente de caramelos y decides repartirlo en 5 partes iguales. ¿Cuánta fracción representa cada parte?", "2/25"));
            problemas.Add("problema6", new ProblemaMatematico("¿Cuánto es 3/4 ÷ 1/2?", "3/2"));
            problemas.Add("problema7", new ProblemaMatematico("Si tienes 1/3 de un acuario lleno de peces y decides separarlo en 2 partes iguales, ¿cuánta fracción representa cada parte?", "1/6"));
            problemas.Add("problema8", new ProblemaMatematico("Tienes 4/5 de una caja de juguetes. Si decides dividirlo en 4 partes iguales, ¿cuánta fracción representa cada parte?", "1/5"));
            problemas.Add("problema9", new ProblemaMatematico("¿Cuánto es 5/6 ÷ 1/3?", "5/2"));
            problemas.Add("problema10", new ProblemaMatematico("Imagina que tienes 2/3 de un jardín plantado con flores y decides dividirlo en 3 secciones iguales. ¿Cuánta fracción representa cada sección?", "2/9"));
            problemas.Add("problema11", new ProblemaMatematico("¿Cuánto es 4/7 ÷ 2/7?", "2/1"));
            problemas.Add("problema12", new ProblemaMatematico("Si tienes 3/4 de una caja de lápices y decides dividirla en 2 partes iguales, ¿cuánta lápices hay en cada parte?", "3/8"));
            problemas.Add("problema13", new ProblemaMatematico("Tienes 2/3 de un paquete de pegatinas. Si decides dividirlo en 3 partes iguales, ¿cuánta fracción representa cada parte?", "2/9"));
            problemas.Add("problema14", new ProblemaMatematico("¿Cuánto es 1/2 ÷ 1/3?", "3/2"));
            problemas.Add("problema15", new ProblemaMatematico("Si compras 3/4 de una bolsa de golosinas y decides dividirla en 4 partes iguales, ¿cuánta fracción representa cada parte?", "3/16"));
            problemas.Add("problema16", new ProblemaMatematico("¿Cuánto es 2/5 ÷ 1/4?", "8/5"));
            problemas.Add("problema17", new ProblemaMatematico("Tienes 5/6 de un estante lleno de libros y decides dividirlo en 2 partes iguales. ¿Cuánta fracción representa cada parte?", "5/12"));
            problemas.Add("problema18", new ProblemaMatematico("¿Cuánto es 3/4 ÷ 1/4?", "3/1"));
            problemas.Add("problema19", new ProblemaMatematico("Imagina que tienes 4/5 de una caja de herramientas y decides dividirlo en 5 partes iguales. ¿Cuánta fracción representa cada parte?", "4/25"));
            problemas.Add("problema20", new ProblemaMatematico("¿Cuánto es 2/3 ÷ 1/6?", "4/1"));


            //// Agrega respuestas matemáticos al Dictionary.-------------------
            respuestasMalas.Add("respuestamala1", new RespuestasAlAzar("1/8"));
            respuestasMalas.Add("respuestamala2", new RespuestasAlAzar("3/16"));
            respuestasMalas.Add("respuestamala3", new RespuestasAlAzar("2/7"));
            respuestasMalas.Add("respuestamala4", new RespuestasAlAzar("5/12"));
            respuestasMalas.Add("respuestamala5", new RespuestasAlAzar("7/14"));
            respuestasMalas.Add("respuestamala6", new RespuestasAlAzar("1/5"));
            respuestasMalas.Add("respuestamala7", new RespuestasAlAzar("4/9"));
            respuestasMalas.Add("respuestamala8", new RespuestasAlAzar("6/11"));
            respuestasMalas.Add("respuestamala9", new RespuestasAlAzar("3/10"));
            respuestasMalas.Add("respuestamala10", new RespuestasAlAzar("2/6"));
            // Respuestas Incorrectas adicionales para Preguntas de Suma y Resta con el Mismo Denominador
            respuestasMalas.Add("respuestamala11", new RespuestasAlAzar("5/7"));
            respuestasMalas.Add("respuestamala12", new RespuestasAlAzar("2/3"));
            respuestasMalas.Add("respuestamala13", new RespuestasAlAzar("4/8"));
            respuestasMalas.Add("respuestamala14", new RespuestasAlAzar("1/6"));
            respuestasMalas.Add("respuestamala15", new RespuestasAlAzar("3/4"));
            respuestasMalas.Add("respuestamala16", new RespuestasAlAzar("7/9"));
            respuestasMalas.Add("respuestamala17", new RespuestasAlAzar("6/10"));
            respuestasMalas.Add("respuestamala18", new RespuestasAlAzar("4/7"));
            respuestasMalas.Add("respuestamala19", new RespuestasAlAzar("5/8"));
            respuestasMalas.Add("respuestamala20", new RespuestasAlAzar("2/5"));
            nextQ();
        }
        else if (SceneManager.GetActiveScene().name == "preguntas4")
        {
            // Preguntas de Suma de Fracciones (Difíciles)
            problemas.Add("problema1", new ProblemaMatematico("¿Cuánto es 3/4 + 5/6?", "19/12"));
            problemas.Add("problema2", new ProblemaMatematico("Si tienes 2/3 de una pizza y alguien más tiene 4/5 de otra pizza, ¿cuánta pizza tienen en total?", "22/15"));
            problemas.Add("problema3", new ProblemaMatematico("¿Cuánto es 7/8 + 2/3?", "29/24"));
            problemas.Add("problema4", new ProblemaMatematico("Imagina que tienes 5/6 de un estanque lleno de peces. Si se escapan 1/3 de los peces, ¿cuánta fracción queda en el estanque?", "5/18"));
            problemas.Add("problema5", new ProblemaMatematico("Tienes 2/3 de una barra de chocolate y decides compartir la mitad con tu amigo. Si tu amigo también tiene 1/4 de otra barra de chocolate, ¿cuánta fracción de chocolate tienen en total?", "17/12"));
            problemas.Add("problema6", new ProblemaMatematico("¿Cuánto es 3/5 + 4/7?", "41/35"));
            problemas.Add("problema7", new ProblemaMatematico("Si tienes 1/4 de un tanque de gasolina y decides agregar 3/8 más, ¿cuánta gasolina tienes ahora en fracción?", "5/8"));
            problemas.Add("problema8", new ProblemaMatematico("Tienes 3/7 de una caja de juguetes y decides agregar 2/3 más. ¿Cuánta fracción de la caja está llena ahora?", "23/21"));
            problemas.Add("problema9", new ProblemaMatematico("¿Cuánto es 5/9 + 2/5?", "67/45"));
            problemas.Add("problema10", new ProblemaMatematico("Imagina que tienes 4/5 de una botella de jugo y decides mezclarlo con 3/4 de otra botella de jugo diferente. ¿Cuánta fracción de jugo mezclado tienes en total?", "31/20"));

            // Preguntas de Resta de Fracciones (Difíciles)
            problemas.Add("problema11", new ProblemaMatematico("¿Cuánto es 7/8 - 3/4?", "1/8"));
            problemas.Add("problema12", new ProblemaMatematico("Si tienes 5/6 de una barra de chocolate y decides restarle 1/3, ¿cuánta fracción de chocolate te queda?", "5/18"));
            problemas.Add("problema13", new ProblemaMatematico("¿Cuánto es 4/5 - 2/3?", "2/15"));
            problemas.Add("problema14", new ProblemaMatematico("Tienes 2/3 de un estanque lleno de peces y decides vender 1/4 de los peces. ¿Cuánta fracción de peces te queda en el estanque?", "5/12"));
            problemas.Add("problema15", new ProblemaMatematico("Imagina que tienes 3/4 de una pizza y decides darle 2/5 a tu amigo. ¿Cuánta fracción de pizza te queda?", "7/20"));
            problemas.Add("problema16", new ProblemaMatematico("¿Cuánto es 5/6 - 1/2?", "1/3"));
            problemas.Add("problema17", new ProblemaMatematico("Si tienes 2/5 de un pastel y decides quitarle 1/3, ¿cuánta fracción de pastel queda?", "1/15"));
            problemas.Add("problema18", new ProblemaMatematico("Tienes 3/7 de una caja de juguetes y decides restarle 1/3. ¿Cuánta fracción de la caja queda ahora?", "2/21"));
            problemas.Add("problema19", new ProblemaMatematico("¿Cuánto es 5/9 - 2/5?", "17/45"));
            problemas.Add("problema20", new ProblemaMatematico("Imagina que tienes 4/5 de una botella de jugo y decides restarle 3/4 de otra botella de jugo diferente. ¿Cuánta fracción de jugo te queda?", "1/20"));


            //// Agrega respuestas matemáticos al Dictionary.-------------------
            respuestasMalas.Add("respuestamala1", new RespuestasAlAzar("1/24"));
            respuestasMalas.Add("respuestamala2", new RespuestasAlAzar("3/16"));
            respuestasMalas.Add("respuestamala3", new RespuestasAlAzar("2/33"));
            respuestasMalas.Add("respuestamala4", new RespuestasAlAzar("5/12"));
            respuestasMalas.Add("respuestamala5", new RespuestasAlAzar("7/14"));
            respuestasMalas.Add("respuestamala6", new RespuestasAlAzar("1/43"));
            respuestasMalas.Add("respuestamala7", new RespuestasAlAzar("4/15"));
            respuestasMalas.Add("respuestamala8", new RespuestasAlAzar("6/18"));
            respuestasMalas.Add("respuestamala9", new RespuestasAlAzar("3/10"));
            respuestasMalas.Add("respuestamala10", new RespuestasAlAzar("2/34"));
            // Respuestas Incorrectas adicionales para Preguntas de Suma y Resta con el Mismo Denominador
            respuestasMalas.Add("respuestamala11", new RespuestasAlAzar("5/32"));
            respuestasMalas.Add("respuestamala12", new RespuestasAlAzar("2/30"));
            respuestasMalas.Add("respuestamala13", new RespuestasAlAzar("4/21"));
            respuestasMalas.Add("respuestamala14", new RespuestasAlAzar("1/22"));
            respuestasMalas.Add("respuestamala15", new RespuestasAlAzar("3/24"));
            respuestasMalas.Add("respuestamala16", new RespuestasAlAzar("7/49"));
            respuestasMalas.Add("respuestamala17", new RespuestasAlAzar("6/10"));
            respuestasMalas.Add("respuestamala18", new RespuestasAlAzar("4/87"));
            respuestasMalas.Add("respuestamala19", new RespuestasAlAzar("5/12"));
            respuestasMalas.Add("respuestamala20", new RespuestasAlAzar("2/33"));
            nextQ();
        }
        else if (SceneManager.GetActiveScene().name == "preguntas5")
        {
            // Preguntas de Multiplicación de Fracciones (Difíciles)
            problemas.Add("problema1", new ProblemaMatematico("¿Cuánto es 3/4 * 5/6?", "15/24"));
            problemas.Add("problema2", new ProblemaMatematico("Si tienes 2/3 de un estanque lleno de peces y decides vender 1/4 de ellos, ¿cuántos peces vendes?", "2/12"));
            problemas.Add("problema3", new ProblemaMatematico("¿Cuánto es 4/5 * 7/8?", "28/40"));
            problemas.Add("problema4", new ProblemaMatematico("Tienes 5/6 de una jarra de agua y decides verter 1/3 en cada vaso. ¿Cuánto representa cada vaso?", "5/18"));
            problemas.Add("problema5", new ProblemaMatematico("Imagina que tienes 2/5 de una granja plantada con maíz y decides sembrar 2/3 de esa área con tomates. ¿Cuánta área queda sin plantar?", "2/15"));
            problemas.Add("problema6", new ProblemaMatematico("¿Cuánto es 1/2 * 3/4 * 2/3?", "3/12"));
            problemas.Add("problema7", new ProblemaMatematico("Si tienes 3/7 de un conjunto de juguetes y decides regalar 2/5 de ellos, ¿cuántos juguetes regalas?", "6/35"));
            problemas.Add("problema8", new ProblemaMatematico("Tienes 4/9 de un recipiente lleno de bolas de helado y decides vender 2/3 de ellas. ¿Cuántas bolas de helado vendes?", "8/27"));
            problemas.Add("problema9", new ProblemaMatematico("¿Cuánto es 5/8 * 1/2?", "5/16"));
            problemas.Add("problema10", new ProblemaMatematico("Imagina que tienes 1/3 de un campo de fútbol y decides sembrar 3/4 de esa área con flores. ¿Cuánta área queda sin flores?", "1/4"));
            problemas.Add("problema11", new ProblemaMatematico("¿Cuánto es 2/3 * 4/5 * 3/4?", "24/60"));
            problemas.Add("problema12", new ProblemaMatematico("Si tienes 2/5 de una caja de lápices y decides distribuir 1/2 de ellos en igual cantidad a tus amigos, ¿cuántos lápices le das a cada amigo?", "1/5"));
            problemas.Add("problema13", new ProblemaMatematico("Tienes 3/4 de una pila de libros y decides dividirla en 2 partes iguales. ¿Cuánta fracción representa cada parte?", "3/8"));
            problemas.Add("problema14", new ProblemaMatematico("Si compras 2/3 de una bolsa de golosinas y decides darle 3/4 a tu hermana, ¿cuánto le das a tu hermana?", "1/2"));
            problemas.Add("problema15", new ProblemaMatematico("¿Cuánto es 3/5 * 2/3?", "6/15"));
            problemas.Add("problema16", new ProblemaMatematico("Imagina que tienes 1/4 de un tanque de gasolina y decides llenar 2/3 de tu coche. ¿Cuánto tanque queda sin usar?", "1/6"));
            problemas.Add("problema17", new ProblemaMatematico("Si tienes 5/6 de una batería y decides usar 2/3 de su energía, ¿cuánta energía utilizas?", "5/9"));
            problemas.Add("problema18", new ProblemaMatematico("Tienes 4/7 de una reserva de agua y decides distribuir 3/5 de ella a las plantas. ¿Cuánta agua distribuyes?", "12/35"));
            problemas.Add("problema19", new ProblemaMatematico("¿Cuánto es 3/4 * 1/3 * 2/5?", "6/60"));
            problemas.Add("problema20", new ProblemaMatematico("Si tienes 2/5 de una caja de chocolates y decides comer 3/4 de lo que tienes, ¿cuántos chocolates te quedan?", "3/10"));


            //// Agrega respuestas matemáticos al Dictionary.-------------------
            respuestasMalas.Add("respuestamala1", new RespuestasAlAzar("1/23"));
            respuestasMalas.Add("respuestamala2", new RespuestasAlAzar("3/16"));
            respuestasMalas.Add("respuestamala3", new RespuestasAlAzar("2/57"));
            respuestasMalas.Add("respuestamala4", new RespuestasAlAzar("5/12"));
            respuestasMalas.Add("respuestamala5", new RespuestasAlAzar("7/14"));
            respuestasMalas.Add("respuestamala6", new RespuestasAlAzar("1/56"));
            respuestasMalas.Add("respuestamala7", new RespuestasAlAzar("4/29"));
            respuestasMalas.Add("respuestamala8", new RespuestasAlAzar("6/11"));
            respuestasMalas.Add("respuestamala9", new RespuestasAlAzar("3/10"));
            respuestasMalas.Add("respuestamala10", new RespuestasAlAzar("2/6"));
            // Respuestas Incorrectas adicionales para Preguntas de Suma y Resta con el Mismo Denominador
            respuestasMalas.Add("respuestamala11", new RespuestasAlAzar("5/17"));
            respuestasMalas.Add("respuestamala12", new RespuestasAlAzar("2/32"));
            respuestasMalas.Add("respuestamala13", new RespuestasAlAzar("4/48"));
            respuestasMalas.Add("respuestamala14", new RespuestasAlAzar("1/26"));
            respuestasMalas.Add("respuestamala15", new RespuestasAlAzar("3/14"));
            respuestasMalas.Add("respuestamala16", new RespuestasAlAzar("7/39"));
            respuestasMalas.Add("respuestamala17", new RespuestasAlAzar("6/10"));
            respuestasMalas.Add("respuestamala18", new RespuestasAlAzar("4/17"));
            respuestasMalas.Add("respuestamala19", new RespuestasAlAzar("5/48"));
            respuestasMalas.Add("respuestamala20", new RespuestasAlAzar("2/52"));

            nextQ();
        }
        else if (SceneManager.GetActiveScene().name == "preguntas6")
        {
            // Preguntas de División de Fracciones (Difíciles)
            problemas.Add("problema1", new ProblemaMatematico("¿Cuánto es 3/4 ÷ 2/3?", "9/8"));
            problemas.Add("problema2", new ProblemaMatematico("Si tienes 2/3 de una barra de chocolate y decides dividirla en 5 partes iguales, ¿cuánta chocolate tiene cada parte?", "2/15"));
            problemas.Add("problema3", new ProblemaMatematico("¿Cuánto es 4/5 ÷ 1/2?", "8/5"));
            problemas.Add("problema4", new ProblemaMatematico("Tienes 5/6 de una jarra de agua y decides dividirla en 4 partes iguales. ¿Cuánta representa cada parte?", "5/24"));
            problemas.Add("problema5", new ProblemaMatematico("Imagina que tienes 2/5 de un tanque de gasolina y decides usar 1/3 de lo que tienes. ¿Cuánta gasolina utilizas?", "2/15"));
            problemas.Add("problema6", new ProblemaMatematico("¿Cuánto es 3/4 ÷ 1/2 ÷ 2/3?", "3/4"));
            problemas.Add("problema7", new ProblemaMatematico("Si tienes 1/3 de un acuario lleno de peces y decides dividirlo en 3 partes iguales, ¿cuánta representa cada parte?", "1/9"));
            problemas.Add("problema8", new ProblemaMatematico("Tienes 4/5 de una caja de juguetes. Si decides dividirla en 2 partes iguales, ¿cuánta fracción representa cada parte?", "2/5"));
            problemas.Add("problema9", new ProblemaMatematico("¿Cuánto es 5/6 ÷ 2/3?", "5/4"));
            problemas.Add("problema10", new ProblemaMatematico("Imagina que tienes 2/3 de un jardín plantado con flores y decides dividirlo en 4 secciones iguales. ¿Cuánta representa cada sección?", "1/6"));
            problemas.Add("problema11", new ProblemaMatematico("¿Cuánto es 4/7 ÷ 2/7 ÷ 1/2?", "2/1"));
            problemas.Add("problema12", new ProblemaMatematico("Si tienes 3/4 de una caja de lápices y decides dividirla en 3 partes iguales, ¿cuánta lápices hay en cada parte?", "1/4"));
            problemas.Add("problema13", new ProblemaMatematico("Tienes 2/3 de un paquete de pegatinas. Si decides dividirlo en 2 partes iguales, ¿cuánta representa cada parte?", "1/3"));
            problemas.Add("problema14", new ProblemaMatematico("¿Cuánto es 1/2 ÷ 1/3 ÷ 2/3?", "3/1"));
            problemas.Add("problema15", new ProblemaMatematico("Si compras 3/4 de una bolsa de golosinas y decides dividirla en 3 partes iguales, ¿cuánta fracción representa cada parte?", "1/4"));
            problemas.Add("problema16", new ProblemaMatematico("¿Cuánto es 2/5 ÷ 1/4 ÷ 3/2?", "16/15"));
            problemas.Add("problema17", new ProblemaMatematico("Tienes 5/6 de un estante lleno de libros y decides dividirlo en 3 partes iguales. ¿Cuánta fracción representa cada parte?", "5/18"));
            problemas.Add("problema18", new ProblemaMatematico("¿Cuánto es 3/4 ÷ 1/4 ÷ 2/3?", "3/2"));
            problemas.Add("problema19", new ProblemaMatematico("Imagina que tienes 4/5 de una caja de herramientas y decides dividirlo en 3 partes iguales. ¿Cuánta representa cada parte?", "4/15"));
            problemas.Add("problema20", new ProblemaMatematico("¿Cuánto es 2/3 ÷ 1/6 ÷ 1/2?", "4/1"));


            //// Agrega respuestas matemáticos al Dictionary.-------------------
            respuestasMalas.Add("respuestamala1", new RespuestasAlAzar("1/28"));
            respuestasMalas.Add("respuestamala2", new RespuestasAlAzar("3/16"));
            respuestasMalas.Add("respuestamala3", new RespuestasAlAzar("2/17"));
            respuestasMalas.Add("respuestamala4", new RespuestasAlAzar("5/12"));
            respuestasMalas.Add("respuestamala5", new RespuestasAlAzar("7/14"));
            respuestasMalas.Add("respuestamala6", new RespuestasAlAzar("1/55"));
            respuestasMalas.Add("respuestamala7", new RespuestasAlAzar("4/29"));
            respuestasMalas.Add("respuestamala8", new RespuestasAlAzar("6/11"));
            respuestasMalas.Add("respuestamala9", new RespuestasAlAzar("3/10"));
            respuestasMalas.Add("respuestamala10", new RespuestasAlAzar("2/16"));
            // Respuestas Incorrectas adicionales para Preguntas de Suma y Resta con el Mismo Denominador
            respuestasMalas.Add("respuestamala11", new RespuestasAlAzar("5/27"));
            respuestasMalas.Add("respuestamala12", new RespuestasAlAzar("2/30"));
            respuestasMalas.Add("respuestamala13", new RespuestasAlAzar("4/28"));
            respuestasMalas.Add("respuestamala14", new RespuestasAlAzar("1/56"));
            respuestasMalas.Add("respuestamala15", new RespuestasAlAzar("3/48"));
            respuestasMalas.Add("respuestamala16", new RespuestasAlAzar("7/59"));
            respuestasMalas.Add("respuestamala17", new RespuestasAlAzar("6/10"));
            respuestasMalas.Add("respuestamala18", new RespuestasAlAzar("4/17"));
            respuestasMalas.Add("respuestamala19", new RespuestasAlAzar("5/28"));
            respuestasMalas.Add("respuestamala20", new RespuestasAlAzar("2/35"));

            nextQ();
        }
    }

    public void nextQ()
    {
        // Luego, selecciona un problema al azar.
        string problemaAleatorio = SeleccionarProblemaAlAzar();
        indiceATM = GenerarNumeroAleatorio(1, 3);
        MostrarProblemaEnPanel(problemaAleatorio);
        //--------------------------------------------------------------------
        InsertarTexto(indiceATM, problemaAleatorio);
    }
    string SeleccionarProblemaAlAzar()
    {
        // Convierte las claves del Dictionary en una lista.
        List<string> claves = new List<string>(problemas.Keys);

        // Selecciona una clave al azar.
        int indiceAleatorio = Random.Range(0, claves.Count);
        string claveSeleccionada = claves[indiceAleatorio];

        return claveSeleccionada;
    }

    string SeleccionarRespuestaMalaAlAzar()
    {
        // Convierte las claves del Dictionary en una lista.
        List<string> claves = new List<string>(respuestasMalas.Keys);

        // Selecciona una clave al azar.
        int indiceAleatorio = Random.Range(0, claves.Count);
        string claveSeleccionada = claves[indiceAleatorio];

        return claveSeleccionada;
    }

    int GenerarNumeroAleatorio(int min, int max)
    {
        // Crea una instancia de Random.
        System.Random random = new System.Random();

        // Genera un número aleatorio en el rango especificado.
        return random.Next(min, max);
    }

    void MostrarProblemaEnPanel(string claveProblema)
    {
        // Obtén el problema seleccionado.
        ProblemaMatematico problema = problemas[claveProblema];

        // Asigna la pregunta y la respuesta a los objetos Text en tu panel.
        textoPregunta.text = problema.pregunta;
        textoRespuestaCorrecta = problema.respuesta;
    }

    void InsertarTexto(int claveIndice, string claveProblemaF)
    {
        ProblemaMatematico problema = problemas[claveProblemaF];

        if (claveIndice == 1)
        {
            respuestaText.text = problema.respuesta;
        }
        else
        {
            string respuestaAlatoria = SeleccionarRespuestaMalaAlAzar();
            RespuestasAlAzar respuestaMala1 = respuestasMalas[respuestaAlatoria];
            if (respuestaMala1.respuestaX.Equals(problema.respuesta))
            {
                respuestaText.text = "Ninguna de las anteriores";
            }
            respuestaText.text = respuestaMala1.respuestaX;
        }
        if (claveIndice == 2)
        {
            respuestaText2.text = problema.respuesta;
        }
        else
        {
            string respuestaAlatoria = SeleccionarRespuestaMalaAlAzar();
            RespuestasAlAzar respuestaMala2 = respuestasMalas[respuestaAlatoria];
            if (respuestaMala2.respuestaX.Equals(problema.respuesta))
            {
                respuestaText2.text = "Ninguna de las anteriores";
            }
            else
            {
                respuestaText2.text = respuestaMala2.respuestaX;
            }
        }
        if (claveIndice == 3)
        {
            respuestaText3.text = problema.respuesta;
        }
        else
        {
            string respuestaAlatoria = SeleccionarRespuestaMalaAlAzar();
            RespuestasAlAzar respuestaMala3 = respuestasMalas[respuestaAlatoria];
            if (respuestaMala3.respuestaX.Equals(problema.respuesta))
            {
                respuestaText3.text = "Ninguna de las anteriores";
            }
            else
            {
                respuestaText3.text = respuestaMala3.respuestaX;
            }
        }
        if (claveIndice == 4)
        {
            respuestaText4.text = problema.respuesta;
        }
        else
        {
            string respuestaAlatoria = SeleccionarRespuestaMalaAlAzar();
            RespuestasAlAzar respuestaMala4 = respuestasMalas[respuestaAlatoria];
            if (respuestaMala4.respuestaX.Equals(problema.respuesta))
            {
                respuestaText4.text = "Ninguna de las anteriores";
            }
            else
            {
                respuestaText4.text = respuestaMala4.respuestaX;
            }
        }

    }
}
