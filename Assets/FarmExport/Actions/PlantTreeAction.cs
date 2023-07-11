using TreeEditor;
using UnityEngine;

namespace ShipFactory {
	public class PlantTreeAction : PlantActionBase<TreeFarmPlot> {
		
		protected override GameObject RemoveFromGWorld() {
			return GWorld.Instance.RemoveTreeFarmPlot();
		}

		protected override void AddToGWorld(GameObject go) {
			GWorld.Instance.AddTreeFarmPlot(go);
		}

		protected override void OnPositivePrePerform() {
			GWorld.Instance.GetWorld().ModifyState("freeTreeFarmPlots", -1);
		}
	}
}