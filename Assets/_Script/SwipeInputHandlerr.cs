using UnityEngine;

public class SwipeInputHandlerr : MonoBehaviour
{
    private float value = 0f;
    private Vector2 touchStartPosition;
    private float swipeThreshold = 10f; // Swipe mesafesiyle orant�l� olarak daha d���k bir de�er.

    private float rotationSpeed = 180f; // D�n�� h�z�, istedi�iniz de�eri ayarlayabilirsiniz.

    public GameObject @this;


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved|| touch.phase == TouchPhase.Stationary)
            {
                float swipeDistance = touch.position.x - touchStartPosition.x;

                if (Mathf.Abs(swipeDistance) > swipeThreshold)
                {
                    
                    if (swipeDistance > 0)
                    {
                        value = Mathf.Clamp(value + 0.001f, -1f, 1f); 
                     //   Debug.Log(value);
                    }
                   
                    else if (swipeDistance < 0)
                    {
                        value = Mathf.Clamp(value - 0.001f, -1f, 1f); 
                   //     Debug.Log(value);
                    }
                }
            }
            float targetRotation = value * 360f;
            Vector3 targetEulerAngles = this.transform.eulerAngles;
            targetEulerAngles.z = targetRotation;
            this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles,
                targetEulerAngles, rotationSpeed * Time.deltaTime);
            if (targetEulerAngles.z <= -360 || targetEulerAngles.z >= 360)
            {
                this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 
                    this.transform.eulerAngles.y, 0);
            }
        }
    }

        // De�eri kullanarak yapmak istedi�iniz i�lemleri burada yapabilirsiniz.
        // �rne�in, karakterin h�z�n� veya objelerin konumunu g�ncellemek i�in bu de�eri kullanabilirsiniz.
    }


