using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.Mathematics;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    void OnParticleCollision(GameObject other) 
    {
        // vfx 게임 오브젝트로 저장(인스턴스화)
        GameObject vfx = Instantiate(deathVFX, transform.position, quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
