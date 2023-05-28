
using UnityEngine;
    public class PersonajeVida: VidaBase
    {
        public bool PuedeSerCurado => Salud < saludMax;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                RecibirDaño(10f);
            }
            if(Input.GetKeyDown(KeyCode.R)) { 
                RestaurarSalud(5f);
            }
        }

        public void RestaurarSalud(float cantidad)
        {
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

        }
    }
