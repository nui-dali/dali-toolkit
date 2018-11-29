/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
 */

#include <iostream>
#include <stdlib.h>
#include <dali-toolkit-test-suite-utils.h>
#include <toolkit-timer.h>
#include <toolkit-event-thread-callback.h>
#include <dali-toolkit/dali-toolkit.h>
#include <dali-toolkit/devel-api/visual-factory/visual-factory.h>
#include <dali-toolkit/devel-api/controls/control-devel.h>
#include <dali-toolkit/devel-api/visuals/visual-properties-devel.h>
#include <dali-toolkit/devel-api/visuals/image-visual-properties-devel.h>
#include <dali-toolkit/devel-api/visuals/animated-vector-image-visual-actions-devel.h>
#include "dummy-control.h"

using namespace Dali;
using namespace Dali::Toolkit;

void dali_animated_vector_image_visual_startup(void)
{
  test_return_value = TET_UNDEF;
}

void dali_animated_vector_image_visual_cleanup(void)
{
  test_return_value = TET_PASS;
}

namespace
{

const char* TEST_VECTOR_IMAGE_FILE_NAME =  TEST_RESOURCE_DIR  "/insta_camera.json";

}

int UtcDaliVisualFactoryGetAnimatedVectorImageVisual01(void)
{
  ToolkitTestApplication application;
  tet_infoline( "UtcDaliVisualFactoryGetAnimatedVectorImageVisual01: Request animated vector image visual with a json url" );

  VisualFactory factory = VisualFactory::Get();
  Visual::Base visual = factory.CreateVisual( TEST_VECTOR_IMAGE_FILE_NAME, ImageDimensions() );
  DALI_TEST_CHECK( visual );

  DummyControl actor = DummyControl::New( true );
  DummyControlImpl& dummyImpl = static_cast< DummyControlImpl& >( actor.GetImplementation() );
  dummyImpl.RegisterVisual( DummyControl::Property::TEST_VISUAL, visual );
  actor.SetSize( 200.0f, 200.0f );
  Stage::GetCurrent().Add( actor );

  application.SendNotification();
  application.Render();

  // Wait for resource ready event callback
  DALI_TEST_EQUALS( Test::WaitForEventThreadTrigger( 1 ), true, TEST_LOCATION );

  // renderer is added to actor
  DALI_TEST_CHECK( actor.GetRendererCount() == 1u );
  Renderer renderer = actor.GetRendererAt( 0u );
  DALI_TEST_CHECK( renderer );

  // Test SetOffStage().
  actor.Unparent();
  DALI_TEST_CHECK( actor.GetRendererCount() == 0u );

  END_TEST;
}

int UtcDaliVisualFactoryGetAnimatedVectorImageVisual02(void)
{
  ToolkitTestApplication application;
  tet_infoline( "UtcDaliVisualFactoryGetAnimatedVectorImageVisual02: Request animated vector image visual with a Property::Map" );

  Property::Map propertyMap;
  propertyMap.Add( Toolkit::Visual::Property::TYPE, DevelVisual::ANIMATED_VECTOR_IMAGE )
             .Add( ImageVisual::Property::URL, TEST_VECTOR_IMAGE_FILE_NAME  );

  Visual::Base visual = VisualFactory::Get().CreateVisual( propertyMap );
  DALI_TEST_CHECK( visual );

  DummyControl actor = DummyControl::New( true );
  DummyControlImpl& dummyImpl = static_cast< DummyControlImpl& >( actor.GetImplementation() );
  dummyImpl.RegisterVisual( DummyControl::Property::TEST_VISUAL, visual );
  actor.SetSize( 200.0f, 200.0f );
  Stage::GetCurrent().Add( actor );

  application.SendNotification();
  application.Render();

  // Wait for resource ready event callback
  DALI_TEST_EQUALS( Test::WaitForEventThreadTrigger( 1 ), true, TEST_LOCATION );

  // renderer is added to actor
  DALI_TEST_CHECK( actor.GetRendererCount() == 1u );
  Renderer renderer = actor.GetRendererAt( 0u );
  DALI_TEST_CHECK( renderer );

  actor.Unparent( );
  DALI_TEST_CHECK( actor.GetRendererCount() == 0u );

  END_TEST;
}

