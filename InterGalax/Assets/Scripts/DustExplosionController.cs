using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustExplosionController : MonoBehaviour
{
    [SerializeField] AudioClip DustExplosion;
    const float DELAY = 0.25f;

    void Start()
    {
        AudioSource.PlayClipAtPoint(DustExplosion, Camera.main.transform.position);
        Destroy(gameObject, DELAY);
    }


}
