using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;

public class PlayerPositionManager : MonoBehaviour {

	[SerializeField]
	AbstractMap _map;

	[SerializeField]
	Transform mapOrigin;

	[SerializeField]
	PlayerLocationProvider locationProvider;

	[SerializeField]
	float _positionFollowFactor = 0.1f;

	Vector3 _targetPosition;

	void Start () {
		locationProvider.OnLocationUpdated += LocationProvider_OnLocationUpdated;
	}

	void OnDestroy(){
		locationProvider.OnLocationUpdated -= LocationProvider_OnLocationUpdated;
	}
	
	void LocationProvider_OnLocationUpdated(object sender, LocationUpdatedEventArgs e){
		_targetPosition = Conversions.GeoToWorldPosition(
			e.Location, 
			_map.CenterMercator,
			_map.WorldRelativeScale
		).ToVector3xz() + mapOrigin.position;


		transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _positionFollowFactor);
	}
}
