using UnityEngine;
using UnityEngine.InputSystem; // Añadimos la nueva librería

public class Mover : MonoBehaviour
{
    public float velocidad = 1.5f;

    void Update()
    {
        // Leemos el teclado con el nuevo Input System
        float movimientoH = 0f;
        float movimientoV = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) movimientoH = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) movimientoH = 1f;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) movimientoV = 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) movimientoV = -1f;
        }
       

        Vector3 direccion = new Vector3(movimientoH, 0, movimientoV);
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }
    public void aumentarVel(float a){

    }
}