using System;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public PersonajeVida PersonajeVida { get; private set; }
    public PersonajeAnimaciones PersonajeAnimaciones { get; private set; }
    public PersonajeMana PersonajeMana { get; private set; }
    
    [SerializeField] private PersonajeStats stats;

    private void Awake()
    {
        PersonajeVida = GetComponent<PersonajeVida>();
        PersonajeAnimaciones = GetComponent<PersonajeAnimaciones>();
        PersonajeMana = GetComponent<PersonajeMana>();
    }

    public void RestaurarPersonaje()
    {
        PersonajeVida.RestaurarPersonaje();
        PersonajeAnimaciones.RevivirPersonaje();
        PersonajeMana.RestablecerMana();
    }

    private void AtributoRespuesta(TipoAtributo tipo)
    {
        if(stats.PuntosDisponibles <= 0f) return;

        switch(tipo){
            case TipoAtributo.Fuerza:
                stats.Fuerza ++;
                stats.AñadirBonusPorAtributoFuerza();
                break;
            case TipoAtributo.Destreza:
                stats.Destreza ++;
                stats.AñadirBonusPorAtributoDestreza();
                break;
            case TipoAtributo.Inteligencia:
                stats.Inteligencia ++;
                stats.AñadirBonusPorAtributoInteligencia();
                break;
            
        }
    }

    private void OnEnable() {
        AtributoButton.EventoAgregarAtributo += AtributoRespuesta;
    }

    private void OnDisable() {
        AtributoButton.EventoAgregarAtributo -= AtributoRespuesta;
    }
}
