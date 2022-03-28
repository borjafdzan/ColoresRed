using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorColores : MonoBehaviour
{
    public List<Color> colores = new List<Color>(){
            new Color(0.5f, 0.3f, 0.5f),
            new Color(0.8f, 0.5f, 0.1f),
            new Color(0.2f, 0.3f, 0.9f),
            new Color(0.9f, 0.1f, 0.2f),
            /*
            new Color(0.5f, 0.3f, 0.4f),
            new Color(0.9f, 0.8f, 0.9f),
            new Color(0.3f, 0.9f, 0.1f),
            new Color(0.1f, 0.8f, 0.6f),
            new Color(0.9f, 0.3f, 0.1f),
            new Color(0.2f, 0.3f, 0.7f),
            */
   };

   public Color CambiarColorJugador(Color colorActual){
       Color colorAleatorio = this.colores[Random.Range(0, this.colores.Count)];
       this.colores.Add(colorActual);
       this.colores.Remove(colorAleatorio);
       return colorAleatorio;
   }

    //Este metodo borra un color de la lista, existe porque como el Color.Value
    //por defecto es negro siempre tendriamos una lista de 10 colores de los cuales
    //si tenemos 6 jugadores conectados 6 de esos colores de la lista seran negros
   public Color AsignarColorInicial(){
       Color colorInicial = this.colores[Random.Range(0, this.colores.Count)];
       this.colores.Remove(colorInicial);
       return colorInicial;
   }
}
