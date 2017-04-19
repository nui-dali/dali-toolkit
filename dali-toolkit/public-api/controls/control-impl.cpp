/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

// CLASS HEADER
#include <dali-toolkit/public-api/controls/control-impl.h>

// EXTERNAL INCLUDES
#include <cstring> // for strcmp
#include <limits>
#include <stack>
#include <typeinfo>
#include <dali/public-api/animation/constraint.h>
#include <dali/public-api/object/type-registry-helper.h>
#include <dali/public-api/size-negotiation/relayout-container.h>
#include <dali/devel-api/object/handle-devel.h>
#include <dali/devel-api/scripting/scripting.h>
#include <dali/integration-api/debug.h>

// INTERNAL INCLUDES
#include <dali-toolkit/public-api/focus-manager/keyboard-focus-manager.h>
#include <dali-toolkit/public-api/controls/control.h>
#include <dali-toolkit/public-api/styling/style-manager.h>
#include <dali-toolkit/public-api/visuals/color-visual-properties.h>
#include <dali-toolkit/devel-api/controls/control-depth-index-ranges.h>
#include <dali-toolkit/devel-api/controls/control-devel.h>
#include <dali-toolkit/devel-api/visuals/visual-properties-devel.h>
#include <dali-toolkit/devel-api/focus-manager/keyinput-focus-manager.h>
#include <dali-toolkit/internal/styling/style-manager-impl.h>
#include <dali-toolkit/internal/visuals/color/color-visual.h>
#include <dali-toolkit/internal/visuals/visual-string-constants.h>
#include <dali-toolkit/devel-api/align-enums.h>
#include <dali-toolkit/internal/controls/control/control-data-impl.h>

