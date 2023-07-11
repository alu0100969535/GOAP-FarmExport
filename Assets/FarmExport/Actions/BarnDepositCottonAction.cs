namespace ShipFactory {
	public class BarnDepositCottonAction : BarnActionBase {
		protected override void OnPositivePostPerform(Barn barn) {
			GWorld.Instance.GetWorld().ModifyState("cottonInBarn", 1);
			GWorld.Instance.GetWorld().ModifyState("cottonCollected", -1);
			barn.AddCottonItem();

			if (GWorld.Instance.GetWorld().GetStates().TryGetValue("cottonCollected", out var collected)) {
				if (collected <= 0) {
					beliefs.RemoveState("full");
				}
			}
			else {
				beliefs.RemoveState("full");
			}
		}
	}
}