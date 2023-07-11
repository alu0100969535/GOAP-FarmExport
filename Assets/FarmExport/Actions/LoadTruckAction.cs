using TMPro;

namespace ShipFactory {
	public class LoadTruckAction : GAction {
		public override bool PrePerform() {
			target = GWorld.Instance.GetTruck();
			if (target == null) {
				return false;
			}

			var truck = target.GetComponent<Truck>();
			if (truck == null) {
				return false;
			}
			
			return !truck.WillDepartSoon();
		}

		public override bool PostPerform() {
			var truck = target.GetComponent<Truck>();
			if (truck == null) {
				return false;
			}

			
			if (GWorld.Instance.GetWorld().GetStates().TryGetValue("handlingCotton", out var handlingCotton)) {
				if (handlingCotton > 0) {
					GWorld.Instance.GetWorld().ModifyState("handlingCotton", -handlingCotton);
					GWorld.Instance.GetWorld().ModifyState("sentCotton", handlingCotton);
				}
			}
			
			if (GWorld.Instance.GetWorld().GetStates().TryGetValue("handlingWood", out var handlingWood)) {
				if (handlingWood > 0) {
					GWorld.Instance.GetWorld().ModifyState("handlingWood", -handlingWood);
					GWorld.Instance.GetWorld().ModifyState("sentWood", handlingWood);
				}
			}
			
			return true;
		}
	}
}