using UnityEngine;

public class Trampero : PersonajeJugable
{
    [SerializeField] protected GameObject spawnerDeTrampa;

    // Constructor(s)
    public Trampero()
    {
        this.nombre = "Trampero";
        this.maxPuntosDeVida = 10;
        this.maxPuntosDeMana = 0;
        this.validarNumero = true;

    }

    // Declaracion de Metodos
    public override void UsarHabilidad(int numeroHabilidad)
    {
        base.UsarHabilidad(numeroHabilidad);
        if (validarNumero == true)
        {
            int puntosRequeridos = inventarioDeHabilidades[numeroHabilidad].ObtenerPuntosRequeridosParaActivar();
            bool estaListaHabilidad = inventarioDeHabilidades[numeroHabilidad].ObtenerEstaListo();
            if (puntosRequeridos <= puntosDeVida && estaListaHabilidad == true)
            {
                puntosDeVida -= puntosRequeridos;
                if (this.gameObject.CompareTag("Player")) { ControladorUI.instance.ActualizarVida(puntosDeVida); }
                Vector3 posicionJugador = GetComponent<Transform>().position;
                Quaternion direccionJugador = GetComponentInChildren<Camera>().GetComponent<Transform>().rotation;
                inventarioDeHabilidades[numeroHabilidad].DarReferenciaDeProyectil(spawnerDeProyectil, posicionJugador,direccionJugador);
                posicionJugador.z += 2f;
                posicionJugador.y -= 1.08f;
                inventarioDeHabilidades[numeroHabilidad].DarReferenciaDeTrampa(spawnerDeTrampa,posicionJugador);
                inventarioDeHabilidades[numeroHabilidad].ActivarHabilidad();
            }
            else
            {
                //eliminate
                print("no tienes puntos suficientes para activar Habilidad o no esta lista");
            }
        }
        else
        {
            validarNumero = true;
        }
    }

    // Declaracion de Metodos de Unity
    public override void Start()
    {
        base.Start();
        Habilidad disparo = new HabilidadDisparo();
        Habilidad trampa = new HabilidadTrampa();
        this.inventarioDeHabilidades.Add(disparo);
        this.inventarioDeHabilidades.Add(trampa);
    }
}
