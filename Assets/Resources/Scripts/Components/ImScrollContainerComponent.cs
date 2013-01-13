using UnityEngine;
using System.Collections;

public class ImScrollContainerComponent : ImAbstractComponent {
	private WTScrollContainer scrollContainer_;	
	
	public ImScrollContainerComponent(string name) : base(name) {
		scrollContainer_ = new WTScrollContainer();
	}
	
	public WTScrollContainer scrollContainer {
		get {return scrollContainer_;}	
	}
}
