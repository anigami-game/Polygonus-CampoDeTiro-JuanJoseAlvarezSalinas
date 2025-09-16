using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PersonajeJugable : Personaje
{
    //Declaraciond de propiedades
    [SerializeField, Range(0, 20)] protected int puntosDeMana;
    [SerializeField, Range(0, 20)] protected int maxPuntosDeMana;
    public List<Habilidad> inventarioDeHabilidades = new List<Habilidad>();
    [SerializeField] protected GameObject spawnerDeProyectil;
    protected float contadorTiempo;
    protected bool validarNumero;

    //Constructor
    public PersonajeJugable() { }

    // Getters and Setters
    public int ObtenerPMana()
    {
        return puntosDeMana;
    }
    public int ObtenerMaxPMana()
    {
        return maxPuntosDeMana;
    }
    public List<Habilidad> ObtenerInventarioDeHabilidades()
    {
        return inventarioDeHabilidades;
    }

    // Declaracion de Metodos
    public virtual void UsarHabilidad(int numeroHabilidad)
    {
        if (numeroHabilidad >= 3 || numeroHabilidad < 0 || numeroHabilidad >= inventarioDeHabilidades.Count)
        {
            //eliminate
            print("Habilidad no asignada");
            validarNumero = false;
            return;
        }       
    }
    public void RecuperarPMana(FuenteDeMana fuente)
    {   
        if(fuente == FuenteDeMana.TIEMPO)
        {
            puntosDeMana++;
        }
        else
        {
            puntosDeMana += + 10;
        }
        if (this.gameObject.CompareTag("Player")){ControladorUI.instance.ActualizarMana(puntosDeMana);}
        
    }

    // Declaracion de Metodos de Unity
    public override void Start()
    {
        base.Start();
        puntosDeMana = maxPuntosDeMana;
        if (this.gameObject.CompareTag("Player"))
        {
            ControladorUI.instance.ActualizarMana(puntosDeMana);
            ControladorUI.instance.ActualizarMaxMana(maxPuntosDeMana);
        }
        contadorTiempo = 0f;
        foreach (Habilidad habilidad in inventarioDeHabilidades){
            habilidad.contadorTiempo = 0f;
        }
    }

    public void Update()
    {
        contadorTiempo += Time.deltaTime;
        if (contadorTiempo >= 1f)
        {
            if (puntosDeMana < maxPuntosDeMana)
            {
                RecuperarPMana(FuenteDeMana.TIEMPO);
            }
            int numeroHabilidad = 0;
            //Actualizar tiempos de recarga en Habilidades
            foreach (Habilidad habilidad in inventarioDeHabilidades)
            {  
                if (habilidad.tiempoParaRecargar > 0)
                {
                    habilidad.tiempoParaRecargar -= 1;
                    if (this.gameObject.CompareTag("Player"))
                    {
                        ControladorUI.instance.ActualizarCoolDownHabilidad(numeroHabilidad, habilidad.tiempoParaRecargar);
                    }
                }
                else
                {
                    habilidad.estaListo = true;
                }
                numeroHabilidad++;
            }
            contadorTiempo -= 1f;
        }
        
    }
}
