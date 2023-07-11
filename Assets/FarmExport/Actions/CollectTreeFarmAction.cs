using UnityEngine;

namespace ShipFactory {
	public class CollectTreeFarmAction : CollectFarmActionBase<TreeFarmPlot> {

		protected override GameObject FindInInventory() {
			return inventory.FindItemWithTag("WoodFarmPlot");
		}

		protected override void OnPositivePostPerform() {
			GWorld.Instance.GetWorld().ModifyState("freeTreeFarmPlots", 1);
			GWorld.Instance.GetWorld().ModifyState("availableTrees", -1);
			GWorld.Instance.GetWorld().ModifyState("woodCollected", 1);
			inventory.RemoveItem(target);
			GWorld.Instance.AddTreeFarmPlot(target);

			if (GWorld.Instance.GetWorld().GetStates().TryGetValue("woodCollected", out var woodCollected)) {
				if (woodCollected >= 6) {
					beliefs.SetState("full", 0);
				}
			}
			
		}
	}
}