using System;
using UnityEngine;

[Serializable]
public class Places{
	public Place[] results;
}

[Serializable]
public class Place{
	public Geometry geometry;
	public string name;
	public float rating;
	public Photo[] photos;
	public Vector3 worldPos;
	public Texture2D texture;
}

[Serializable]
public class Geometry{
	public Location location;
}

[Serializable]
public class Location{
	public double lat;
	public double lng;
}

[Serializable]
public class Photo{
	public string photo_reference;
	public int height;
	public int width;
}