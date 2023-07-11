using UnityEngine;

namespace ShipFactory {
	public abstract class BarnActionBase : GAction {
		public override bool PrePerform() {
			target = GWorld.Instance.GetBarn();
			if (target == null) {
				return false;
			}
			
			var barn = target.GetComponent<Barn>();
			if (barn == null) {
				return false;
			}
			
			return ShouldPerform(barn);
		}

		public override bool PostPerform() {
			var barn = target.GetComponent<Barn>();
			if (barn == null) {
				return false;
			}
			
			OnPositivePostPerform(barn);
			return true;
		}

		protected virtual bool ShouldPerform(Barn barn) {
			return true;
		}
		
		protected abstract void OnPositivePostPerform(Barn barn);
	}
	
}