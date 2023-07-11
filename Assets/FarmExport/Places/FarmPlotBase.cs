using UnityEngine;

namespace ShipFactory {
	public abstract class FarmPlotBase : MonoBehaviour {

		[SerializeField] private Renderer renderer;
		[SerializeField] private Material emptyMaterial;
		[SerializeField] private Material plantedMaterial;
		[SerializeField] private GameObject tree;

		private bool canCollect;
		private bool isPlanted;


		public void Start() {
			renderer.material = emptyMaterial;
			tree.SetActive(false);
		}

		public bool CanPlant() {
			return !isPlanted && !canCollect;
		}

		public void Plant() {
			renderer.material = plantedMaterial;
			isPlanted = true;
			Invoke(nameof(Grow), Random.Range(10,20));
		}

		public bool CanCollect() {
			return isPlanted && canCollect;
		}

		public void Collect() {
			renderer.material = emptyMaterial;
			tree.SetActive(false);
			canCollect = false;
			isPlanted = false;
		}

		private void Grow() {
			renderer.material = emptyMaterial;
			tree.SetActive(true);
			canCollect = true;
			OnGrow();
		}

		protected abstract void OnGrow();

	}
}