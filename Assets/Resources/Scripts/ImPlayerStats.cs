using UnityEngine;
using System.Collections;
using System;

public static class ImPlayerStats {
	public static event Action SignalDollarsChanged;
	
	private static float dollars_ = 100f;
	
	public static float dollars {
		get {return dollars_;}
		set {
			dollars_ = value;
			if (SignalDollarsChanged != null) SignalDollarsChanged();
		}
	}
}
