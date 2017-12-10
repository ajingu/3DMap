using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Mapbox.Unity.Map;

public class GooglePlacesSessionInterface : Singleton<MonoBehaviour> {

	[SerializeField]
	AbstractMap map;

	[SerializeField]
	Transform mapOrigin;

	[SerializeField]
	double latitude = 0;

	[SerializeField]
	double longitude = 0;

	[SerializeField]
	int radius = 500;

	[SerializeField]
	string types = "food";

	[SerializeField]
	string name = "ラーメン";

	[SerializeField]
	string APIKey = "";

	private string nearby_url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius={2}&types={3}&name={4}&key={5}";

	public Places places_result{ get; set;}

	string Nearby_URL(){
		return String.Format(
			nearby_url, 
			latitude,
			longitude,
			radius,
			types,
			name,
			APIKey
		);
	}

	public IEnumerator  Nearby_Request(){
		string url = Nearby_URL ();
		var req = UnityWebRequest.Get (url);

		yield return req.SendWebRequest();

		var json = req.downloadHandler.text;

		places_result = JsonUtility.FromJson<Places> (json);

		if (places_result != null) {
			Nearby_Process (places_result);
		} else {
			print("SearchResult is null.");
		}
	}

	void Nearby_Process(Places places_result){
		foreach (Place place in places_result.results) {
			place.worldPos = GooglePlacesUtils.LatLonToUnityCoordination (place.geometry.location.lat, place.geometry.location.lng, map) + mapOrigin.position;
			print ("name: " + place.name + "\nrating: " + place.rating
				+ "\nlocation: " + place.geometry.location.lat + ", " + place.geometry.location.lng
				+ "\nphoto_reference: " + (place.photos != null ? place.photos[0].photo_reference : "null")
			);
		}
	}


}
