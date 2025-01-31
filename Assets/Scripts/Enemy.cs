using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.Mathematics;
using UnityEditor.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    
    [SerializeField] int scorePerHit = 1;
    [SerializeField] int hitPoint = 4;
    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
        parentGameObject = GameObject.FindGameObjectWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoint < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoint--;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        // vfx 게임 오브젝트로 저장(인스턴스화)
        GameObject vfx = Instantiate(deathVFX, transform.position, quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

  
}
