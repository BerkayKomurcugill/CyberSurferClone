using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotateOnSwipe : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void Update()
    {
        // Kayd�rma y�n�n� al (klavye i�in "Horizontal" ekseni)
        float swipeDirection = Input.GetAxis("Horizontal");

        // Pozitif y�nde kayd�r�l�yorsa sa�a d�n�� yap
        if (swipeDirection > 0)
        {
            RotateObject(Vector3.up); // Y ekseni etraf�nda d�n��
        }
        // Negatif y�nde kayd�r�l�yorsa sola d�n�� yap
        else if (swipeDirection < 0)
        {
            RotateObject(Vector3.down); // Y ekseni etraf�nda ters d�n��
        }
    }

    // Objeyi belirtilen eksende d�nd�rmek i�in bir fonksiyon
    void RotateObject(Vector3 axis)
    {
        // D�n��� objenin mevcut rotasyonuna ekleyerek ger�ekle�tiririz
        transform.Rotate(axis * rotationSpeed * Time.deltaTime);
    }
}
