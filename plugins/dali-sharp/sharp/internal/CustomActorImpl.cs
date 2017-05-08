//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Dali {

public class CustomActorImpl : RefObject {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal CustomActorImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.CustomActorImpl_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CustomActorImpl obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public CustomActor Self() {
    CustomActor ret = new CustomActor(NDalicPINVOKE.CustomActorImpl_Self(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void OnStageConnection(int depth) {
    NDalicPINVOKE.CustomActorImpl_OnStageConnection(swigCPtr, depth);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void OnStageDisconnection() {
    NDalicPINVOKE.CustomActorImpl_OnStageDisconnection(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void OnChildAdd(View child) {
    NDalicPINVOKE.CustomActorImpl_OnChildAdd(swigCPtr, View.getCPtr(child));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void OnChildRemove(View child) {
    NDalicPINVOKE.CustomActorImpl_OnChildRemove(swigCPtr, View.getCPtr(child));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void OnPropertySet(int index, Property.Value propertyValue) {
    NDalicPINVOKE.CustomActorImpl_OnPropertySet(swigCPtr, index, Property.Value.getCPtr(propertyValue));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void OnSizeSet(Vector3 targetSize) {
    NDalicPINVOKE.CustomActorImpl_OnSizeSet(swigCPtr, Vector3.getCPtr(targetSize));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void OnSizeAnimation(Animation animation, Vector3 targetSize) {
    NDalicPINVOKE.CustomActorImpl_OnSizeAnimation(swigCPtr, Animation.getCPtr(animation), Vector3.getCPtr(targetSize));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual bool OnTouchEvent(SWIGTYPE_p_Dali__TouchEvent arg0) {
    bool ret = NDalicPINVOKE.CustomActorImpl_OnTouchEvent(swigCPtr, SWIGTYPE_p_Dali__TouchEvent.getCPtr(arg0));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool OnHoverEvent(Hover arg0) {
    bool ret = NDalicPINVOKE.CustomActorImpl_OnHoverEvent(swigCPtr, Hover.getCPtr(arg0));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool OnKeyEvent(Key arg0) {
    bool ret = NDalicPINVOKE.CustomActorImpl_OnKeyEvent(swigCPtr, Key.getCPtr(arg0));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool OnWheelEvent(Wheel arg0) {
    bool ret = NDalicPINVOKE.CustomActorImpl_OnWheelEvent(swigCPtr, Wheel.getCPtr(arg0));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void OnRelayout(Vector2 size, RelayoutContainer container) {
    NDalicPINVOKE.CustomActorImpl_OnRelayout(swigCPtr, Vector2.getCPtr(size), RelayoutContainer.getCPtr(container));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void OnSetResizePolicy(ResizePolicyType policy, DimensionType dimension) {
    NDalicPINVOKE.CustomActorImpl_OnSetResizePolicy(swigCPtr, (int)policy, (int)dimension);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual Vector3 GetNaturalSize() {
    Vector3 ret = new Vector3(NDalicPINVOKE.CustomActorImpl_GetNaturalSize(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float CalculateChildSize(View child, DimensionType dimension) {
    float ret = NDalicPINVOKE.CustomActorImpl_CalculateChildSize(swigCPtr, View.getCPtr(child), (int)dimension);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float GetHeightForWidth(float width) {
    float ret = NDalicPINVOKE.CustomActorImpl_GetHeightForWidth(swigCPtr, width);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float GetWidthForHeight(float height) {
    float ret = NDalicPINVOKE.CustomActorImpl_GetWidthForHeight(swigCPtr, height);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool RelayoutDependentOnChildren(DimensionType dimension) {
    bool ret = NDalicPINVOKE.CustomActorImpl_RelayoutDependentOnChildren__SWIG_0(swigCPtr, (int)dimension);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool RelayoutDependentOnChildren() {
    bool ret = NDalicPINVOKE.CustomActorImpl_RelayoutDependentOnChildren__SWIG_1(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void OnCalculateRelayoutSize(DimensionType dimension) {
    NDalicPINVOKE.CustomActorImpl_OnCalculateRelayoutSize(swigCPtr, (int)dimension);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void OnLayoutNegotiated(float size, DimensionType dimension) {
    NDalicPINVOKE.CustomActorImpl_OnLayoutNegotiated(swigCPtr, size, (int)dimension);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool RequiresTouchEvents() {
    bool ret = NDalicPINVOKE.CustomActorImpl_RequiresTouchEvents(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool RequiresHoverEvents() {
    bool ret = NDalicPINVOKE.CustomActorImpl_RequiresHoverEvents(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool RequiresWheelEvents() {
    bool ret = NDalicPINVOKE.CustomActorImpl_RequiresWheelEvents(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsRelayoutEnabled() {
    bool ret = NDalicPINVOKE.CustomActorImpl_IsRelayoutEnabled(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}