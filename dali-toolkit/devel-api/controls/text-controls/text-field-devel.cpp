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
 *
 */

// INTERNAL INCLUDES
#include <dali-toolkit/devel-api/controls/text-controls/text-field-devel.h>
#include <dali-toolkit/internal/controls/text-controls/text-field-impl.h>

namespace Dali
{

namespace Toolkit
{

namespace DevelTextField
{

InputMethodContext GetInputMethodContext( TextField textField )
{
  return GetImpl( textField ).GetInputMethodContext();
}

void SelectWholeText( TextField textField )
{
  GetImpl( textField ).SelectWholeText();
}

} // namespace DevelText

} // namespace Toolkit

} // namespace Dali
