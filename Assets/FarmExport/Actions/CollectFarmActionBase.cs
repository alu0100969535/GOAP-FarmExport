using UnityEngine;

namespace ShipFactory {
	public abstract class CollectFarmActionBase<T> : GAction where T : FarmPlotBase {
		public override bool PrePerform() {
			target = FindInInventory();
			if (target == null) {
				return false;
			}

			var farmPlot = target.GetComponent<T>();
			return farmPlot.CanCollect();
		}

		public override bool PostPerform() {
			var farmPlot = target.GetComponent<T>();

			if (farmPlot == null) {
				return false;
			}
			
			farmPlot.Collect();
			OnPositivePostPerform();
			return true;
		}

		protected abstract GameObject FindInInventory();
		protected abstract void OnPositivePostPerform();
	}
}