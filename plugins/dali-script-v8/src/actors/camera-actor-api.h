#ifndef __DALI_V8PLUGIN_CAMERA_ACTOR_API_H__
#define __DALI_V8PLUGIN_CAMERA_ACTOR_API_H__

/*
 * Copyright (c) 2015 Samsung Electronics Co., Ltd.
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

// EXTERNAL INCLUDES
#include <v8.h>
#include <dali/public-api/actors/camera-actor.h>

namespace Dali
{

namespace V8Plugin
{

namespace CameraActorApi
{
  /**
   * constructor
   */
  Actor New( const v8::FunctionCallbackInfo< v8::Value >& args );


  /**
   * Camera API see DALI camera.h
   */
  void SetPerspectiveProjection( const v8::FunctionCallbackInfo< v8::Value >& args );
  void SetOrthographicProjection( const v8::FunctionCallbackInfo< v8::Value >& args );

}; // namespace CameraActorApi

} // namespace V8Plugin

} // namespace Dali

#endif // header __DALI_V8PLUGIN_CAMERA_ACTOR_API_H__
