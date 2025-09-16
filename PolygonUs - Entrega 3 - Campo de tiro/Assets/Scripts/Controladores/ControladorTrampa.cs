using UnityEngine;

public class ControladorTrampa : MonoBehaviour
{
    // Declaracion de Metodos De Unity
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IReciboDano>() != null && !other.CompareTag("Player") && !other.CompareTag("MainCamera"))
        {
            print(other.gameObject.GetComponent<IReciboDano>());
            other.gameObject.GetComponent<IReciboDano>().DisminuirPVida(8);
            Destroy(this.gameObject);
        }

    }
}
