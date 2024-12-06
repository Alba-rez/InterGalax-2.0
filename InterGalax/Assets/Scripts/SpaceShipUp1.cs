using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipUp1 : MonoBehaviour
{
    
    [SerializeField] Vector3 endPosition;
    [SerializeField] float duration;


    

    void Start()
    {

        StartCoroutine("StartPlayer");
    }


    IEnumerator StartPlayer()
    {
        yield return new WaitForSeconds(12);

        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;
        Vector3 initialPosition = transform.position;
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            Vector3 newPosition = Vector3.Lerp(initialPosition, endPosition, t / duration);
            transform.position = newPosition;
            yield return null;

        }


    }


}