namespace Dali
{

namespace Toolkit
{

namespace Internal
{

namespace
{

#if defined(DEBUG_ENABLED)
Debug::Filter* gLogFilter = Debug::Filter::New( Debug::NoLogging, false, "LOG_CONTROL_VISUALS");
#endif

DALI_ENUM_TO_STRING_TABLE_BEGIN( CLIPPING_MODE )
DALI_ENUM_TO_STRING_WITH_SCOPE( ClippingMode, DISABLED )
DALI_ENUM_TO_STRING_WITH_SCOPE( ClippingMode, CLIP_CHILDREN )
DALI_ENUM_TO_STRING_TABLE_END( CLIPPING_MODE )

/**
 *  Finds visual in given array, returning true if found along with the iterator for that visual as a out parameter
 */
bool FindVisual( Property::Index targetIndex, RegisteredVisualContainer& visuals, RegisteredVisualContainer::Iterator& iter )
{
  for ( iter = visuals.Begin(); iter != visuals.End(); iter++ )
  {
    if ( (*iter)->index ==  targetIndex )
    {
      return true;
    }
  }
  return false;
}

Toolkit::Visual::Base GetVisualByName(
  RegisteredVisualContainer& visuals,
  const std::string& visualName )
{
  Toolkit::Visual::Base visualHandle;

  RegisteredVisualContainer::Iterator iter;
  for ( iter = visuals.Begin(); iter != visuals.End(); iter++ )
  {
    Toolkit::Visual::Base visual = (*iter)->visual;
    if( visual && visual.GetName() == visualName )
    {
      visualHandle = visual;
      break;
    }
  }
  return visualHandle;
}

} // unnamed namespace



Toolkit::Control Control::New()
{
  // Create the implementation, temporarily owned on stack
  IntrusivePtr<Control> controlImpl = new Control( ControlBehaviour( CONTROL_BEHAVIOUR_DEFAULT ) );

  // Pass ownership to handle
  Toolkit::Control handle( *controlImpl );

  // Second-phase init of the implementation
  // This can only be done after the CustomActor connection has been made...
  controlImpl->Initialize();

  return handle;
}

void Control::SetStyleName( const std::string& styleName )
{
  if( styleName != mImpl->mStyleName )
  {
    mImpl->mStyleName = styleName;

    // Apply new style, if stylemanager is available
    Toolkit::StyleManager styleManager = Toolkit::StyleManager::Get();
    if( styleManager )
    {
      GetImpl( styleManager ).ApplyThemeStyle( Toolkit::Control( GetOwner() ) );
    }
  }
}

const std::string& Control::GetStyleName() const
{
  return mImpl->mStyleName;
}

void Control::SetBackgroundColor( const Vector4& color )
{
  mImpl->mBackgroundColor = color;
  Property::Map map;
  map[ Toolkit::DevelVisual::Property::TYPE ] = Toolkit::Visual::COLOR;
  map[ Toolkit::ColorVisual::Property::MIX_COLOR ] = color;

  SetBackground( map );
}

Vector4 Control::GetBackgroundColor() const
{
  return mImpl->mBackgroundColor;
}

void Control::SetBackground( const Property::Map& map )
{
  Toolkit::Visual::Base visual = Toolkit::VisualFactory::Get().CreateVisual( map );
  if( visual )
  {
    RegisterVisual( Toolkit::Control::Property::BACKGROUND, visual );
    visual.SetDepthIndex( DepthIndex::BACKGROUND );

    // Trigger a size negotiation request that may be needed by the new visual to relayout its contents.
    RelayoutRequest();
  }
}

void Control::SetBackgroundImage( Image image )
{
  Toolkit::Visual::Base visual = Toolkit::VisualFactory::Get().CreateVisual( image );
  if( visual )
  {
    RegisterVisual( Toolkit::Control::Property::BACKGROUND, visual );
    visual.SetDepthIndex( DepthIndex::BACKGROUND );
  }
}

void Control::ClearBackground()
{
   UnregisterVisual( Toolkit::Control::Property::BACKGROUND );
   mImpl->mBackgroundColor = Color::TRANSPARENT;

   // Trigger a size negotiation request that may be needed when unregistering a visual.
   RelayoutRequest();
}

void Control::EnableGestureDetection(Gesture::Type type)
{
  if ( (type & Gesture::Pinch) && !mImpl->mPinchGestureDetector )
  {
    mImpl->mPinchGestureDetector = PinchGestureDetector::New();
    mImpl->mPinchGestureDetector.DetectedSignal().Connect(mImpl, &Impl::PinchDetected);
    mImpl->mPinchGestureDetector.Attach(Self());
  }

  if ( (type & Gesture::Pan) && !mImpl->mPanGestureDetector )
  {
    mImpl->mPanGestureDetector = PanGestureDetector::New();
    mImpl->mPanGestureDetector.DetectedSignal().Connect(mImpl, &Impl::PanDetected);
    mImpl->mPanGestureDetector.Attach(Self());
  }

  if ( (type & Gesture::Tap) && !mImpl->mTapGestureDetector )
  {
    mImpl->mTapGestureDetector = TapGestureDetector::New();
    mImpl->mTapGestureDetector.DetectedSignal().Connect(mImpl, &Impl::TapDetected);
    mImpl->mTapGestureDetector.Attach(Self());
  }

  if ( (type & Gesture::LongPress) && !mImpl->mLongPressGestureDetector )
  {
    mImpl->mLongPressGestureDetector = LongPressGestureDetector::New();
    mImpl->mLongPressGestureDetector.DetectedSignal().Connect(mImpl, &Impl::LongPressDetected);
    mImpl->mLongPressGestureDetector.Attach(Self());
  }
}

void Control::DisableGestureDetection(Gesture::Type type)
{
  if ( (type & Gesture::Pinch) && mImpl->mPinchGestureDetector )
  {
    mImpl->mPinchGestureDetector.Detach(Self());
    mImpl->mPinchGestureDetector.Reset();
  }

  if ( (type & Gesture::Pan) && mImpl->mPanGestureDetector )
  {
    mImpl->mPanGestureDetector.Detach(Self());
    mImpl->mPanGestureDetector.Reset();
  }

  if ( (type & Gesture::Tap) && mImpl->mTapGestureDetector )
  {
    mImpl->mTapGestureDetector.Detach(Self());
    mImpl->mTapGestureDetector.Reset();
  }

  if ( (type & Gesture::LongPress) && mImpl->mLongPressGestureDetector)
  {
    mImpl->mLongPressGestureDetector.Detach(Self());
    mImpl->mLongPressGestureDetector.Reset();
  }
}

PinchGestureDetector Control::GetPinchGestureDetector() const
{
  return mImpl->mPinchGestureDetector;
}

PanGestureDetector Control::GetPanGestureDetector() const
{
  return mImpl->mPanGestureDetector;
}

TapGestureDetector Control::GetTapGestureDetector() const
{
  return mImpl->mTapGestureDetector;
}

LongPressGestureDetector Control::GetLongPressGestureDetector() const
{
  return mImpl->mLongPressGestureDetector;
}

void Control::SetKeyboardNavigationSupport(bool isSupported)
{
  mImpl->mIsKeyboardNavigationSupported = isSupported;
}

bool Control::IsKeyboardNavigationSupported()
{
  return mImpl->mIsKeyboardNavigationSupported;
}

void Control::SetKeyInputFocus()
{
  if( Self().OnStage() )
  {
    Toolkit::KeyInputFocusManager::Get().SetFocus(Toolkit::Control::DownCast(Self()));
  }
}

bool Control::HasKeyInputFocus()
{
  bool result = false;
  if( Self().OnStage() )
  {
    Toolkit::Control control = Toolkit::KeyInputFocusManager::Get().GetCurrentFocusControl();
    if( Self() == control )
    {
      result = true;
    }
  }
  return result;
}

void Control::ClearKeyInputFocus()
{
  if( Self().OnStage() )
  {
    Toolkit::KeyInputFocusManager::Get().RemoveFocus(Toolkit::Control::DownCast(Self()));
  }
}

void Control::SetAsKeyboardFocusGroup(bool isFocusGroup)
{
  mImpl->mIsKeyboardFocusGroup = isFocusGroup;

  // The following line will be removed when the deprecated API in KeyboardFocusManager is deleted
  Toolkit::KeyboardFocusManager::Get().SetAsFocusGroup(Self(), isFocusGroup);
}

bool Control::IsKeyboardFocusGroup()
{
  return Toolkit::KeyboardFocusManager::Get().IsFocusGroup(Self());
}

void Control::AccessibilityActivate()
{
  // Inform deriving classes
  OnAccessibilityActivated();
}

void Control::KeyboardEnter()
{
  // Inform deriving classes
  OnKeyboardEnter();
}

void Control::RegisterVisual( Property::Index index, Toolkit::Visual::Base& visual )
{
  RegisterVisual( index, visual, true );
}

void Control::RegisterVisual( Property::Index index, Toolkit::Visual::Base& visual, bool enabled )
{
  bool visualReplaced ( false );
  Actor self = Self();

  if( !mImpl->mVisuals.Empty() )
  {
    RegisteredVisualContainer::Iterator iter;
    // Check if visual (index) is already registered.  Replace if so.
    if ( FindVisual( index, mImpl->mVisuals, iter ) )
    {
      if( (*iter)->visual && self.OnStage() )
      {
        Toolkit::GetImplementation((*iter)->visual).SetOffStage( self );
      }

      mImpl->StopObservingVisual( (*iter)->visual );
      mImpl->StartObservingVisual( visual );

      (*iter)->visual = visual;
      visualReplaced = true;
    }
  }

  // If not set, set the name of the visual to the same name as the control's property.
  // ( If the control has been type registered )
  if( visual.GetName().empty() )
  {
    // Check if the control has been type registered:
    TypeInfo typeInfo = TypeRegistry::Get().GetTypeInfo( typeid(*this) );
    if( typeInfo )
    {
      // Check if the property index has been registered:
      Property::IndexContainer indices;
      typeInfo.GetPropertyIndices( indices );
      Property::IndexContainer::Iterator iter = std::find( indices.Begin(), indices.End(), index );
      if( iter != indices.End() )
      {
        // If it has, then get it's name and use that for the visual
        std::string visualName = typeInfo.GetPropertyName( index );
        visual.SetName( visualName );
      }
    }
  }

  if( !visualReplaced ) // New registration entry
  {
    mImpl->mVisuals.PushBack( new RegisteredVisual( index, visual, enabled ) );

    // monitor when the visuals resources are ready
    mImpl->StartObservingVisual( visual );

  }

  if( visual && self.OnStage() && enabled )
  {
    Toolkit::GetImplementation(visual).SetOnStage( self );
  }

  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "Control::RegisterVisual() Registered %s(%d), enabled:%s\n",  visual.GetName().c_str(), index, enabled?"T":"F" );
}

void Control::UnregisterVisual( Property::Index index )
{
   RegisteredVisualContainer::Iterator iter;
   if ( FindVisual( index, mImpl->mVisuals, iter ) )
   {
     // stop observing visual
     mImpl->StopObservingVisual( (*iter)->visual );

     Actor self( Self() );
     Toolkit::GetImplementation((*iter)->visual).SetOffStage( self );
     (*iter)->visual.Reset();
     mImpl->mVisuals.Erase( iter );
   }
}

Toolkit::Visual::Base Control::GetVisual( Property::Index index ) const
{
  RegisteredVisualContainer::Iterator iter;
  if ( FindVisual( index, mImpl->mVisuals, iter ) )
  {
    return (*iter)->visual;
  }

  return Toolkit::Visual::Base();
}

void Control::EnableVisual( Property::Index index, bool enable )
{
  RegisteredVisualContainer::Iterator iter;
  if ( FindVisual( index, mImpl->mVisuals, iter ) )
  {
    if (  (*iter)->enabled == enable )
    {
      DALI_LOG_INFO( gLogFilter, Debug::Verbose, "Control::EnableVisual Visual %s(%d) already %s\n", (*iter)->visual.GetName().c_str(), index, enable?"enabled":"disabled");
      return;
    }

    (*iter)->enabled = enable;
    Actor parentActor = Self();
    if ( Self().OnStage() ) // If control not on Stage then Visual will be added when StageConnection is called.
    {
      if ( enable )
      {
        DALI_LOG_INFO( gLogFilter, Debug::Verbose, "Control::EnableVisual Setting %s(%d) on stage \n", (*iter)->visual.GetName().c_str(), index );
        Toolkit::GetImplementation((*iter)->visual).SetOnStage( parentActor );
      }
      else
      {
        DALI_LOG_INFO( gLogFilter, Debug::Verbose, "Control::EnableVisual Setting %s(%d) off stage \n", (*iter)->visual.GetName().c_str(), index );
        Toolkit::GetImplementation((*iter)->visual).SetOffStage( parentActor );  // No need to call if control not staged.
      }
    }
  }
}

bool Control::IsVisualEnabled( Property::Index index ) const
{
  RegisteredVisualContainer::Iterator iter;
  if ( FindVisual( index, mImpl->mVisuals, iter ) )
  {
    return (*iter)->enabled;
  }
  return false;
}

Dali::Animation Control::CreateTransition( const Toolkit::TransitionData& handle )
{
  Dali::Animation transition;
  const Internal::TransitionData& transitionData = Toolkit::GetImplementation( handle );

  if( transitionData.Count() > 0 )
  {
    // Setup a Transition from TransitionData.
    TransitionData::Iterator end = transitionData.End();
    for( TransitionData::Iterator iter = transitionData.Begin() ;
         iter != end; ++iter )
    {
      TransitionData::Animator* animator = (*iter);

      Toolkit::Visual::Base visual = GetVisualByName( mImpl->mVisuals, animator->objectName );

      if( visual )
      {
        Internal::Visual::Base& visualImpl = Toolkit::GetImplementation( visual );
        visualImpl.AnimateProperty( transition, *animator );
      }
      else
      {
        // Otherwise, try any actor children of control (Including the control)
        Actor child = Self().FindChildByName( animator->objectName );
        if( child )
        {
          Property::Index propertyIndex = DevelHandle::GetPropertyIndex( child, animator->propertyKey );
          if( propertyIndex != Property::INVALID_INDEX )
          {
            if( animator->animate == false )
            {
              if( animator->targetValue.GetType() != Property::NONE )
              {
                child.SetProperty( propertyIndex, animator->targetValue );
              }
            }
            else // animate the property
            {
              if( animator->initialValue.GetType() != Property::NONE )
              {
                child.SetProperty( propertyIndex, animator->initialValue );
              }

              if( ! transition )
              {
                transition = Dali::Animation::New( 0.1f );
              }

              transition.AnimateTo( Property( child, propertyIndex ),
                                    animator->targetValue,
                                    animator->alphaFunction,
                                    TimePeriod( animator->timePeriodDelay,
                                                animator->timePeriodDuration ) );
            }
          }
        }
      }
    }
  }

  return transition;
}

bool Control::OnAccessibilityActivated()
{
  return false; // Accessibility activation is not handled by default
}

bool Control::OnKeyboardEnter()
{
  return false; // Keyboard enter is not handled by default
}

bool Control::OnAccessibilityPan(PanGesture gesture)
{
  return false; // Accessibility pan gesture is not handled by default
}

bool Control::OnAccessibilityTouch(const TouchEvent& touchEvent)
{
  return false; // Accessibility touch event is not handled by default
}

bool Control::OnAccessibilityValueChange(bool isIncrease)
{
  return false; // Accessibility value change action is not handled by default
}

bool Control::OnAccessibilityZoom()
{
  return false; // Accessibility zoom action is not handled by default
}

Actor Control::GetNextKeyboardFocusableActor(Actor currentFocusedActor, Toolkit::Control::KeyboardFocus::Direction direction, bool loopEnabled)
{
  return Actor();
}

void Control::OnKeyboardFocusChangeCommitted(Actor commitedFocusableActor)
{
}

Toolkit::Control::KeyEventSignalType& Control::KeyEventSignal()
{
  return mImpl->mKeyEventSignal;
}

Toolkit::Control::KeyInputFocusSignalType& Control::KeyInputFocusGainedSignal()
{
  return mImpl->mKeyInputFocusGainedSignal;
}

Toolkit::Control::KeyInputFocusSignalType& Control::KeyInputFocusLostSignal()
{
  return mImpl->mKeyInputFocusLostSignal;
}

bool Control::EmitKeyEventSignal( const KeyEvent& event )
{
  // Guard against destruction during signal emission
  Dali::Toolkit::Control handle( GetOwner() );

  bool consumed = false;

  // signals are allocated dynamically when someone connects
  if ( !mImpl->mKeyEventSignal.Empty() )
  {
    consumed = mImpl->mKeyEventSignal.Emit( handle, event );
  }

  if (!consumed)
  {
    // Notification for derived classes
    consumed = OnKeyEvent(event);
  }

  return consumed;
}

Control::Control( ControlBehaviour behaviourFlags )
: CustomActorImpl( static_cast< ActorFlags >( behaviourFlags ) ),
  mImpl(new Impl(*this))
{
  mImpl->mFlags = behaviourFlags;
}

Control::~Control()
{
  delete mImpl;
}

void Control::Initialize()
{
  // Call deriving classes so initialised before styling is applied to them.
  OnInitialize();

  if( (mImpl->mFlags & REQUIRES_STYLE_CHANGE_SIGNALS) ||
      !(mImpl->mFlags & DISABLE_STYLE_CHANGE_SIGNALS) )
  {
    Toolkit::StyleManager styleManager = StyleManager::Get();

    // if stylemanager is available
    if( styleManager )
    {
      StyleManager& styleManagerImpl = GetImpl( styleManager );

      // Register for style changes
      styleManagerImpl.ControlStyleChangeSignal().Connect( this, &Control::OnStyleChange );

      // Apply the current style
      styleManagerImpl.ApplyThemeStyleAtInit( Toolkit::Control( GetOwner() ) );
    }
  }

  if( mImpl->mFlags & REQUIRES_KEYBOARD_NAVIGATION_SUPPORT )
  {
    SetKeyboardNavigationSupport( true );
  }
}

void Control::OnInitialize()
{
}

void Control::OnControlChildAdd( Actor& child )
{
}

void Control::OnControlChildRemove( Actor& child )
{
}

void Control::OnStyleChange( Toolkit::StyleManager styleManager, StyleChange::Type change )
{
  // By default the control is only interested in theme (not font) changes
  if( styleManager && change == StyleChange::THEME_CHANGE )
  {
    GetImpl( styleManager ).ApplyThemeStyle( Toolkit::Control( GetOwner() ) );
    RelayoutRequest();
  }
}

void Control::OnPinch(const PinchGesture& pinch)
{
  if( !( mImpl->mStartingPinchScale ) )
  {
    // lazy allocate
    mImpl->mStartingPinchScale = new Vector3;
  }

  if( pinch.state == Gesture::Started )
  {
    *( mImpl->mStartingPinchScale ) = Self().GetCurrentScale();
  }

  Self().SetScale( *( mImpl->mStartingPinchScale ) * pinch.scale );
}

void Control::OnPan( const PanGesture& pan )
{
}

void Control::OnTap(const TapGesture& tap)
{
}

void Control::OnLongPress( const LongPressGesture& longPress )
{
}

void Control::EmitKeyInputFocusSignal( bool focusGained )
{
  Dali::Toolkit::Control handle( GetOwner() );

  if ( focusGained )
  {
    // signals are allocated dynamically when someone connects
    if ( !mImpl->mKeyInputFocusGainedSignal.Empty() )
    {
      mImpl->mKeyInputFocusGainedSignal.Emit( handle );
    }
  }
  else
  {
    // signals are allocated dynamically when someone connects
    if ( !mImpl->mKeyInputFocusLostSignal.Empty() )
    {
      mImpl->mKeyInputFocusLostSignal.Emit( handle );
    }
  }
}

void Control::OnStageConnection( int depth )
{
  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "Control::OnStageConnection number of registered visuals(%d)\n",  mImpl->mVisuals.Size() );

