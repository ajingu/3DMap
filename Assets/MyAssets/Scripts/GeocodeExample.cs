using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GeocodeExample : MonoBehaviour {

	[SerializeField] 
	GooglePlacesSessionInterface nearby_session;

	[SerializeField] 
	GooglePlacesPhotoSessionInterface photo_session;

	[SerializeField]
	Mapbox.Unity.MeshGeneration.Factories.DirectionsProvider directionsProvider;

	[SerializeField]
	Transform map;

	[SerializeField] 
	GameObject shopInfoPrefab, player;

	[SerializeField]
	PlayerLocationProvider playerLocationProvider;

	Vector3 playerPos;


	void Start () {
		Input.location.Start ();

		Observable
			.FromCoroutine (nearby_session.Nearby_Request)
			.Subscribe (_ => {
				Instantiate_Prefabs();
				LocatePlayer();
			});
	}

	void Instantiate_Prefabs(){
		foreach (Place place in nearby_session.places_result.results) {
			Observable
				.FromCoroutine (() => photo_session.Photo_Request(place))
				.Subscribe (_ => Instantiate_Prefab(place));
		}
	}

	void Instantiate_Prefab(Place place){
		GameObject go = (GameObject)Instantiate(shopInfoPrefab, place.worldPos, Quaternion.identity);
		go.transform.parent = map;
		go.GetComponent<ShopInfoPrefabManager>().Setup (place);
	}
		
	void LocatePlayer(){
		playerPos = playerLocationProvider.RetrieveLocation ();
		player.transform.position = playerPos;
	}
}
