using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 offset;

	private Renderer rend;
	private Color startColor;

	private GameObject turret;

    BuildManager buildManager;

	void Start()
	{
        buildManager = BuildManager.instance;
		rend =  GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	void OnMouseDown()
	{
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

		if (turret != null) {
			Debug.Log ("Can't Build Turret");
			return;
		}
		// Build a turret

		GameObject turretToBuild = buildManager.GetTurretToBuild ();
		turret = (GameObject)Instantiate (turretToBuild, transform.position + offset, transform.rotation);
	}

	void OnMouseEnter()
	{
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
