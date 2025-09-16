using UnityEngine;

public class SpawnDeTrampas : MonoBehaviour
{
    //Declaracion de propiedades
    public GameObject referenciaTrampa;

    //Declaracion de Metodos
    public void spawnearTrampa(Vector3 posicionTrampa)
    {
        Instantiate(referenciaTrampa, posicionTrampa, Quaternion.Euler(0f, 0f, 0f));
    }
}
