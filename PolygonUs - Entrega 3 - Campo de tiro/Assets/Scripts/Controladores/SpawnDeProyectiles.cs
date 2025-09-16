using UnityEngine;

public class SpawnDeProyectiles : MonoBehaviour
{
    //Declaracion de propiedades
    public GameObject referenciaProyectil;

    //Declaracion de Metodos
    public void spawnearProyectil(Vector3 posicionProyectil, Quaternion direccionProyectil)
    {
        Instantiate(referenciaProyectil, posicionProyectil, direccionProyectil);
    }
}
