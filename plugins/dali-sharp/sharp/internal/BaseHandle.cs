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

public class BaseHandle : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal BaseHandle(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BaseHandle obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~BaseHandle() {
    DisposeQueue.Instance.Add(this);
  }

  public virtual void Dispose() {
    if (!Window.IsInstalled()) {
      DisposeQueue.Instance.Add(this);
      return;
    }

    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_BaseHandle(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }



  // Returns the bool value true to indicate that an operand is true and returns false otherwise.
  public static bool operator true(BaseHandle handle)
  {
    // if the C# object is null, return false
    if( BaseHandle.ReferenceEquals( handle, null ) )
    {
      return false;
    }
    // returns true if the handle has a body, false otherwise
    return handle.HasBody();
  }

  // Returns the bool false  to indicate that an operand is false and returns true otherwise.
  public static bool operator false(BaseHandle  handle)
  {
    // if the C# object is null, return true
    if( BaseHandle.ReferenceEquals( handle, null ) )
    {
      return true;
    }
    return !handle.HasBody();
  }

  // Explicit conversion from Handle to bool.
  public static explicit operator bool(BaseHandle handle)
  {
     // if the C# object is null, return false
    if( BaseHandle.ReferenceEquals( handle, null ) )
    {
      return false;
    }
    // returns true if the handle has a body, false otherwise
    return handle.HasBody();
  }

  // Equality operator
  public static bool operator == (BaseHandle x, BaseHandle y)
  {
    // if the C# objects are the same return true
    if(  BaseHandle.ReferenceEquals( x, y ) )
    {
      return true;
    }
    if ( !BaseHandle.ReferenceEquals( x, null ) && !BaseHandle.ReferenceEquals( y, null ) )
    {
      // drop into native code to see if both handles point to the same body
      return x.IsEqual( y) ;
    }
    return false;

  }

  // Inequality operator. Returns Null if either operand is Null
  public static bool operator !=(BaseHandle x, BaseHandle y)
  {
    return !(x==y);
  }

  // Logical AND operator for &&
  // It's possible when doing a && this function (opBitwiseAnd) is never called due
  // to short circuiting. E.g.
  // If you perform x && y What actually is called is
  // BaseHandle.op_False( x ) ? BaseHandle.op_True( x ) : BaseHandle.opTrue( BaseHandle.opBitwiseAnd(x,y) )
  //
  public static BaseHandle operator &(BaseHandle x, BaseHandle y)
  {
    if( x == y )
    {
      return x;
    }
    return null;
  }

  // Logical OR operator for ||
  // It's possible when doing a || this function (opBitwiseOr) is never called due
  // to short circuiting. E.g.
  // If you perform x || y What actually is called is
  // BaseHandle.op_True( x ) ? BaseHandle.op_True( x ) : BaseHandle.opTrue( BaseHandle.opBitwiseOr(x,y) )
  public static BaseHandle operator |(BaseHandle x, BaseHandle y)
  {
    if ( !BaseHandle.ReferenceEquals( x, null ) || !BaseHandle.ReferenceEquals( y, null ) )
    {
       if( x.HasBody() )
       {
         return x;
       }
       if( y.HasBody() )
       {
         return y;
       }
       return null;
    }
    return null;
  }

  // Logical ! operator
  public static bool operator !(BaseHandle x)
  {
    // if the C# object is null, return true
    if( BaseHandle.ReferenceEquals( x, null ) )
    {
      return true;
    }
    if( x.HasBody() )
    {
      return false;
    }
    return true;
  }


  public BaseHandle(BaseObject handle) : this(NDalicPINVOKE.new_BaseHandle__SWIG_0(BaseObject.getCPtr(handle)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public BaseHandle() : this(NDalicPINVOKE.new_BaseHandle__SWIG_1(), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public BaseHandle(BaseHandle handle) : this(NDalicPINVOKE.new_BaseHandle__SWIG_2(BaseHandle.getCPtr(handle)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public BaseHandle Assign(BaseHandle rhs) {
    BaseHandle ret = new BaseHandle(NDalicPINVOKE.BaseHandle_Assign(swigCPtr, BaseHandle.getCPtr(rhs)), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool DoAction(string actionName, Property.Map attributes) {
    bool ret = NDalicPINVOKE.BaseHandle_DoAction(swigCPtr, actionName, Property.Map.getCPtr(attributes));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetTypeName() {
    string ret = NDalicPINVOKE.BaseHandle_GetTypeName(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool GetTypeInfo(TypeInfo info) {
    bool ret = NDalicPINVOKE.BaseHandle_GetTypeInfo(swigCPtr, TypeInfo.getCPtr(info));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public BaseObject GetBaseObject() {
    BaseObject ret = new BaseObject(NDalicPINVOKE.BaseHandle_GetBaseObject__SWIG_0(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reset() {
    NDalicPINVOKE.BaseHandle_Reset(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool EqualTo(BaseHandle rhs) {
    bool ret = NDalicPINVOKE.BaseHandle_EqualTo(swigCPtr, BaseHandle.getCPtr(rhs));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool NotEqualTo(BaseHandle rhs) {
    bool ret = NDalicPINVOKE.BaseHandle_NotEqualTo(swigCPtr, BaseHandle.getCPtr(rhs));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public RefObject GetObjectPtr() {
    global::System.IntPtr cPtr = NDalicPINVOKE.BaseHandle_GetObjectPtr(swigCPtr);
    RefObject ret = (cPtr == global::System.IntPtr.Zero) ? null : new RefObject(cPtr, false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool HasBody() {
    bool ret = NDalicPINVOKE.BaseHandle_HasBody(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsEqual(BaseHandle rhs) {
    bool ret = NDalicPINVOKE.BaseHandle_IsEqual(swigCPtr, BaseHandle.getCPtr(rhs));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
