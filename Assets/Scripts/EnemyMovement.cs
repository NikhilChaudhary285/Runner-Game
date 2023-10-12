using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;

#if UNITY_EDITOR

using UnityEditor.Build.Content;

#endif
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemyDuration;
    private EnemySpawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        transform.DOMoveX(-9.5f, enemyDuration, false).SetEase(Ease.Linear).OnComplete(DestroyEnemy);

    }
    void DestroyEnemy()
    {
        Destroy(gameObject);
        enemySpawner.destroyedEnemies++;

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

}
