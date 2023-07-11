namespace ShipFactory {
	public class TreeFarmPlot : FarmPlotBase {
		protected override void OnGrow() {
			GWorld.Instance.GetWorld().ModifyState("availableTrees", 1);
		}
	}
}