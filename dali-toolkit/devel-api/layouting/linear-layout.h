#ifndef DALI_TOOLKIT_LAYOUTING_LINEAR_LAYOUT_H
#define DALI_TOOLKIT_LAYOUTING_LINEAR_LAYOUT_H

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

#include <dali/public-api/common/dali-common.h>
#include <dali/public-api/object/base-handle.h>
#include <dali-toolkit/devel-api/layouting/layout-group.h>
#include <dali-toolkit/devel-api/layouting/layout-size.h>
#include <dali-toolkit/public-api/toolkit-property-index-ranges.h>

namespace Dali
{
namespace Toolkit
{

namespace Internal DALI_INTERNAL
{
class LinearLayout;
}

/**
 * This class implements a linear box layout, automatically handling
 * right to left or left to right direction change.
 */
class DALI_TOOLKIT_API LinearLayout : public LayoutGroup
{
public:

  enum PropertyRange
  {
    CHILD_PROPERTY_START_INDEX = LINEAR_LAYOUT_CHILD_PROPERTY_START_INDEX,
    CHILD_PROPERTY_END_INDEX   = LINEAR_LAYOUT_CHILD_PROPERTY_END_INDEX
  };

  /**
   * @brief Enumeration for the direction in which the content is laid out
   */
  enum class Orientation
  {
    HORIZONTAL,                 ///< Horizontal (row)
    VERTICAL                    ///< Vertical (column)
  };

  /**
   * @brief Creates an uninitialized LinearLayout handle.
   *
   * Initialize it using LinearLayout::New().
   * Calling member functions with an uninitialized handle is not allowed.
   */
  LinearLayout();

  /**
   * @brief Creates a LinearLayout object.
   */
  static LinearLayout New();

  /**
   * @brief Downcasts a handle to a LinearLayout handle.
   *
   * If handle points to a LinearLayout, the downcast produces a valid handle.
   * If not, the returned handle is left uninitialized.

   * @param[in] handle to an object
   * @return Handle to a LinearLayout or an uninitialized handle
   */
  static LinearLayout DownCast( BaseHandle handle );

  /**
   * @brief Copy constructor
   */
  LinearLayout( const LinearLayout& other );

  /**
   * @brief Assigment operator
   */
  LinearLayout& operator=( const LinearLayout& other );

  /**
   * @brief Default destructor.
   *
   * This is non-virtual, since derived Handle types must not contain data or virtual methods
   */
  ~LinearLayout()=default;

  /**
   * @brief Set the padding between cells in the layout
   *
   * @param[in] size The padding between cells.
   */
  void SetCellPadding( LayoutSize size );

  /**
   * @brief Get the padding between cells in the layout
   *
   * @return The padding between cells.
   */
  LayoutSize GetCellPadding();

  /**
   * @brief Set the orientation in the layout
   *
   * @param[in] orientation The orientation.
   */
  void SetOrientation( Orientation orientation );

  /**
   * @brief Get the orientation in the layout
   *
   * @return The orientation.
   */
  Orientation GetOrientation();

public: // Not intended for application developers

  /// @cond internal
  /**
   * @brief This constructor is used by LinearLayout::New() methods.
   *
   * @param[in] actor A pointer to a newly allocated Dali resource
   */
  explicit DALI_INTERNAL LinearLayout( Internal::LinearLayout* body );
  /// @endcond
};

} // namespace Toolkit
} // namespace Dali

#endif // DALI_TOOLKIT_LAYOUTING_LINEAR_LAYOUT_H