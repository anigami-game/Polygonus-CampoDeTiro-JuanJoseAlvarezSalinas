using UnityEngine;

public class ControladorCampoDeDano : MonoBehaviour
{
    //Declaracion de propiedades
    private float contadorTiempo = 0f;
    // Declaracion de Metodos De Unity
    void OnTriggerStay(Collider other)
    {
        contadorTiempo += Time.deltaTime;
        if (contadorTiempo >= 1f)
        {
            if (other.gameObject.GetComponent<IReciboDano>() != null)
            {
                print(other.gameObject.GetComponent<IReciboDano>());
                other.gameObject.GetComponent<IReciboDano>().DisminuirPVida(1);
            }
            contadorTiempo -= 1f;
        }

    }
}
