using UnityEngine;

public class TouchManager : MonoBehaviour {

	[SerializeField]
	Camera camera;

	[SerializeField]
	Mapbox.Unity.MeshGeneration.Factories.DirectionsProvider directionsProvider;

	void Update () {
		if (Input.touchCount > 0) {
			var touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
				Ray ray = camera.ScreenPointToRay (new Vector3(touch.position.x, touch.position.y, 0f));
				RaycastHit hit;
	
				if (Physics.Raycast (ray, out hit)) {
					var manager = hit.collider.GetComponent<ShopInfoPrefabManager>();
					if (manager != null) {
						directionsProvider.ProvideDirection (manager.transform);
					}
				}
			}
		}
	}
}
