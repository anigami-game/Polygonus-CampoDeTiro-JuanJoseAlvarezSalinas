using UnityEngine;

public class HabilidadCura : Habilidad
{
    // Constructor(s)
    public HabilidadCura()
    {
        this.nombre = "Curar";
        this.tiempoCoolDown = 15;
        this.puntosRequeridosParaActivar = 20;
        this.tiempoParaRecargar = 0;
        this.estaListo = true;

    }

    // Declaracion de Metodos
    public void ActivarHabilidadCura(Personaje personaje)
    {
        personaje.RecuperarPVida(10);
    }

    public override void ActivarHabilidad()
    {
        base.ActivarHabilidad();
        ActivarHabilidadCura(casteador);
    }
}