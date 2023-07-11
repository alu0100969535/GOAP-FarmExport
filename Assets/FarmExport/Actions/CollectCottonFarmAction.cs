using UnityEngine;

namespace ShipFactory {
	public class CollectCottonFarmAction : CollectFarmActionBase<CottonFarmPlot> {
		protected override GameObject FindInInventory() {
			return inventory.FindItemWithTag("CottonFarmPlot");
		}

		protected override void OnPositivePostPerform() {
			GWorld.Instance.GetWorld().ModifyState("freeCottonFarmPlots", 1);
			GWorld.Instance.GetWorld().ModifyState("availableCotton", -1);
			GWorld.Instance.GetWorld().ModifyState("cottonCollected", 1);
			inventory.RemoveItem(target);
			GWorld.Instance.AddCottonFarmPlot(target);
			
			if (GWorld.Instance.GetWorld().GetStates().TryGetValue("cottonCollected", out var collected)) {
				if (collected >= 6) {
					beliefs.SetState("full", 0);
				}
			}
		}
	}
}