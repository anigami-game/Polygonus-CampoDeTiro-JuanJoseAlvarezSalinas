using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour, IReciboDano
{
    //Declaraciond de propiedades
    [SerializeField] protected string nombre;
    [SerializeField, Range(0, 10)] protected int puntosDeVida;
    [SerializeField, Range(0, 10)] protected int maxPuntosDeVida;

    //Constructor(s)
    public Personaje() { }

    //Getters and Setters
    public string ObtenerNombre()
    {
        return nombre;
    }
    public int ObtenerPVida()
    {
        return puntosDeVida;
    }
    public virtual void DisminuirPVida(int DanoRecibido)
    {
        puntosDeVida =  Mathf.Clamp(puntosDeVida - DanoRecibido, 0, maxPuntosDeVida);
        if (this.gameObject.CompareTag("Player")) { ControladorUI.instance.ActualizarVida(puntosDeVida); }
    }
    public void RecuperarPVida(int vidaRecuperada)
    {
        puntosDeVida = Mathf.Clamp(puntosDeVida + vidaRecuperada, 0, maxPuntosDeVida);
        if (this.gameObject.CompareTag("Player")) { ControladorUI.instance.ActualizarVida(puntosDeVida); }
    }

    //Declaracion de Metodos de Unity
    public virtual void Start()
    {
        puntosDeVida = maxPuntosDeVida;
        if (this.gameObject.CompareTag("Player"))
        {
            ControladorUI.instance.ActualizarVida(puntosDeVida);
            ControladorUI.instance.ActualizarMaxVida(maxPuntosDeVida);
        }
    }
}
