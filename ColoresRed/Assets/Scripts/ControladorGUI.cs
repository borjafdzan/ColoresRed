using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ControladorGUI : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject PrefabControladorColores;

    public void OnClickBtnCliente(){
        NetworkManager.Singleton.StartClient();
        MenuPrincipal.SetActive(false);
    }

    public void OnClickBtnServidor(){
        CrearControladorDeColores();
        NetworkManager.Singleton.StartServer();
        MenuPrincipal.SetActive(false);
    }

    public void OnClickBtnHost(){
        CrearControladorDeColores();
        NetworkManager.Singleton.StartHost();
        MenuPrincipal.SetActive(false);
    }

    public void OnClickDesconectar(){
        NetworkObject objetoRedJugadorLocal = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
        Jugador jugadorLocal = objetoRedJugadorLocal.GetComponent<Jugador>();
        jugadorLocal.AddColorListaServidorServerRpc();
        MenuPrincipal.SetActive(true);
        Invoke("Desconectar", 0.3f);
    }

    //Crear controlador de colores
    private void CrearControladorDeColores(){
        Instantiate(PrefabControladorColores, Vector3.zero, Quaternion.identity);
    }

    private void Desconectar(){
        NetworkManager.Singleton.Shutdown();
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
