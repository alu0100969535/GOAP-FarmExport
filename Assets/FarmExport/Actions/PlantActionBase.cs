using UnityEngine;

namespace ShipFactory {
	public abstract class PlantActionBase<T> : GAction where T : FarmPlotBase {
		
		public override bool PrePerform() {
			target = RemoveFromGWorld();
			if (target == null) {
				return false;
			}
			
			var farmPlot = target.GetComponent<T>();

			if (farmPlot == null || !farmPlot.CanPlant()) {
				AddToGWorld(target);
				target = null;
				return false;
			}
			
			inventory.AddItem(target);
			OnPositivePrePerform();
			return true;
		}

		public override bool PostPerform() {
			var farmPlot = target.GetComponent<T>();

			if (farmPlot == null) {
				return false;
			}
			
			farmPlot.Plant();
			return true;
		}

		protected abstract GameObject RemoveFromGWorld();
		protected abstract void AddToGWorld(GameObject go);
		protected abstract void OnPositivePrePerform();
	}
}