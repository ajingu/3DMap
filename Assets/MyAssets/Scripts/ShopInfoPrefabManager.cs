using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class ShopInfoPrefabManager : MonoBehaviour {

	[SerializeField] 
	Text shop_name, rating;

	[SerializeField] 
	Image image;

	public Camera camera;

	void Awake(){
		camera = Camera.main;
	}

	public void Setup(Place place){
		shop_name.text = place.name;
		rating.text = place.rating.ToString();
		if (place.texture != null) {
			int height = place.photos [0].height;
			int width = place.photos [0].width;
			image.GetComponent<Image>().sprite = Sprite.Create(place.texture, new Rect(0,0, Mathf.Min(640, width),Mathf.Min(360, height)), Vector2.zero);
		}

		this.UpdateAsObservable ()
			.Where (_ => camera != null)
			.Subscribe (_ => {
				this.transform.LookAt(camera.transform);
			});
	}
}
