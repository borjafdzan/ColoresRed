using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Jugador : NetworkBehaviour
{
    ControladorColores controlador;
    private Renderer renderizador;
    NetworkVariable<Vector3> posicion = new NetworkVariable<Vector3>();
    NetworkVariable<Color> colorJugador = new NetworkVariable<Color>();
    void Start()
    {
        posicion.OnValueChanged = CambioPosicion; 
        colorJugador.OnValueChanged = CambioColor;
        this.renderizador = GetComponent<Renderer>();

        //Comprobamos que siempre se asigne un material ya desde el inicio si es el
        //por defecto sera el negro y luego se cambiar si es el dueno y si no es el dueno
        //ya tendra un valor asignado en el variable del color
        this.renderizador.material.SetColor("_Color", colorJugador.Value);
        if (IsServer){
            this.controlador = GameObject.FindGameObjectWithTag("ControladorColores").GetComponent<ControladorColores>();
        }

        if (IsOwner){
            CambiarColorInicialServerRpc();
        }
    }

    private void CambioColor(Color previousValue, Color newValue)
    {
        this.renderizador.material.SetColor("_Color", newValue);
    }

    private void CambioPosicion(Vector3 previousValue, Vector3 newValue)
    {
        this.transform.position = newValue;
    }

    [ServerRpc]
    public void CambiarColorServerRpc(){
        Color colorActual = colorJugador.Value;
        colorJugador.Value = controlador.CambiarColorJugador(colorActual);
    }
    [ServerRpc]
    public void CambiarColorInicialServerRpc(){
        colorJugador.Value = controlador.AsignarColorInicial();
    }

    [ServerRpc]
    public void PosicionAleatoriaServerRpc(){
        posicion.Value = GenerarPosicionAleatoria();
    }

    private Vector3 GenerarPosicionAleatoria(){
        return new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }
}
