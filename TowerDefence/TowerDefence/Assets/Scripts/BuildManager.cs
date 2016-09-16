using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

	private TurretBlueprint turretToBuild;

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

	
    // creating property  to check if a turret is selected
    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        
        if (PlayerStats.Money < turretToBuild.cost) {
            Debug.Log("Not Enough Money to build that!");
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Turret Build! Money Left = "+PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
