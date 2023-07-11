namespace ShipFactory {
	public class CottonFarmPlot : FarmPlotBase {
		protected override void OnGrow() {
			GWorld.Instance.GetWorld().ModifyState("availableCotton", 1);
		}
	}
}