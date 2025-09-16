using UnityEngine;

public class Mago : PersonajeJugable
{
    // Constructor(s)
    public Mago()
    {
        this.nombre = "Mago";
        this.maxPuntosDeVida = 7;
        this.maxPuntosDeMana = 20;
        this.validarNumero = true;
    }
    // Declaracion de Metodos
    public override void UsarHabilidad(int numeroHabilidad)
    {
        base.UsarHabilidad(numeroHabilidad);
        if (validarNumero == true)
        {
            int puntosRequeridos = inventarioDeHabilidades[numeroHabilidad].ObtenerPuntosRequeridosParaActivar();
            if (puntosRequeridos <= puntosDeMana)
            {
                puntosDeMana -= puntosRequeridos;
                if (this.gameObject.CompareTag("Player")) { ControladorUI.instance.ActualizarMana(puntosDeMana); }
                Vector3 posicionJugador = GetComponent<Transform>().position;
                Quaternion direccionJugador = GetComponentInChildren<Camera>().GetComponent<Transform>().rotation;
                inventarioDeHabilidades[numeroHabilidad].DarReferenciaDeProyectil(spawnerDeProyectil, posicionJugador, direccionJugador);
                inventarioDeHabilidades[numeroHabilidad].DarReferenciaCasteador(this);
                inventarioDeHabilidades[numeroHabilidad].ActivarHabilidad();
            }
            else
            {
                //eliminate
                print("Habilidad no disponible");
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
        Habilidad cura = new HabilidadCura();
        this.inventarioDeHabilidades.Add(disparo);
        this.inventarioDeHabilidades.Add(cura);
    }
}
