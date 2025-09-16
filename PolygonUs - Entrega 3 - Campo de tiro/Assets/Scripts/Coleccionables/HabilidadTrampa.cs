using System;
using UnityEngine;

public class HabilidadTrampa : Habilidad
{   
    // Constructor(s)
    public HabilidadTrampa()
    {
        this.nombre = "Trampa de piso";
        this.tiempoCoolDown = 5;
        this.puntosRequeridosParaActivar = 3;
        this.tiempoParaRecargar = 0;
        this.estaListo = true;

    }

    // Declaracion de Metodos
    public override void ActivarHabilidad()
    {
        base.ActivarHabilidad();
        trampaParaInstanciar.GetComponent<SpawnDeTrampas>().spawnearTrampa(posicionParaInstanciarTrampa);
    }
}