using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(menuName = "Stats")]
public class PersonajeStats : ScriptableObject
{
    [Header ("Stats")]
    public float Daño = 5f;
    public float Defensa = 2f;
    public float Velocidad = 5f;
    public float Nivel;
    public float ExpActual;
    public float ExpRequerida;
    [Range(0f, 100f)] public float PorcentajeCritico;
    [Range(0f, 100f)] public float PorcentajeBloqueo;

    [Header ("Atributos")]

    public int Fuerza;
    public int Destreza;
    public int Inteligencia;

    [HideInInspector] public int PuntosDisponibles;

    public void AñadirBonusPorAtributoFuerza()
    {
        Daño += 1f;
        Defensa += 0.5f;
        PorcentajeBloqueo += 0.03f;
    }

    public void AñadirBonusPorAtributoDestreza()
    {
        Daño += 0.5f;
        Velocidad += 0.5f;
        PorcentajeCritico += 0.2f;
    }

    public void AñadirBonusPorAtributoInteligencia()
    {
        PorcentajeCritico += 0.2f;
        PorcentajeBloqueo += 0.01f;
        Velocidad += 1f;
    }


    public void RessetearValores()
    {
        Daño = 5f;
        Defensa = 2f;
        Velocidad = 5f;
        Nivel = 1f;
        ExpActual = 0f;
        ExpRequerida = 0f;
        PorcentajeCritico = 0f;
        PorcentajeBloqueo = 0f;

        Fuerza = 0;
        Destreza = 0;
        Inteligencia = 0;

        PuntosDisponibles = 0;
    }
}