int UtcDaliAnimatedVectorImageVisualGetPropertyMap01(void)
{
  ToolkitTestApplication application;
  tet_infoline( "UtcDaliAnimatedVectorImageVisualGetPropertyMap01" );

  Property::Map propertyMap;
  propertyMap.Add( Toolkit::Visual::Property::TYPE,  DevelVisual::ANIMATED_VECTOR_IMAGE )
             .Add( ImageVisual::Property::URL, TEST_VECTOR_IMAGE_FILE_NAME  );

  // request AnimatedVectorImageVisual with a property map
  VisualFactory factory = VisualFactory::Get();
  Visual::Base visual = factory.CreateVisual( propertyMap );

  Property::Map resultMap;
  visual.CreatePropertyMap( resultMap );

  // check the property values from the returned map from a visual
  Property::Value* value = resultMap.Find( Toolkit::Visual::Property::TYPE, Property::INTEGER );
  DALI_TEST_CHECK( value );
  DALI_TEST_CHECK( value->Get< int >() == DevelVisual::ANIMATED_VECTOR_IMAGE );

  value = resultMap.Find( ImageVisual::Property::URL, Property::STRING );
  DALI_TEST_CHECK( value );
  DALI_TEST_CHECK( value->Get< std::string >() == TEST_VECTOR_IMAGE_FILE_NAME );

  // request AnimatedVectorImageVisual with an URL
  Visual::Base visual2 = factory.CreateVisual( TEST_VECTOR_IMAGE_FILE_NAME, ImageDimensions() );

  resultMap.Clear();
  visual2.CreatePropertyMap( resultMap );

  // check the property values from the returned map from a visual
  value = resultMap.Find( Toolkit::Visual::Property::TYPE, Property::INTEGER );
  DALI_TEST_CHECK( value );
  DALI_TEST_CHECK( value->Get< int >() == DevelVisual::ANIMATED_VECTOR_IMAGE );

  value = resultMap.Find( ImageVisual::Property::URL, Property::STRING );
  DALI_TEST_CHECK( value );
  DALI_TEST_CHECK( value->Get< std::string >() == TEST_VECTOR_IMAGE_FILE_NAME );

  END_TEST;
}

int UtcDaliAnimatedVectorImageVisualPlayback(void)
{
  ToolkitTestApplication application;

  tet_infoline( "UtcDaliAnimatedVectorImageVisualPlayback" );

  {
    // request AnimatedVectorImageVisual with a property map
    VisualFactory factory = VisualFactory::Get();
    Visual::Base visual = factory.CreateVisual(
      Property::Map()
      .Add( Toolkit::Visual::Property::TYPE, DevelVisual::ANIMATED_VECTOR_IMAGE )
      .Add( ImageVisual::Property::URL, TEST_VECTOR_IMAGE_FILE_NAME ) );

    DummyControl dummyControl = DummyControl::New( true );
    Impl::DummyControl& dummyImpl = static_cast< Impl::DummyControl& >( dummyControl.GetImplementation() );
    dummyImpl.RegisterVisual( DummyControl::Property::TEST_VISUAL, visual );
    dummyControl.SetResizePolicy( ResizePolicy::FILL_TO_PARENT, Dimension::ALL_DIMENSIONS );

    Property::Map attributes;
    tet_infoline( "Test Play action" );
    DevelControl::DoAction( dummyControl, DummyControl::Property::TEST_VISUAL, Dali::Toolkit::DevelAnimatedVectorImageVisual::Action::PLAY, attributes );

    Stage::GetCurrent().Add( dummyControl );
    application.SendNotification();
    application.Render( 16 );

    DALI_TEST_EQUALS( Test::WaitForEventThreadTrigger( 1 ), true, TEST_LOCATION );

    // test

    tet_infoline( "Test Pause action" );
    DevelControl::DoAction( dummyControl, DummyControl::Property::TEST_VISUAL, Dali::Toolkit::DevelAnimatedVectorImageVisual::Action::PAUSE, attributes );

    application.SendNotification();
    application.Render(16);

    // test

    tet_infoline( "Test Resume action" );
    DevelControl::DoAction( dummyControl, DummyControl::Property::TEST_VISUAL, Dali::Toolkit::DevelAnimatedVectorImageVisual::Action::RESUME, attributes );

    application.SendNotification();
    application.Render(16);

    // test

    tet_infoline( "Test Stop action" );
    DevelControl::DoAction( dummyControl, DummyControl::Property::TEST_VISUAL, Dali::Toolkit::DevelAnimatedVectorImageVisual::Action::STOP, attributes );

    application.SendNotification();
    application.Render(16);

    // test

    tet_infoline( "Test Stop action again" );
    DevelControl::DoAction( dummyControl, DummyControl::Property::TEST_VISUAL, Dali::Toolkit::DevelAnimatedVectorImageVisual::Action::STOP, attributes );

    application.SendNotification();
    application.Render(16);

    // test

    tet_infoline( "Test Play action" );
    DevelControl::DoAction( dummyControl, DummyControl::Property::TEST_VISUAL, Dali::Toolkit::DevelAnimatedVectorImageVisual::Action::PLAY, attributes );

    application.SendNotification();
    application.Render(16);

    // test

    dummyControl.SetSize( 100.0f, 100.0f );

    application.SendNotification();
    application.Render(16);

    // test
    // Size should be changed

    dummyControl.Unparent();
  }

  END_TEST;
}

