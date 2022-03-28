using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Jugador : NetworkBehaviour
{
    NetworkVariable<Vector3> posicion = new NetworkVariable<Vector3>();
    void Start()
    {
        posicion.OnValueChanged = CambioPosicion; 
    }

    private void CambioPosicion(Vector3 previousValue, Vector3 newValue)
    {
        this.transform.position = newValue;
    }

    [ServerRpc]
    public void PosicionAleatoriaServerRpc(){
        posicion.Value = GenerarPosicionAleatoria();
    }

    private Vector3 GenerarPosicionAleatoria(){
        return new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }
}
