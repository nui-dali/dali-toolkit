/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/
// This File has been auto-generated by SWIG and then modified using DALi Ruby Scripts
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

using System;
using System.Runtime.InteropServices;


public class ProgressBar : View {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal ProgressBar(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.ProgressBar_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ProgressBar obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~ProgressBar() {
    DisposeQueue.Instance.Add(this);
  }

  public override void Dispose() {
    if (!Window.IsInstalled()) {
      DisposeQueue.Instance.Add(this);
      return;
    }

    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_ProgressBar(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }



public class ValueChangedEventArgs : EventArgs
{
   private ProgressBar _progressBar;
   private float _progressValue;
   private float _secondaryProgressValue;

   public ProgressBar ProgressBar
   {
      get
      {
         return _progressBar;
      }
      set
      {
         _progressBar = value;
      }
   }

   public float ProgressValue
   {
      get
      {
         return _progressValue;
      }
      set
      {
         _progressValue = value;
      }
   }

   public float SecondaryProgressValue
   {
      get
      {
         return _secondaryProgressValue;
      }
      set
      {
         _secondaryProgressValue = value;
      }
   }

}

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void ValueChangedCallbackDelegate(IntPtr progressBar, float progressValue, float secondaryProgressValue);
  private DaliEventHandler<object,ValueChangedEventArgs> _progressBarValueChangedEventHandler;
  private ValueChangedCallbackDelegate _progressBarValueChangedCallbackDelegate;

  public event DaliEventHandler<object,ValueChangedEventArgs> ValueChanged
  {
     add
     {
        lock(this)
        {
           // Restricted to only one listener
           if (_progressBarValueChangedEventHandler == null)
           {
              _progressBarValueChangedEventHandler += value;

              _progressBarValueChangedCallbackDelegate = new ValueChangedCallbackDelegate(OnValueChanged);
              this.ValueChangedSignal().Connect(_progressBarValueChangedCallbackDelegate);
           }
        }
     }

     remove
     {
        lock(this)
        {
           if (_progressBarValueChangedEventHandler != null)
           {
              this.ValueChangedSignal().Disconnect(_progressBarValueChangedCallbackDelegate);
           }

           _progressBarValueChangedEventHandler -= value;
        }
     }
  }

  // Callback for ProgressBar ValueChanged signal
  private void OnValueChanged(IntPtr progressBar, float progressValue, float secondaryProgressValue)
  {
     ValueChangedEventArgs e = new ValueChangedEventArgs();

     // Populate all members of "e" (ValueChangedEventArgs) with real page
     e.ProgressBar = ProgressBar.GetProgressBarFromPtr( progressBar );
     e.ProgressValue = progressValue;
     e.SecondaryProgressValue = secondaryProgressValue;

     if (_progressBarValueChangedEventHandler != null)
     {
       _progressBarValueChangedEventHandler(this, e);
     }
  }

  public static ProgressBar GetProgressBarFromPtr(global::System.IntPtr cPtr) {
    ProgressBar ret = new ProgressBar(cPtr, false);
   if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


  public class Property : global::System.IDisposable {
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;
  
    internal Property(global::System.IntPtr cPtr, bool cMemoryOwn) {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }
  
    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj) {
      return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
  
    ~Property() {
      Dispose();
    }
  
    public virtual void Dispose() {
      lock(this) {
        if (swigCPtr.Handle != global::System.IntPtr.Zero) {
          if (swigCMemOwn) {
            swigCMemOwn = false;
            NDalicPINVOKE.delete_ProgressBar_Property(swigCPtr);
          }
          swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        }
        global::System.GC.SuppressFinalize(this);
      }
    }
  
    public Property() : this(NDalicPINVOKE.new_ProgressBar_Property(), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }
  
    public static readonly int PROGRESS_VALUE = NDalicPINVOKE.ProgressBar_Property_PROGRESS_VALUE_get();
    public static readonly int SECONDARY_PROGRESS_VALUE = NDalicPINVOKE.ProgressBar_Property_SECONDARY_PROGRESS_VALUE_get();
    public static readonly int INDETERMINATE = NDalicPINVOKE.ProgressBar_Property_INDETERMINATE_get();
    public static readonly int TRACK_VISUAL = NDalicPINVOKE.ProgressBar_Property_TRACK_VISUAL_get();
    public static readonly int PROGRESS_VISUAL = NDalicPINVOKE.ProgressBar_Property_PROGRESS_VISUAL_get();
    public static readonly int SECONDARY_PROGRESS_VISUAL = NDalicPINVOKE.ProgressBar_Property_SECONDARY_PROGRESS_VISUAL_get();
    public static readonly int INDETERMINATE_VISUAL = NDalicPINVOKE.ProgressBar_Property_INDETERMINATE_VISUAL_get();
    public static readonly int INDETERMINATE_VISUAL_ANIMATION = NDalicPINVOKE.ProgressBar_Property_INDETERMINATE_VISUAL_ANIMATION_get();
    public static readonly int LABEL_VISUAL = NDalicPINVOKE.ProgressBar_Property_LABEL_VISUAL_get();
  
  }

  public ProgressBar () : this (NDalicPINVOKE.ProgressBar_New(), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public ProgressBar(ProgressBar handle) : this(NDalicPINVOKE.new_ProgressBar__SWIG_1(ProgressBar.getCPtr(handle)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public ProgressBar Assign(ProgressBar handle) {
    ProgressBar ret = new ProgressBar(NDalicPINVOKE.ProgressBar_Assign(swigCPtr, ProgressBar.getCPtr(handle)), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new static ProgressBar DownCast(BaseHandle handle) {
    ProgressBar ret = new ProgressBar(NDalicPINVOKE.ProgressBar_DownCast(BaseHandle.getCPtr(handle)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ProgressBarValueChangedSignal ValueChangedSignal() {
    ProgressBarValueChangedSignal ret = new ProgressBarValueChangedSignal(NDalicPINVOKE.ProgressBar_ValueChangedSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public enum PropertyRange {
    PROPERTY_START_INDEX = PropertyRanges.PROPERTY_REGISTRATION_START_INDEX,
    PROPERTY_END_INDEX = View.PropertyRange.PROPERTY_START_INDEX+1000
  }

  public float ProgressValue
  {
    get
    {
      float temp = 0.0f;
      GetProperty( ProgressBar.Property.PROGRESS_VALUE).Get( ref temp );
      return temp;
    }
    set
    {
      SetProperty( ProgressBar.Property.PROGRESS_VALUE, new Dali.Property.Value( value ) );
    }
  }
  public float SecondaryProgressValue
  {
    get
    {
      float temp = 0.0f;
      GetProperty( ProgressBar.Property.SECONDARY_PROGRESS_VALUE).Get( ref temp );
      return temp;
    }
    set
    {
      SetProperty( ProgressBar.Property.SECONDARY_PROGRESS_VALUE, new Dali.Property.Value( value ) );
    }
  }
  public bool Indeterminate
  {
    get
    {
      bool temp = false;
      GetProperty( ProgressBar.Property.INDETERMINATE).Get( ref temp );
      return temp;
    }
    set
    {
      SetProperty( ProgressBar.Property.INDETERMINATE, new Dali.Property.Value( value ) );
    }
  }
  public Dali.Property.Map TrackVisual
  {
    get
    {
      Dali.Property.Map temp = new Dali.Property.Map();
      GetProperty( ProgressBar.Property.TRACK_VISUAL).Get(  temp );
      return temp;
    }
    set
    {
      SetProperty( ProgressBar.Property.TRACK_VISUAL, new Dali.Property.Value( value ) );
    }
  }
  public Dali.Property.Map ProgressVisual
  {
    get
    {
      Dali.Property.Map temp = new Dali.Property.Map();
      GetProperty( ProgressBar.Property.PROGRESS_VISUAL).Get(  temp );
      return temp;
    }
    set
    {
      SetProperty( ProgressBar.Property.PROGRESS_VISUAL, new Dali.Property.Value( value ) );
    }
  }
  public Dali.Property.Map SecondaryProgressVisual
  {
    get
    {
      Dali.Property.Map temp = new Dali.Property.Map();
      GetProperty( ProgressBar.Property.SECONDARY_PROGRESS_VISUAL).Get(  temp );
      return temp;
    }
    set
    {
      SetProperty( ProgressBar.Property.SECONDARY_PROGRESS_VISUAL, new Dali.Property.Value( value ) );
    }
  }
  public Dali.Property.Map IndeterminateVisual
  {
    get
    {
      Dali.Property.Map temp = new Dali.Property.Map();
      GetProperty( ProgressBar.Property.INDETERMINATE_VISUAL).Get(  temp );
      return temp;
    }
    set
    {
      SetProperty( ProgressBar.Property.INDETERMINATE_VISUAL, new Dali.Property.Value( value ) );
    }
  }
  public Dali.Property.Array IndeterminateVisualAnimation
  {
    get
    {
      Dali.Property.Array temp = new Dali.Property.Array();
      GetProperty( ProgressBar.Property.INDETERMINATE_VISUAL_ANIMATION).Get(  temp );
      return temp;
    }
    set
    {
      SetProperty( ProgressBar.Property.INDETERMINATE_VISUAL_ANIMATION, new Dali.Property.Value( value ) );
    }
  }
  public Dali.Property.Map LabelVisual
  {
    get
    {
      Dali.Property.Map temp = new Dali.Property.Map();
      GetProperty( ProgressBar.Property.LABEL_VISUAL).Get(  temp );
      return temp;
    }
    set
    {
      SetProperty( ProgressBar.Property.LABEL_VISUAL, new Dali.Property.Value( value ) );
    }
  }

}

}
