using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 offset;

	private Renderer rend;
	private Color startColor;

    [Header("Optional")]
	public GameObject turret;

    BuildManager buildManager;

	void Start()
	{
        buildManager = BuildManager.instance;
		rend =  GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }

	void OnMouseDown()
	{
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

		if (turret != null) {
			Debug.Log ("Can't Build Turret");
			return;
		}
        // Build a turret

        buildManager.BuildTurretOn(this);
	}

	void OnMouseEnter()
	{
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
