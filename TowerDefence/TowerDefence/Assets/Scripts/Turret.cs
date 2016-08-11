﻿using UnityEngine;
using System.Collections;


public class Turret : MonoBehaviour {
	
	private Transform target;

	[Header("Attributes")]
	public float range = 15f;
	public float fireRate = 1f;
	public float fireCountdown = 0f;

	public Transform partToRotate;

	private string enemyTag = "Enemy";

	private float turnSpeed = 10f;

	public GameObject bulletPrefab;
	public Transform firePoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			return;
		}

		// Lock Target
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y , 0f);

		// shooting the target
		if (fireCountdown <= 0f) {
			Shoot ();
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);

		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}
	}

	void Shoot()
	{
		GameObject bulletGO =  (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bullet != null) {
			bullet.Seek (target);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
