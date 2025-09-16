using UnityEngine;

public class HabilidadDisparo : Habilidad
{
    // Constructor(s)
    public HabilidadDisparo()
    {
        this.nombre = "Disparo";
        this.tiempoCoolDown = 0;
        this.puntosRequeridosParaActivar = 0;
        this.tiempoParaRecargar = 0;
        this.estaListo = true;

    }

    // Declaracion de Metodos

    public override void ActivarHabilidad()
    {
        base.ActivarHabilidad();
        proyectilParaInstanciar.GetComponent<SpawnDeProyectiles>().spawnearProyectil(posicionParaInstanciarProyectil, direccionParaInstanciarProyectil);
    }
}