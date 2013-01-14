using UnityEngine;
using System.Collections;

public class ImScrollContainerComponent : ImAbstractComponent, WTScrollContainerInterface {
	private WTScrollContainer scrollContainer_;	
	
	public ImScrollContainerComponent(string name) : base(name) {
		scrollContainer_ = new WTScrollContainer();
		scrollContainer_.scrollContainerDelegate = this;
	}
	
	public void ScrollContainerDidScroll(WTScrollContainer scrollContainer) {
		
	}
	
	public void ScrollContainerWillBeginDragging(WTScrollContainer scrollContainer) {
		
	}
	
	public void ScrollContainerWillEndDragging(WTScrollContainer scrollContainer, bool velocity, Vector2 targetContentOffset) {
	
	}
	
	public void ScrollContainerDidEndDragging(WTScrollContainer scrollContainer, bool willDecelerate) {
		
	}
	
	public void ScrollContainerShouldScrollToTop(WTScrollContainer scrollContainer) {
		
	}
	
	public void ScrollContainerDidScrollToTop(WTScrollContainer scrollContainer) {
		
	}
	
	public void ScrollContainerWillBeginDecelerating(WTScrollContainer scrollContainer) {
		
	}
	
	public void ScrollContainerDidEndDecelerating(WTScrollContainer scrollContainer) {
		
	}
	
	public void ScrollContainerDidEndScrollingAnimation(WTScrollContainer scrollContainer) {
		
	}
	
	public WTScrollContainer scrollContainer {
		get {return scrollContainer_;}	
	}
}
