using UnityEngine;

namespace ShipFactory {
	public class TruckLoaderAgent : GAgent {
		// Start is called before the first frame update
		new void Start()
		{
			base.Start();

			SubGoal s = new SubGoal("loadTruck", 1, false);
			goals.Add(s, 1);

			SubGoal s2 = new SubGoal("rested", 1, false);
			goals.Add(s2, 2);
			Invoke(nameof(GetTired), Random.Range(40, 50));
		}

		void GetTired()
		{
			beliefs.ModifyState("exhausted", 0);
			Invoke(nameof(GetTired), Random.Range(40, 50));
		}
	}
}