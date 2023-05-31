using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMana : MonoBehaviour
{
    [SerializeField] private float manaInicial;
    [SerializeField] private float manaMax;
    [SerializeField] private float manaRegen;

    public float ManaActual { get; private set; }

    private PersonajeVida _personajeVida;

    private void Awake() {
        _personajeVida = GetComponent<PersonajeVida>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ManaActual = manaInicial;
        ActualizarBarraMana();
        
        InvokeRepeating(nameof(RegenerarMana), 1, 1);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.G)){
            UsarMana(10f);
        }
    }

    public void UsarMana(float cantidad){
        if(ManaActual >= cantidad){
            ManaActual -= cantidad;
            ActualizarBarraMana();
        }
    }

    private void RegenerarMana(){
        if(_personajeVida.Salud > 0f && ManaActual < manaMax)
        {
            ManaActual += manaRegen;
            ActualizarBarraMana();
        }
    }

    public void RestablecerMana(){
        ManaActual = manaMax;
        ActualizarBarraMana();
    }

    private void ActualizarBarraMana(){
        UIManager.Instance.ActualizarManaPersonaje(ManaActual, manaMax);
    }
}