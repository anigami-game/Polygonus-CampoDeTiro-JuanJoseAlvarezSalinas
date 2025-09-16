public class PersonajeNoJugable : Personaje
{
    // Constructor
    public PersonajeNoJugable()
    {
        nombre = "Blanco";
        maxPuntosDeVida = 3;
    }

    // Declaracion de Metodos
    public override void DisminuirPVida(int DanoRecibido)
    {
        base.DisminuirPVida(DanoRecibido);
        if (puntosDeVida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
