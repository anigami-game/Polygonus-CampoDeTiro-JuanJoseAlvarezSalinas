using UnityEngine;

public class InputDelJugador : MonoBehaviour
{
    // Declaracion de propiedades
    private Camera camaraDelJugador;
    private CharacterController controlDelPersonaje;
    private PersonajeJugable personaje;
    public float velocidad = 6f;
    public float gravedad = 10f;
    public float velocidadMirada = 2f;
    public float limiteAnguloMirada = 45f;
    private Vector3 direccionMovimiento = Vector3.zero;
    private float rotacionX = 0;

    // Declaracion de Metodos de Unity
    public void OnEnable()
    {
        controlDelPersonaje = GetComponent<CharacterController>();
        camaraDelJugador = GetComponentInChildren<Camera>();
        personaje = GetComponent<PersonajeJugable>();
        // Bloquear y invisibilizar el mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Desplazamiento
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX =  velocidad * Input.GetAxis("Vertical");
        float curSpeedY =  velocidad * Input.GetAxis("Horizontal");
        direccionMovimiento = (forward * curSpeedX) + (right * curSpeedY);

        if (!controlDelPersonaje.isGrounded)
        {
            direccionMovimiento.y -= gravedad * Time.deltaTime;
        }

        controlDelPersonaje.Move(direccionMovimiento * Time.deltaTime);

        //Rotacion de Mirada
        rotacionX += -Input.GetAxis("Mouse Y") * velocidadMirada;
        rotacionX = Mathf.Clamp(rotacionX, -limiteAnguloMirada, limiteAnguloMirada);
        camaraDelJugador.transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * velocidadMirada, 0);

        //Activacion de habilidades
        if (Input.GetKeyUp(KeyCode.Space))
        {
            personaje.UsarHabilidad(0);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            personaje.UsarHabilidad(1);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            personaje.UsarHabilidad(2);
        }
    }
}