int UtcDaliAnimatedVectorImageVisualCustomShader(void)
{
  ToolkitTestApplication application;
  tet_infoline( "UtcDaliAnimatedVectorImageVisualCustomShader Test custom shader" );

  VisualFactory factory = VisualFactory::Get();
  Property::Map properties;
  Property::Map shader;
  const std::string vertexShader = "Foobar";
  const std::string fragmentShader = "Foobar sampler2D Foobar";
  shader[Visual::Shader::Property::FRAGMENT_SHADER] = fragmentShader;
  shader[Visual::Shader::Property::VERTEX_SHADER] = vertexShader;

  properties[Visual::Property::TYPE] = Visual::IMAGE;
  properties[Visual::Property::SHADER] = shader;
  properties[ImageVisual::Property::URL] = TEST_VECTOR_IMAGE_FILE_NAME;

  Visual::Base visual = factory.CreateVisual( properties );

  // trigger creation through setting on stage
  DummyControl dummy = DummyControl::New( true );
  Impl::DummyControl& dummyImpl = static_cast< Impl::DummyControl& >( dummy.GetImplementation() );
  dummyImpl.RegisterVisual( DummyControl::Property::TEST_VISUAL, visual );

  dummy.SetSize( 200.f, 200.f );
  dummy.SetParentOrigin( ParentOrigin::CENTER );
  Stage::GetCurrent().Add( dummy );

  application.SendNotification();
  application.Render();

  DALI_TEST_EQUALS( Test::WaitForEventThreadTrigger( 1 ), true, TEST_LOCATION );

  Renderer renderer = dummy.GetRendererAt( 0 );
  Shader shader2 = renderer.GetShader();
  Property::Value value = shader2.GetProperty( Shader::Property::PROGRAM );
  Property::Map* map = value.GetMap();
  DALI_TEST_CHECK( map );

  std::string resultFragmentShader, resultVertexShader;
  Property::Value* fragment = map->Find( "fragment" ); // fragment key name from shader-impl.cpp
  fragment->Get( resultFragmentShader );
  DALI_TEST_CHECK( resultFragmentShader.find( fragmentShader ) != std::string::npos );

  Property::Value* vertex = map->Find( "vertex" ); // vertex key name from shader-impl.cpp
  vertex->Get( resultVertexShader );
  DALI_TEST_CHECK( resultVertexShader.find( vertexShader ) != std::string::npos );

  END_TEST;
}

int UtcDaliAnimatedVectorImageVisualNaturalSize(void)
{
  ToolkitTestApplication application;
  tet_infoline( "UtcDaliAnimatedVectorImageVisualNaturalSize" );

  VisualFactory factory = VisualFactory::Get();
  Visual::Base visual = factory.CreateVisual( TEST_VECTOR_IMAGE_FILE_NAME, ImageDimensions() );
  DALI_TEST_CHECK( visual );

  DummyControl actor = DummyControl::New( true );
  DummyControlImpl& dummyImpl = static_cast< DummyControlImpl& >( actor.GetImplementation() );
  dummyImpl.RegisterVisual( DummyControl::Property::TEST_VISUAL, visual );

  Vector2 controlSize( 20.f, 30.f );
  Vector2 naturalSize;

  actor.SetSize( controlSize );
  Stage::GetCurrent().Add( actor );

  application.SendNotification();
  application.Render();

  DALI_TEST_EQUALS( Test::WaitForEventThreadTrigger( 1 ), true, TEST_LOCATION );

  visual.GetNaturalSize( naturalSize );

  DALI_TEST_EQUALS( naturalSize, controlSize, TEST_LOCATION );

  END_TEST;
}