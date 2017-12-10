using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Location;
using Mapbox.Utils;

public class PlayerLocationProvider : DeviceLocationProvider {

	[SerializeField] 
	double lat, lng;

	[SerializeField]
	AbstractMap map;

	[SerializeField]
	Transform mapOrigin;

	Vector3 pos;

	public Vector3 RetrieveLocation(){
	#if !UNITY_EDITOR
		var data = Input.location.lastData;
		pos = GooglePlacesUtils.LatLonToUnityCoordination (data.latitude, data.longitude, map) + mapOrigin.position;
	#else
		pos = GooglePlacesUtils.LatLonToUnityCoordination (lat, lng, map) + mapOrigin.position;
	#endif


		return pos;
	}
}
