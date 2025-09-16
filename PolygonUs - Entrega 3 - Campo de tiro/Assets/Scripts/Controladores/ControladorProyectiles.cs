using UnityEngine;

public class ControladorProyectiles : MonoBehaviour
{
    // Declaracion de propiedades
    private float contadorTiempo;
    public float velocidad = 20f;
    private Vector3 direccion;
    // Declaracion de Metodos de Unity
    public void Start()
    {
        direccion = this.transform.forward;
        contadorTiempo = 0f;
    }

    void Update()
    {
        contadorTiempo += Time.deltaTime;
        if (contadorTiempo >= 4f)
        {
            Destroy(this.gameObject);
        }
        this.transform.position += direccion * (velocidad * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("MainCamera"))
        {
            if (other.gameObject.GetComponent<IReciboDano>() != null)
            {
                other.gameObject.GetComponent<IReciboDano>().DisminuirPVida(1);
            }
            Destroy(this.gameObject);
        }

    }
}
