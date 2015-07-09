using UnityEngine;
using System.Collections;

public class ObjectButtonScript : MonoBehaviour {

	public DisplayManager manager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPrism()
	{
		   manager.setObjectState(DisplayManager.ObjectState.Prism);
	}

	public void setGlass()
	{
			manager.setObjectState(DisplayManager.ObjectState.Glass);
	}

	public void setRaindrop()
	{
			manager.setObjectState(DisplayManager.ObjectState.Raindrop);
	}

	//First Ray
	public void setWhiteRay()
	{
		manager.setRayState (DisplayManager.RayState.White);
	}

	public void setCyanRay()
	{
		manager.setRayState (DisplayManager.RayState.Cyan);
	}

	public void setMagentaRay()
	{
		manager.setRayState (DisplayManager.RayState.Magenta);
	}

	public void setYellowRay()
	{
		manager.setRayState (DisplayManager.RayState.Yellow);
	}

	public void setRedRay()
	{
		manager.setRayState (DisplayManager.RayState.Red);
	}

	public void setGreenRay()
	{
		manager.setRayState (DisplayManager.RayState.Green);
	}

	public void setBlueRay()
	{
		manager.setRayState (DisplayManager.RayState.Blue);
	}
}
