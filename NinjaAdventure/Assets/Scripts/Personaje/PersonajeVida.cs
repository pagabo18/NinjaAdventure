using System;
using UnityEngine;

    public class PersonajeVida: VidaBase
    {
        // [SerializeField] private UIManager uiManager;

        public bool PuedeSerCurado => Salud < saludMax;

        public static Action EventoPersonajeDerrotado;

        public bool Derrotado { get; private set; }

        private BoxCollider2D _boxCollider2D;

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        protected override void Start()
        {
            base.Start();
            ActualizarBarraVida(Salud, saludMax);
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                RecibirDaño(10f);
            }
            if(Input.GetKeyDown(KeyCode.Y)) { 
                RestaurarSalud(5f);
            }
        }

        public void RestaurarSalud(float cantidad)
        {
            if(Derrotado) return;

            if(PuedeSerCurado){
                Salud += cantidad;
                if(Salud > saludMax) {
                    Salud = saludMax;
                    
                }
                
                ActualizarBarraVida(Salud, saludMax);
            }   
        }

        protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
        {
            UIManager.Instance.ActualizarVidaPersonaje(vidaActual, vidaMax);
        }

        protected override void PersonajeDerrotado()
        {
            Derrotado = true;
            _boxCollider2D.enabled = false;
            EventoPersonajeDerrotado?.Invoke();
        }

        public void RestaurarPersonaje(){
            Derrotado = false;
            Salud = saludMax;
            _boxCollider2D.enabled = true;
            ActualizarBarraVida(Salud, saludMax);
            
        }
    }
