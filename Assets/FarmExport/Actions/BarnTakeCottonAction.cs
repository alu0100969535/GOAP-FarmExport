namespace ShipFactory {
	public class BarnTakeCottonAction : BarnActionBase {

		protected override bool ShouldPerform(Barn barn) {
			return barn.GetCottonCount() > 0;
		}
		
		protected override void OnPositivePostPerform(Barn barn) {
			GWorld.Instance.GetWorld().ModifyState("handlingCotton", 1);
			GWorld.Instance.GetWorld().ModifyState("cottonInBarn", -1);
			barn.RemoveCottonItem();
			
		}
	}
}