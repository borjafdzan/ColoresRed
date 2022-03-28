using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ControladorGUI : MonoBehaviour
{
    public GameObject MenuPrincipal;

    public void OnClickBtnCliente(){
        NetworkManager.Singleton.StartClient();
        MenuPrincipal.SetActive(false);
    }

    public void OnClickBtnServidor(){
        NetworkManager.Singleton.StartServer();
        MenuPrincipal.SetActive(false);
    }

    public void OnClickBtnHost(){
        NetworkManager.Singleton.StartHost();
        MenuPrincipal.SetActive(false);
    }

    public void PeticionCambiarPosicion(){
        NetworkObject objetoRedJugador = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
        Jugador jugadorLocal = objetoRedJugador.GetComponent<Jugador>();
        jugadorLocal.PosicionAleatoriaServerRpc();
    }

    public void PeticionCambiarColor(){
        NetworkObject objetoRedJugador = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
        Jugador jugadorLocal = objetoRedJugador.GetComponent<Jugador>();
        jugadorLocal.CambiarColorServerRpc();
    }
}
