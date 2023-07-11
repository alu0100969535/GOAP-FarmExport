using UnityEngine;

namespace ShipFactory {
	public class BarnDepositWoodAction : BarnActionBase {
		
		protected override void OnPositivePostPerform(Barn barn) {
			GWorld.Instance.GetWorld().ModifyState("woodInBarn", 1);
			GWorld.Instance.GetWorld().ModifyState("woodCollected", -1);
			barn.AddWoodItem();
			
			if (GWorld.Instance.GetWorld().GetStates().TryGetValue("woodCollected", out var woodCollected)) {
				if (woodCollected <= 0) {
					beliefs.RemoveState("full");
				}
			}
			else {
				beliefs.RemoveState("full");
			}
		}
	}
}