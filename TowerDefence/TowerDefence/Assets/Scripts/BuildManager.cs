using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

	private GameObject turretToBuild;

	void Awake()
	{
		if (instance != null) {
			Debug.LogError ("More than one BuildManager");
		}
		instance = this;
	}

    /*
	void Start()
	{
		turretToBuild = standardTurretPrefab;
	}
    */

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
