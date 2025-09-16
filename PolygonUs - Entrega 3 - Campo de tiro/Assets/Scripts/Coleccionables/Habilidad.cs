using UnityEngine;

public class Habilidad
{
    //Declaraciond de propiedades
    [SerializeField] protected string nombre;
    [SerializeField] protected Sprite icono;
    [SerializeField, Range(0, 10)] protected int tiempoCoolDown;
    [SerializeField] protected int puntosRequeridosParaActivar;
    [SerializeField] public int tiempoParaRecargar;
    [SerializeField] public bool estaListo;
    public float contadorTiempo;
    protected GameObject trampaParaInstanciar;
    protected Vector3 posicionParaInstanciarTrampa;
    protected GameObject proyectilParaInstanciar;
    protected Vector3 posicionParaInstanciarProyectil;
    protected Quaternion direccionParaInstanciarProyectil;
    protected Personaje casteador;

    //Constructor(s)
    public Habilidad(){}

    //Getters and Setters
    public string ObtenerNombre()
    {
        return nombre;
    }
    public Sprite ObtenerIcono()
    {
        return icono;
    }
    public int ObtenerPuntosRequeridosParaActivar()
    {
        return puntosRequeridosParaActivar;
    }
    public bool ObtenerEstaListo()
    {
        return estaListo;
    }
    public void DarReferenciaDeProyectil(GameObject referenciaProyectil, Vector3 referenciaPosicion, Quaternion referenciaDireccion)
    {
        proyectilParaInstanciar = referenciaProyectil;
        posicionParaInstanciarProyectil = referenciaPosicion;
        direccionParaInstanciarProyectil = referenciaDireccion;
    }
    public void DarReferenciaDeTrampa(GameObject referenciaTrampa, Vector3 referenciaPosicion)
    {
        trampaParaInstanciar = referenciaTrampa;
        posicionParaInstanciarTrampa = referenciaPosicion;
    }
    public void DarReferenciaCasteador(Personaje referenciaCasteador)
    {
        casteador = referenciaCasteador;
    }

    //Declaracion de Metodos
    public virtual void ActivarHabilidad()
    {
            estaListo = false;
            tiempoParaRecargar = tiempoCoolDown;
    }
}
