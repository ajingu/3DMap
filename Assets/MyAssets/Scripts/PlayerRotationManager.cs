using UnityEngine;
using Mapbox.Unity.Location;

public class PlayerRotationManager : MonoBehaviour {

	[SerializeField]
	PlayerLocationProvider locationProvider;

	[SerializeField]
	float _rotationFollowFactor = 0.1f;


	void Start () {
		locationProvider.OnHeadingUpdated += LocationProvider_OnHeadingUpdated;
	}

	void OnDestroy(){
		locationProvider.OnHeadingUpdated -= LocationProvider_OnHeadingUpdated;
	}
	
	void LocationProvider_OnHeadingUpdated(object sender, HeadingUpdatedEventArgs e)
	{
		var euler = Mapbox.Unity.Constants.Math.Vector3Zero;
		euler.y = e.Heading + 180f;

		var rotation = Quaternion.Euler(euler);
		transform.localRotation = rotation;
	}
}
