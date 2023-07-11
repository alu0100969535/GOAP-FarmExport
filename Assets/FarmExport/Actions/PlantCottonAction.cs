using UnityEngine;

namespace ShipFactory {
	public class PlantCottonAction : PlantActionBase<CottonFarmPlot> {
		
		protected override GameObject RemoveFromGWorld() {
			return GWorld.Instance.RemoveCottonFarmPlot();
		}

		protected override void AddToGWorld(GameObject go) {
			GWorld.Instance.AddCottonFarmPlot(go);
		}

		protected override void OnPositivePrePerform() {
			GWorld.Instance.GetWorld().ModifyState("freeCottonFarmPlots", -1);
		}
	}
}