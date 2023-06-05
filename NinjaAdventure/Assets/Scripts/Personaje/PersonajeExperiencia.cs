using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeExperiencia : MonoBehaviour
{

    [Header ("Stats")]
    [SerializeField] private PersonajeStats stats;


    [Header ("Config")]
    [SerializeField] private int nivelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int valorIncremental;


    private float expActual;
    private float expActualTemp;
    private float expRequeridaSiguienteNivel;

    // Start is called before the first frame update
    void Start()
    {
        stats.Nivel = 1;

        expRequeridaSiguienteNivel = expBase;
        stats.ExpRequerida = expRequeridaSiguienteNivel;

        ActualizarBarraExp();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.H)){
            AddExp(2f);
        }
    }
    public void AddExp(float expObtenida)
    {
        if(expObtenida > 0f)
        {
            float expRestanteNuevoNivel = expRequeridaSiguienteNivel - expActualTemp;

            if(expObtenida >= expRestanteNuevoNivel){
                expObtenida -= expRestanteNuevoNivel;
                expActual += expObtenida;
                ActualizarNivel();
                AddExp(expObtenida);
            } else { 
                expActual += expObtenida;
                expActualTemp += expObtenida;
                if(expActualTemp == expRequeridaSiguienteNivel)
                {
                    ActualizarNivel();
                }
            }
        }
        stats.ExpActual = expActual;
        ActualizarBarraExp();
    }

    private void ActualizarNivel()
    {
        if(stats.Nivel < nivelMax)
        {
            stats.Nivel++;
            expActualTemp = 0f;
            expRequeridaSiguienteNivel *= valorIncremental;
            stats.ExpRequerida = expRequeridaSiguienteNivel;

        }
    }

    private void ActualizarBarraExp(){
        UIManager.Instance.ActualizarExpPersonaje(expActualTemp, expRequeridaSiguienteNivel);
    }
}
