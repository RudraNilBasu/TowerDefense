using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 offset;

	private Renderer rend;
	private Color startColor;

	private GameObject turret;

	void Start()
	{
		rend =  GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	void OnMouseDown()
	{
		if (turret != null) {
			Debug.Log ("Can't Build Turret");
			return;
		}
		// Build a turret

		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild ();
		turret = (GameObject)Instantiate (turretToBuild, transform.position + offset, transform.rotation);
	}

	void OnMouseOver()
	{
		rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
