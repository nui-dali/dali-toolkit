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

public class Window : BaseHandle {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  private global::System.Runtime.InteropServices.HandleRef stageCPtr;

  internal Window(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Window_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    stageCPtr = new global::System.Runtime.InteropServices.HandleRef(this, NDalicPINVOKE.Stage_GetCurrent());
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Window obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Window() {
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
          NDalicPINVOKE.delete_Window(swigCPtr);
          NDalicPINVOKE.delete_Stage(stageCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }


  public static bool IsInstalled() {
    bool ret = NDalicPINVOKE.Stage_IsInstalled();
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }
    public void SetAcceptFocus( bool accept )
    {
      NDalicPINVOKE.SetAcceptFocus(swigCPtr, accept);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }

    public bool IsFocusAcceptable()
    {
      return NDalicPINVOKE.IsFocusAcceptable(swigCPtr);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }

    public void Show()
    {
      NDalicPINVOKE.Show(swigCPtr);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }

    public void Hide()
    {
      NDalicPINVOKE.Hide(swigCPtr);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }

    public void IsVisible()
    {
      NDalicPINVOKE.IsVisible(swigCPtr);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }

    public class WindowFocusChangedEventArgs : EventArgs
    {
        public bool FocusGained
        {
            get;
            set;
        }
    }

    private WindowFocusChangedEventCallbackType _windowFocusChangedEventCallback;
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    private delegate void WindowFocusChangedEventCallbackType(bool focusGained);
    private event EventHandler<WindowFocusChangedEventArgs> _windowFocusChangedEventHandler;

    public event EventHandler<WindowFocusChangedEventArgs> WindowFocusChanged
    {
        add
        {
            if (_windowFocusChangedEventHandler == null)
            {
                _windowFocusChangedEventCallback = OnWindowFocusedChanged;
                WindowFocusChangedSignal().Connect(_windowFocusChangedEventCallback);
            }

            _windowFocusChangedEventHandler += value;
        }
        remove
        {
            _windowFocusChangedEventHandler -= value;

            if (_windowFocusChangedEventHandler == null && _windowFocusChangedEventCallback != null)
            {
                WindowFocusChangedSignal().Disconnect(_windowFocusChangedEventCallback);
            }
        }
    }

    private void OnWindowFocusedChanged(bool focusGained)
    {
        WindowFocusChangedEventArgs e = new WindowFocusChangedEventArgs();

        e.FocusGained = focusGained;

        if (_windowFocusChangedEventHandler != null)
        {
            _windowFocusChangedEventHandler(this, e);
        }
    }

    public WindowFocusSignalType WindowFocusChangedSignal() {
      WindowFocusSignalType ret = new WindowFocusSignalType(NDalicPINVOKE.FocusChangedSignal(swigCPtr), false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }


  public Window (Rectangle windowPosition, string name, bool isTransparent) : this (NDalicPINVOKE.Window_New__SWIG_0(Rectangle.getCPtr(windowPosition), name, isTransparent), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public Window (Rectangle windowPosition, string name) : this (NDalicPINVOKE.Window_New__SWIG_1(Rectangle.getCPtr(windowPosition), name), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public Window (Rectangle windowPosition, string name, string className, bool isTransparent) : this (NDalicPINVOKE.Window_New__SWIG_2(Rectangle.getCPtr(windowPosition), name, className, isTransparent), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public Window (Rectangle windowPosition, string name, string className) : this (NDalicPINVOKE.Window_New__SWIG_3(Rectangle.getCPtr(windowPosition), name, className), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public Window(Window handle) : this(NDalicPINVOKE.new_Window__SWIG_1(Window.getCPtr(handle)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Window Assign(Window rhs) {
    Window ret = new Window(NDalicPINVOKE.Window_Assign(swigCPtr, Window.getCPtr(rhs)), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void ShowIndicator(Window.IndicatorVisibleMode visibleMode) {
    NDalicPINVOKE.Window_ShowIndicator(swigCPtr, (int)visibleMode);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetIndicatorBgOpacity(Window.IndicatorBgOpacity opacity) {
    NDalicPINVOKE.Window_SetIndicatorBgOpacity(swigCPtr, (int)opacity);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RotateIndicator(Window.WindowOrientation orientation) {
    NDalicPINVOKE.Window_RotateIndicator(swigCPtr, (int)orientation);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetClass(string name, string klass) {
    NDalicPINVOKE.Window_SetClass(swigCPtr, name, klass);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Raise() {
    NDalicPINVOKE.Window_Raise(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Lower() {
    NDalicPINVOKE.Window_Lower(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Activate() {
    NDalicPINVOKE.Window_Activate(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void AddAvailableOrientation(Window.WindowOrientation orientation) {
    NDalicPINVOKE.Window_AddAvailableOrientation(swigCPtr, (int)orientation);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveAvailableOrientation(Window.WindowOrientation orientation) {
    NDalicPINVOKE.Window_RemoveAvailableOrientation(swigCPtr, (int)orientation);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetPreferredOrientation(Window.WindowOrientation orientation) {
    NDalicPINVOKE.Window_SetPreferredOrientation(swigCPtr, (int)orientation);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Window.WindowOrientation GetPreferredOrientation() {
    Window.WindowOrientation ret = (Window.WindowOrientation)NDalicPINVOKE.Window_GetPreferredOrientation(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public DragAndDropDetector GetDragAndDropDetector() {
    DragAndDropDetector ret = new DragAndDropDetector(NDalicPINVOKE.Window_GetDragAndDropDetector(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Any GetNativeHandle() {
    Any ret = new Any(NDalicPINVOKE.Window_GetNativeHandle(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public WindowFocusSignalType FocusChangedSignal() {
    WindowFocusSignalType ret = new WindowFocusSignalType(NDalicPINVOKE.FocusChangedSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Layer GetDefaultLayer()
  {
    return this.GetRootLayer();
  }

  public void Add(Layer layer)
  {
    NDalicPINVOKE.Stage_Add(stageCPtr, Layer.getCPtr(layer));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Remove(Layer layer)
  {
    NDalicPINVOKE.Stage_Remove(stageCPtr, Layer.getCPtr(layer));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Add(View view) {
    NDalicPINVOKE.Stage_Add(stageCPtr, View.getCPtr(view));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Remove(View view) {
    NDalicPINVOKE.Stage_Remove(stageCPtr, View.getCPtr(view));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Vector2 GetSize() {
    Vector2 ret = new Vector2(NDalicPINVOKE.Stage_GetSize(stageCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public RenderTaskList GetRenderTaskList() {
    RenderTaskList ret = new RenderTaskList(NDalicPINVOKE.Stage_GetRenderTaskList(stageCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public uint GetLayerCount() {
    uint ret = NDalicPINVOKE.Stage_GetLayerCount(stageCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Layer GetLayer(uint depth) {
    Layer ret = new Layer(NDalicPINVOKE.Stage_GetLayer(stageCPtr, depth), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Layer GetRootLayer() {
    Layer ret = new Layer(NDalicPINVOKE.Stage_GetRootLayer(stageCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void SetBackgroundColor(Vector4 color) {
    NDalicPINVOKE.Stage_SetBackgroundColor(stageCPtr, Vector4.getCPtr(color));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Vector4 GetBackgroundColor() {
    Vector4 ret = new Vector4(NDalicPINVOKE.Stage_GetBackgroundColor(stageCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Vector2 GetDpi() {
    Vector2 ret = new Vector2(NDalicPINVOKE.Stage_GetDpi(stageCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ObjectRegistry GetObjectRegistry() {
    ObjectRegistry ret = new ObjectRegistry(NDalicPINVOKE.Stage_GetObjectRegistry(stageCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void KeepRendering(float durationSeconds) {
    NDalicPINVOKE.Stage_KeepRendering(stageCPtr, durationSeconds);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public KeyEventSignal KeyEventSignal() {
    KeyEventSignal ret = new KeyEventSignal(NDalicPINVOKE.Stage_KeyEventSignal(stageCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public VoidSignal EventProcessingFinishedSignal() {
    VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_EventProcessingFinishedSignal(stageCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public TouchSignal TouchSignal() {
    TouchSignal ret = new TouchSignal(NDalicPINVOKE.Stage_TouchSignal(stageCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private StageWheelSignal WheelEventSignal() {
    StageWheelSignal ret = new StageWheelSignal(NDalicPINVOKE.Stage_WheelEventSignal(stageCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public VoidSignal ContextLostSignal() {
    VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_ContextLostSignal(stageCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public VoidSignal ContextRegainedSignal() {
    VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_ContextRegainedSignal(stageCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public VoidSignal SceneCreatedSignal() {
    VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_SceneCreatedSignal(stageCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static Vector4 DEFAULT_BACKGROUND_COLOR {
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Stage_DEFAULT_BACKGROUND_COLOR_get();
      Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  public static Vector4 DEBUG_BACKGROUND_COLOR {
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Stage_DEBUG_BACKGROUND_COLOR_get();
      Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  }

  private static readonly Window instance = Application.Instance.GetWindow();
  public static Window Instance
  {
    get
    {
      return instance;
    }
  }

  public enum WindowOrientation {
    PORTRAIT = 0,
    LANDSCAPE = 90,
    PORTRAIT_INVERSE = 180,
    LANDSCAPE_INVERSE = 270
  }

  public enum IndicatorBgOpacity {
    OPAQUE = 100,
    TRANSLUCENT = 50,
    TRANSPARENT = 0
  }

  public enum IndicatorVisibleMode {
    INVISIBLE = 0,
    VISIBLE = 1,
    AUTO = 2
  }



  /**
    * @brief Event arguments that passed via Touch signal
    *
    */
  public class TouchEventArgs : EventArgs
  {
     private Touch _touch;

     /**
       * @brief Touch - contains the information of touch points
       *
       */
     public Touch Touch
     {
        get
        {
           return _touch;
        }
        set
        {
           _touch = value;
        }
     }
  }

  private event EventHandler<TouchEventArgs> _stageTouchHandler;
  private EventCallbackDelegateType1<IntPtr> _stageTouchCallbackDelegate;

  /**
    * @brief Event for TouchEvent signal which can be used to subscribe/unsubscribe the event handler
    * TouchEvent signal is emitted when the screen is touched and when the touch ends
    * (i.e. the down & up touch events only).
    *
    */
  public event EventHandler<TouchEventArgs> Touch
  {
     add
     {
        lock(this)
        {
          _stageTouchHandler += value;
          _stageTouchCallbackDelegate = OnStageTouch;
          this.TouchSignal().Connect(_stageTouchCallbackDelegate);
        }
     }
     remove
     {
        lock(this)
        {
           if (_stageTouchHandler != null)
           {
              this.TouchSignal().Disconnect(_stageTouchCallbackDelegate);
           }
           _stageTouchHandler -= value;
        }
     }
  }

  private void OnStageTouch(IntPtr data)
  {
    TouchEventArgs e = new TouchEventArgs();

    if( data != null )
    {
      e.Touch = Dali.Touch.GetTouchFromPtr( data );
    }

    if (_stageTouchHandler != null)
    {
      _stageTouchHandler(this, e);
    }
  }

  /**
    * @brief Wheel arguments that passed via Wheel signal
    *
    */
  public class WheelEventArgs : EventArgs
  {
     private Wheel _wheel;

     /**
       * @brief Wheel - store a wheel rolling type MOUSE_WHEEL or CUSTOM_WHEEL
       *
       */
     public Wheel Wheel
     {
        get
        {
           return _wheel;
        }
        set
        {
           _wheel = value;
        }
     }
  }

  private event EventHandler<WheelEventArgs> _stageWheelHandler;
  private EventCallbackDelegateType1<IntPtr> _stageWheelCallbackDelegate;

  /**
    * @brief Event for Wheel signal which can be used to subscribe/unsubscribe the event handler
    * Wheel signal is emitted is emitted when wheel event is received.
    *
    */
  public event EventHandler<WheelEventArgs> Wheel
  {
     add
     {
        lock(this)
        {
          _stageWheelHandler += value;
          _stageWheelCallbackDelegate = OnStageWheel;
          this.WheelEventSignal().Connect(_stageWheelCallbackDelegate);
        }
     }
     remove
     {
        lock(this)
        {
           if (_stageWheelHandler != null)
           {
              this.WheelEventSignal().Disconnect(_stageWheelCallbackDelegate);
           }
           _stageWheelHandler -= value;
        }
     }
  }

  private void OnStageWheel(IntPtr data)
  {
    WheelEventArgs e = new WheelEventArgs();

    if( data != null )
    {
      e.Wheel = Dali.Wheel.GetWheelFromPtr( data );
    }

    if (_stageWheelHandler != null)
    {
      _stageWheelHandler(this, e);
    }
  }

  /**
    * @brief Event arguments that passed via Key signal
    *
    */
  public class KeyEventArgs : EventArgs
  {
     private Key _key;

     /**
       * @brief Key - is the keyevent sent to Stage.
       *
       */
     public Key Key
     {
        get
        {
           return _key;
        }
        set
        {
           _key = value;
        }
     }
  }

  private event EventHandler<KeyEventArgs> _stageKeyHandler;
  private EventCallbackDelegateType1<IntPtr> _stageKeyCallbackDelegate;

  /**
    * @brief Event for Key signal which can be used to subscribe/unsubscribe the event handler
    * Key signal is emitted is emitted when key event is received.
    *
    */
  public event EventHandler<KeyEventArgs> Key
  {
     add
     {
        lock(this)
        {
            _stageKeyHandler += value;
            _stageKeyCallbackDelegate = OnStageKey;
            this.KeyEventSignal().Connect(_stageKeyCallbackDelegate);
        }
     }
     remove
     {
        lock(this)
        {
           if (_stageKeyHandler != null)
           {
              this.KeyEventSignal().Disconnect(_stageKeyCallbackDelegate);
           }
           _stageKeyHandler -= value;
        }
     }
  }

  // Callback for Stage KeyEventsignal
  private void OnStageKey(IntPtr data)
  {
    KeyEventArgs e = new KeyEventArgs();

    if( data != null )
    {
      e.Key = Dali.Key.GetKeyFromPtr( data );
    }

    if (_stageKeyHandler != null)
    {
      //here we send all data to user event handlers
      _stageKeyHandler(this, e);
    }
  }


  private event EventHandler _stageEventProcessingFinishedEventHandler;
  private EventCallbackDelegateType0 _stageEventProcessingFinishedEventCallbackDelegate;

  /**
    * @brief Event for EventProcessingFinished signal which can be used to subscribe/unsubscribe the event handler
    * provided by the user. EventProcessingFinished signal is emitted just after the event processing is finished.
    *
    */
  public event EventHandler EventProcessingFinished
  {
     add
     {
        lock(this)
        {
          _stageEventProcessingFinishedEventHandler += value;
          _stageEventProcessingFinishedEventCallbackDelegate = OnEventProcessingFinished;
          this.EventProcessingFinishedSignal().Connect(_stageEventProcessingFinishedEventCallbackDelegate);
        }
     }
     remove
     {
        lock(this)
        {
           if (_stageEventProcessingFinishedEventHandler != null)
           {
              this.EventProcessingFinishedSignal().Disconnect(_stageEventProcessingFinishedEventCallbackDelegate);
           }
           _stageEventProcessingFinishedEventHandler -= value;
        }
     }
  }

  // Callback for Stage EventProcessingFinishedSignal
  private void OnEventProcessingFinished()
  {
     if (_stageEventProcessingFinishedEventHandler != null)
     {
        _stageEventProcessingFinishedEventHandler(this, null);
     }
  }


  private EventHandler _stageContextLostEventHandler;
  private EventCallbackDelegateType0 _stageContextLostEventCallbackDelegate;

  /**
    * @brief Event for ContextLost signal which can be used to subscribe/unsubscribe the event handler
    * ContextLost signal is emitted when the GL context is lost (Platform specific behaviour).
    *
    */
  public event EventHandler ContextLost
  {
     add
     {
        lock(this)
        {
            _stageContextLostEventHandler += value;
            _stageContextLostEventCallbackDelegate = OnContextLost;
            this.ContextLostSignal().Connect(_stageContextLostEventCallbackDelegate);
        }
     }
     remove
     {
        lock(this)
        {
           if (_stageContextLostEventHandler != null)
           {
              this.ContextLostSignal().Disconnect(_stageContextLostEventCallbackDelegate);
           }

           _stageContextLostEventHandler -= value;
        }
     }
  }

  // Callback for Stage ContextLostSignal
  private void OnContextLost()
  {
     if (_stageContextLostEventHandler != null)
     {
        _stageContextLostEventHandler(this, null);
     }
  }


  private EventHandler _stageContextRegainedEventHandler;
  private EventCallbackDelegateType0 _stageContextRegainedEventCallbackDelegate;

  /**
    * @brief Event for ContextRegained signal which can be used to subscribe/unsubscribe the event handler
    * provided by the user. ContextRegained signal is emitted when the GL context is regained (Platform specific
    * behaviour).
    *
    */
  public event EventHandler ContextRegained
  {
     add
     {
        lock(this)
        {
            _stageContextRegainedEventHandler += value;
            _stageContextRegainedEventCallbackDelegate = OnContextRegained;
            this.ContextRegainedSignal().Connect(_stageContextRegainedEventCallbackDelegate);
        }
     }
     remove
     {
        lock(this)
        {
           if (_stageContextRegainedEventHandler != null)
           {
              this.ContextRegainedSignal().Disconnect(_stageContextRegainedEventCallbackDelegate);
           }

           _stageContextRegainedEventHandler -= value;
        }
     }
  }

  // Callback for Stage ContextRegainedSignal
  private void OnContextRegained()
  {
     if (_stageContextRegainedEventHandler != null)
     {
        _stageContextRegainedEventHandler(this, null);
     }
  }


  private EventHandler _stageSceneCreatedEventHandler;
  private EventCallbackDelegateType0 _stageSceneCreatedEventCallbackDelegate;

  /**
    * @brief Event for SceneCreated signal which can be used to subscribe/unsubscribe the event handler
    * SceneCreated signal is emitted after the initial scene is created.
    *
    */
  public event EventHandler SceneCreated
  {
     add
     {
        lock(this)
        {
            _stageSceneCreatedEventHandler += value;
            _stageSceneCreatedEventCallbackDelegate = OnSceneCreated;
            this.SceneCreatedSignal().Connect(_stageSceneCreatedEventCallbackDelegate);
        }
     }
     remove
     {
        lock(this)
        {
           if (_stageSceneCreatedEventHandler != null)
           {
              this.SceneCreatedSignal().Disconnect(_stageSceneCreatedEventCallbackDelegate);
           }

           _stageSceneCreatedEventHandler -= value;
        }
     }
  }

  // Callback for Stage SceneCreatedSignal
  private void OnSceneCreated()
  {
     if (_stageSceneCreatedEventHandler != null)
     {
        _stageSceneCreatedEventHandler(this, null);
     }
  }


  public Vector2 Size
  {
     get
     {
        Vector2 ret = GetSize();
        return ret;
     }
  }

  public Vector4 BackgroundColor
  {
     set
     {
        SetBackgroundColor(value);
     }
     get
     {
        Vector4 ret = GetBackgroundColor();
        return ret;
     }
   }

}

}