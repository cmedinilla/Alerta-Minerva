﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniDirectionalTower : MonoBehaviour {
    public Collider attackObject;
    public GameObject spawnPoint;
    public float maxScale = 2;
    public float Speed = 1;

    private GameObject currentWave = null;
    private Vector3 originalScale;

    [SerializeField]
    private bool _isAttacking = false;

    public bool isAttacking
    {
        get { return this._isAttacking; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isAttacking)
        {
            Attack();
        }
        else
        {
            cleanUp(this.spawnPoint.transform);
        }
	}


    private void Attack()
    {
        if (this.currentWave != null)
        {
            if (Mathf.Abs(this.currentWave.transform.localScale.x) > this.maxScale)
            {// Tamaño máximo alcanzado
                this.currentWave.transform.localScale = this.originalScale;
            }
            else
            {// Sigue creciendo
                this.currentWave.transform.localScale += -1 * Vector3.one * Time.deltaTime * this.Speed;
            }
        }
        else
        {
            this.currentWave = Instantiate(attackObject.gameObject) as GameObject;
            this.currentWave.transform.parent = this.spawnPoint.transform;
            this.currentWave.transform.localPosition = Vector3.zero;
            this.originalScale = this.currentWave.transform.localScale;
        }
    }

    private void cleanUp(Transform parent)
    {
        Object.Destroy(this.currentWave);
        this.currentWave = null;
    }
}