namespace ShipFactory {
	public class BarnTakeWoodAction : BarnActionBase {
		
		protected override bool ShouldPerform(Barn barn) {
			return barn.GetWoodCount() > 0;
		}
		
		protected override void OnPositivePostPerform(Barn barn) {
			GWorld.Instance.GetWorld().ModifyState("handlingWood", 1);
			GWorld.Instance.GetWorld().ModifyState("woodInBarn", -1);
			barn.RemoveWoodItem();
		}
	}
}