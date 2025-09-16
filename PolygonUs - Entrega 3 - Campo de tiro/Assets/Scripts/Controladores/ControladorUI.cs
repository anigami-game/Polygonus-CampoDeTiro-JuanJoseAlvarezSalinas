using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorUI : MonoBehaviour
{
    public static ControladorUI instance;
    // Declaracion de propiedades
    public TMP_Text textoVida;
    public TMP_Text textoMana;
    public TMP_Text textoMaxVida;
    public TMP_Text textoMaxMana;
    public TMP_Text textoContadorHabilidad1;
    public TMP_Text textoContadorHabilidad2;
    private int vida;
    private int maxVida;
    private int mana;
    private int maxMana;
    private int contadorHabilidad1;
    private int contadorHabilidad2;

    //Declaracion de Metodos
    public void ActualizarVida(int nuevoValor)
    {
        vida = nuevoValor;
        textoVida.text = vida.ToString();
    }
    public void ActualizarMaxVida(int nuevoValor)
    {
        maxVida = nuevoValor;
        textoMaxVida.text = maxVida.ToString();
    }
    public void ActualizarMana(int nuevoValor)
    {
        mana = nuevoValor;
        textoMana.text = mana.ToString();
    }
    public void ActualizarMaxMana(int nuevoValor)
    {
        maxMana = nuevoValor;
        textoMaxMana.text = maxMana.ToString();
    }
    public void ActualizarCoolDownHabilidad(int numeroHabilidad,int nuevoValor)
    {
        if (numeroHabilidad == 1)
        {
            contadorHabilidad1 = nuevoValor;
            textoContadorHabilidad1.text = contadorHabilidad1.ToString();
            if (contadorHabilidad1 == 0)
            {
                textoContadorHabilidad1.alpha = 0;
            }
            else
            {
                textoContadorHabilidad1.alpha = 1;
            }
        }
        if (numeroHabilidad == 2)
        {
            contadorHabilidad2 = nuevoValor;
            textoContadorHabilidad2.text = contadorHabilidad2.ToString();
            if (contadorHabilidad2 == 0)
            {
                textoContadorHabilidad2.alpha = 0;
            }
            else
            {
                textoContadorHabilidad2.alpha = 1;
            }
        }
    }

    // Declaracion de Metodos de Unity
    public void Awake()
    {
        instance = this;
        vida = 0;
        maxVida = 0;
        mana = 0;
        maxMana = 0;
        textoVida.text = vida.ToString();
        textoMaxVida.text = maxVida.ToString();
        textoMana.text = mana.ToString();
        textoMaxMana.text = maxMana.ToString();
    }
}
