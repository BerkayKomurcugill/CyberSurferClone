using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotateOnSwipe : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void Update()
    {
        // Kaydýrma yönünü al (klavye için "Horizontal" ekseni)
        float swipeDirection = Input.GetAxis("Horizontal");

        // Pozitif yönde kaydýrýlýyorsa saða dönüþ yap
        if (swipeDirection > 0)
        {
            RotateObject(Vector3.up); // Y ekseni etrafýnda dönüþ
        }
        // Negatif yönde kaydýrýlýyorsa sola dönüþ yap
        else if (swipeDirection < 0)
        {
            RotateObject(Vector3.down); // Y ekseni etrafýnda ters dönüþ
        }
    }

    // Objeyi belirtilen eksende döndürmek için bir fonksiyon
    void RotateObject(Vector3 axis)
    {
        // Dönüþü objenin mevcut rotasyonuna ekleyerek gerçekleþtiririz
        transform.Rotate(axis * rotationSpeed * Time.deltaTime);
    }
}
