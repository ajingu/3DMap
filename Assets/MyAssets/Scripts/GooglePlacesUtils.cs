using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;

public class GooglePlacesUtils{

	public static Vector3 LatLonToUnityCoordination(double lat, double lon, AbstractMap map){
		Vector2d mercator = Conversions.GeoToWorldPosition (lat, lon, map.CenterMercator, map.WorldRelativeScale);
		return mercator.ToVector3xz();
	}

}