  Actor self( Self() );

  for(RegisteredVisualContainer::Iterator iter = mImpl->mVisuals.Begin(); iter!= mImpl->mVisuals.End(); iter++)
  {
    // Check whether the visual is empty and enabled
    if( (*iter)->visual && (*iter)->enabled )
    {
      DALI_LOG_INFO( gLogFilter, Debug::Verbose, "Control::OnStageConnection Setting visual(%d) on stage\n", (*iter)->index );
      Toolkit::GetImplementation((*iter)->visual).SetOnStage( self );
    }
  }

  if( mImpl->mVisuals.Empty() && ! self.GetRendererCount() )
  {
    Property::Value clippingValue = self.GetProperty( Actor::Property::CLIPPING_MODE );
    int clippingMode = ClippingMode::DISABLED;
    if( clippingValue.Get( clippingMode ) )
    {
      // Add a transparent background if we do not have any renderers or visuals so we clip our children

      if( clippingMode == ClippingMode::CLIP_CHILDREN )
      {
        // Create a transparent background visual which will also get staged.
        SetBackgroundColor( Color::TRANSPARENT );
      }
    }
  }
}

void Control::OnStageDisconnection()
{
  for(RegisteredVisualContainer::Iterator iter = mImpl->mVisuals.Begin(); iter!= mImpl->mVisuals.End(); iter++)
  {
    // Check whether the visual is empty
    if( (*iter)->visual )
    {
      DALI_LOG_INFO( gLogFilter, Debug::Verbose, "Control::OnStageDisconnection Setting visual(%d) off stage\n", (*iter)->index );
      Actor self( Self() );
      Toolkit::GetImplementation((*iter)->visual).SetOffStage( self );
    }
  }
}

void Control::OnKeyInputFocusGained()
{
  EmitKeyInputFocusSignal( true );
}

void Control::OnKeyInputFocusLost()
{
  EmitKeyInputFocusSignal( false );
}

void Control::OnChildAdd(Actor& child)
{
  // Notify derived classes.
  OnControlChildAdd( child );
}

void Control::OnChildRemove(Actor& child)
{
  // Notify derived classes.
  OnControlChildRemove( child );
}

void Control::OnPropertySet( Property::Index index, Property::Value propertyValue )
{
  Actor self( Self() );
  if( index == Actor::Property::CLIPPING_MODE )
  {
    // Only set the background if we're already on the stage and have no renderers or visuals

    if( mImpl->mVisuals.Empty() && ! self.GetRendererCount() && self.OnStage() )
    {
      ClippingMode::Type clippingMode = ClippingMode::DISABLED;
      if( Scripting::GetEnumerationProperty< ClippingMode::Type >( propertyValue, CLIPPING_MODE_TABLE, CLIPPING_MODE_TABLE_COUNT, clippingMode ) )
      {
        // Add a transparent background if we do not have one so we clip children

        if( clippingMode == ClippingMode::CLIP_CHILDREN )
        {
          SetBackgroundColor( Color::TRANSPARENT );
        }
      }
    }
  }
}

void Control::OnSizeSet(const Vector3& targetSize)
{
  Toolkit::Visual::Base visual = GetVisual( Toolkit::Control::Property::BACKGROUND );
  if( visual )
  {
    Vector2 size( targetSize );
    visual.SetTransformAndSize( Property::Map(), size ); // Send an empty map as we do not want to modify the visual's set transform
  }
}

void Control::OnSizeAnimation(Animation& animation, const Vector3& targetSize)
{
  // @todo size negotiate background to new size, animate as well?
}

bool Control::OnTouchEvent(const TouchEvent& event)
{
  return false; // Do not consume
}

bool Control::OnHoverEvent(const HoverEvent& event)
{
  return false; // Do not consume
}

bool Control::OnKeyEvent(const KeyEvent& event)
{
  return false; // Do not consume
}

bool Control::OnWheelEvent(const WheelEvent& event)
{
  return false; // Do not consume
}

void Control::OnRelayout( const Vector2& size, RelayoutContainer& container )
{
  for( unsigned int i = 0, numChildren = Self().GetChildCount(); i < numChildren; ++i )
  {
    container.Add( Self().GetChildAt( i ), size );
  }

  Toolkit::Visual::Base visual = GetVisual( Toolkit::Control::Property::BACKGROUND );
  if( visual )
  {
    visual.SetTransformAndSize( Property::Map(), size ); // Send an empty map as we do not want to modify the visual's set transform
  }
}

void Control::OnSetResizePolicy( ResizePolicy::Type policy, Dimension::Type dimension )
{
}

Vector3 Control::GetNaturalSize()
{
  Toolkit::Visual::Base visual = GetVisual( Toolkit::Control::Property::BACKGROUND );
  if( visual )
  {
    Vector2 naturalSize;
    visual.GetNaturalSize( naturalSize );
    return Vector3( naturalSize );
  }
  return Vector3::ZERO;
}

float Control::CalculateChildSize( const Dali::Actor& child, Dimension::Type dimension )
{
  return CalculateChildSizeBase( child, dimension );
}

float Control::GetHeightForWidth( float width )
{
  return GetHeightForWidthBase( width );
}

float Control::GetWidthForHeight( float height )
{
  return GetWidthForHeightBase( height );
}

bool Control::RelayoutDependentOnChildren( Dimension::Type dimension )
{
  return RelayoutDependentOnChildrenBase( dimension );
}

void Control::OnCalculateRelayoutSize( Dimension::Type dimension )
{
}

void Control::OnLayoutNegotiated( float size, Dimension::Type dimension )
{
}

void Control::SignalConnected( SlotObserver* slotObserver, CallbackBase* callback )
{
  mImpl->SignalConnected( slotObserver, callback );
}

void Control::SignalDisconnected( SlotObserver* slotObserver, CallbackBase* callback )
{
  mImpl->SignalDisconnected( slotObserver, callback );
}

Control& GetImplementation( Dali::Toolkit::Control& handle )
{
  CustomActorImpl& customInterface = handle.GetImplementation();
  // downcast to control
  Control& impl = dynamic_cast< Internal::Control& >( customInterface );
  return impl;
}

const Control& GetImplementation( const Dali::Toolkit::Control& handle )
{
  const CustomActorImpl& customInterface = handle.GetImplementation();
  // downcast to control
  const Control& impl = dynamic_cast< const Internal::Control& >( customInterface );
  return impl;
}

} // namespace Internal

} // namespace Toolkit

} // namespace Dali
