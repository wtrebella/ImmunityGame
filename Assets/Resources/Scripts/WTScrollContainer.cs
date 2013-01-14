using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface WTScrollContainerInterface {
	void ScrollContainerDidScroll(WTScrollContainer scrollContainer);
	void ScrollContainerWillBeginDragging(WTScrollContainer scrollContainer);
	void ScrollContainerWillEndDragging(WTScrollContainer scrollContainer, bool velocity, Vector2 targetContentOffset);
	void ScrollContainerDidEndDragging(WTScrollContainer scrollContainer, bool willDecelerate);
	void ScrollContainerShouldScrollToTop(WTScrollContainer scrollContainer);
	void ScrollContainerDidScrollToTop(WTScrollContainer scrollContainer);
	void ScrollContainerWillBeginDecelerating(WTScrollContainer scrollContainer);
	void ScrollContainerDidEndDecelerating(WTScrollContainer scrollContainer);
	void ScrollContainerDidEndScrollingAnimation(WTScrollContainer scrollContainer);
}

public class WTScrollContainer : FContainer, FSingleTouchableInterface {
	public WTScrollContainerInterface scrollContainerDelegate;
	
	public Vector2 contentOffset = Vector2.zero;
	public Vector2 contentSize = Vector2.zero;
	public WTEdgeInsets contentInset = new WTEdgeInsets(0, 0, 0, 0);
	
	public bool scrollEnabled = true;
	public bool directionLockEnabled = true;
	public bool scrollsToTop = true;
	public bool bounces = true;
	public bool alwaysBounceVertical = true;
	public bool alwaysBounceHorizontal = true;
	public bool canCancelContentTouches = true;
	public bool delaysContentTouches = true;
	public float decelerationRate = 100f;
	
	private bool dragging_ = false;
	private bool tracking_ = false;
	private bool decelerating_ = false;
		
	public WTScrollContainer() {
		
	}
	
	public void HandleAddedToStage() {
		Futile.touchManager.AddSingleTouchTarget(this);
	}
	
	public void HandleRemovedFromStage() {
		Futile.touchManager.RemoveSingleTouchTarget(this);
	}
	
	public void SetContentOffset(bool animated) {
		
	}
	
	public void ScrollRectToVisible(Rect rect, bool animated) {
		
	}
	
	public bool TouchesShouldBegin(List<FTouch> touches, FContainer contentContainer) {
		return true;
	}
	
	public bool TouchesShouldCancel(FContainer contentContainer) {
		return true;
	}
	
	public bool dragging {
		get {return dragging_;}	
	}
	
	public bool tracking {
		get {return tracking_;}	
	}
	
	public bool decelerating {
		get {return decelerating_;}	
	}
	
	public bool HandleSingleTouchBegan(FTouch touch) {
		return true;
	}
	
	public void HandleSingleTouchMoved(FTouch touch) {
		
	}
	
	public void HandleSingleTouchMoved(FTouch touch) {
		
	}
	
	public void HandleSingleTouchCanceled(FTouch touch) {
		
	}
	
	/*
Managing the Scroll Indicator
  indicatorStyle  property
  scrollIndicatorInsets  property
  showsHorizontalScrollIndicator  property
  showsVerticalScrollIndicator  property
– flashScrollIndicators
  
Managing the Delegate
  delegate  property
  */
}
