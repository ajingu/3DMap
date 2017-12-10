using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class GooglePlacesPhotoSessionInterface : Singleton<MonoBehaviour> {

	[SerializeField]
	int maxwidth = 640;

	[SerializeField]
	string APIKey = "";

	private string photo_url = "https://maps.googleapis.com/maps/api/place/photo?maxwidth={0}&photoreference={1}&key={2}";

	string Photo_URL(string photoreference){
		return String.Format (
			photo_url,
			maxwidth,
			photoreference,
			APIKey
		);
	}

	public IEnumerator Photo_Request(Place place){
		if (place.photos == null) {
			yield break;
		}
		string url = Photo_URL (place.photos[0].photo_reference);
		var req = UnityWebRequestTexture.GetTexture (url);

		yield return req.SendWebRequest();

		var texture = ((DownloadHandlerTexture)req.downloadHandler).texture;


		if (texture == null) {
		    print("SearchResult is null.");
		}

		place.texture = texture;
	}
}
