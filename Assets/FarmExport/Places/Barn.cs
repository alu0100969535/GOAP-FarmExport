using System;
using UnityEngine;

namespace ShipFactory {
	public class Barn : MonoBehaviour {
		private int wood;
		private int cotton;

		public int GetWoodCount() {
			return wood;
		}
		
		public int GetCottonCount() {
			return cotton;
		}

		public void RemoveWoodItem() {
			wood = Math.Clamp(wood - 1, 0, int.MaxValue);
		}
		
		public void RemoveCottonItem() {
			cotton = Math.Clamp(cotton - 1, 0, int.MaxValue);
		}
		
		public void AddWoodItem() {
			wood = Math.Clamp(wood + 1 , 0, int.MaxValue);
		}
		
		public void AddCottonItem() {
			cotton = Math.Clamp(cotton + 1 , 0, int.MaxValue);
		}	

	}
}