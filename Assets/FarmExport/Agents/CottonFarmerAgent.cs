using UnityEngine;

namespace ShipFactory {
	public class CottonFarmerAgent : GAgent {
		// Start is called before the first frame update
		new void Start()
		{
			SubGoal s = new SubGoal("woodInBarn", 1, false);
			goals.Add(s, 10);
			
			base.Start();
			SubGoal s1 = new SubGoal("needCotton", 1, false);
			goals.Add(s1, 3);
			
			SubGoal s2 = new SubGoal("rested", 1, false);
			goals.Add(s2, 5);
			Invoke(nameof(GetTired), Random.Range(40, 50));
		}

		void GetTired()
		{
			beliefs.ModifyState("exhausted", 0);
			Invoke(nameof(GetTired), Random.Range(40, 50));
		}
	}
}