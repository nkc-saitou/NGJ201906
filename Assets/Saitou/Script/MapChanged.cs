using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Saitou.UI {


	public class MapChanged : MonoBehaviour {

		public GameObject[] UiObjects;

		/// <summary>
		/// ui
		/// </summary>
		public void ShowUi() {
			Debug.Log("dede");
			foreach (var ui in UiObjects) {
				ui.gameObject.SetActive(true);
			}
		}
	}
}
