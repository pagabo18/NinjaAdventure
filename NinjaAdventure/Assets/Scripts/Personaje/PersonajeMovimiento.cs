using System;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;
    
    public Vector2 DireccionMovimiento => _direccionMovimiento;
    public bool EnMovimiento => _direccionMovimiento.magnitude > 0f;
    

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direccionMovimiento;
    private Vector2 _input;
    private PersonajeVida _personajeVida;
    
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _personajeVida = GetComponent<PersonajeVida>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(x:Input.GetAxisRaw("Horizontal"), y:Input.GetAxisRaw("Vertical"));
        if(!_personajeVida.Derrotado)
        {
            if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                velocidad = 7f;
            }
            if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) {
                velocidad = 4f;
            }

            if(_input.x > 0.1)
            {
                _direccionMovimiento.x = 1f;
            }
            else if(_input.x < 0f)
            {
                _direccionMovimiento.x = -1f;
            } else {
                _direccionMovimiento.x = 0f;
            }

            if(_input.y > 0.1)
            {
                _direccionMovimiento.y = 1f;
            }
            else if(_input.y < 0f)
            {
                _direccionMovimiento.y = -1f;
            } else {
                _direccionMovimiento.y = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direccionMovimiento * velocidad * Time.fixedDeltaTime);
    }
}
