#
# Copyright (c) 2019 Samsung Electronics Co., Ltd.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
#

# Build the Dali Toolkit library

toolkit_images_dir  = ../../../dali-toolkit/styles/images-common
toolkit_sounds_dir  = ../../../dali-toolkit/sounds
toolkit_src_dir     = ../../../dali-toolkit/internal
public_api_src_dir  = ../../../dali-toolkit/public-api
devel_api_src_dir   = ../../../dali-toolkit/devel-api
third_party_src_dir = ../../../dali-toolkit/third-party

toolkit_styles_base_dir = ${STYLE_BASE_DIR}
toolkit_styles_dir = $(STYLE_DIR)
toolkit_style_images_dir = $(STYLE_DIR)/images

include ../../../dali-toolkit/sounds/file.list
include ../../../dali-toolkit/styles/file.list
include ../../../dali-toolkit/styles/images-common/file.list
include ../../../dali-toolkit/internal/file.list
include ../../../dali-toolkit/public-api/file.list
include ../../../dali-toolkit/devel-api/file.list
include ../../../dali-toolkit/third-party/file.list

vector_based_text_src_dir = ../../../dali-toolkit/internal/text/rendering/vector-based
include ../../../dali-toolkit/internal/text/rendering/vector-based/file.list

if ENABLE_VECTOR_BASED_TEXT_RENDERING
toolkit_src_files += $(vector_based_text_src_files)
DALI_TOOLKIT_CFLAGS += -DENABLE_VECTOR_BASED_TEXT_RENDERING
endif

resources_dir = ../../../resources
daliimagedir = ${dataReadOnlyDir}/toolkit/images/
daliimage_DATA = ${dali_toolkit_image_files}

dalisounddir = ${dataReadOnlyDir}/toolkit/sounds/
dalisound_DATA = ${dali_toolkit_sound_files}

package_doxy_dir = ../../../doc
include ../../../doc/file.list

LIBDALI_TOOLKIT_LA_SOURCES = \
                     $(toolkit_src_files) \
                     $(public_api_src_files) \
                     $(devel_api_src_files) \
                     $(third_party_src_files)

dalistyledir = ${dataReadOnlyDir}/toolkit/styles/
dalistyle_DATA = ${dali_toolkit_style_files}

dalistyleimagesdir = ${dataReadOnlyDir}/toolkit/styles/images/
dalistyleimages_DATA = ${dali_toolkit_style_images}

libdali_toolkit_la_DEPENDENCIES =

LIBDALI_TOOLKIT_LA_CXXFLAGS = -DDALI_COMPILATION \
                      -DDALI_IMAGE_DIR="\"${daliimagedir}\"" \
                      -DDALI_SOUND_DIR="\"${dalisounddir}\"" \
                      -DDALI_STYLE_DIR="\"${dalistyledir}\"" \
                      -DDALI_STYLE_IMAGE_DIR="\"${dalistyleimagesdir}\"" \
                      -DDALI_DATA_READ_ONLY_DIR="\"${dataReadOnlyDir}\"" \
                      -Werror -Wall \
                      -I../../../ \
                      $(DALI_TOOLKIT_CFLAGS) \
                      $(DALICORE_CFLAGS) \
                      $(DALIADAPTOR_CFLAGS) \
                      $(DLOG_CFLAGS) \
                      $(FRIBIDI_CFLAGS) \
                      $(HTMLCXX_CFLAGS)

LIBDALI_TOOLKIT_LA_LIBADD = \
                      $(DALICORE_LIBS) \
                      $(DALIADAPTOR_LIBS) \
                      $(DLOG_LIBS) \
                      $(FRIBIDI_LIBS) \
                      $(HTMLCXX_LIBS)


# The library
lib_LTLIBRARIES = libdali-toolkit-cxx11.la
libdali_toolkit_cxx11_la_SOURCES = $(LIBDALI_TOOLKIT_LA_SOURCES)
libdali_toolkit_cxx11_la_LIBADD = $(LIBDALI_TOOLKIT_LA_LIBADD)
libdali_toolkit_cxx11_la_CXXFLAGS = $(LIBDALI_TOOLKIT_LA_CXXFLAGS)
libdali_toolkit_cxx11_la_CFLAGS = $(LIBDALI_TOOLKTI_LA_CFLAGS)

if ENABLE_RENAME_SO
#rename
install: install-am
	rm -rf $(libdir)/libdali-toolkit-cxx11.so
	rm -rf $(libdir)/libdali-toolkit.so
	ln -s $(libdir)/libdali-toolkit-cxx11.so.0.0.* $(libdir)/libdali-toolkit.so
endif

# Install headers
topleveldir = $(devincludepath)/dali-toolkit
toplevel_HEADERS = ../../../dali-toolkit/dali-toolkit.h

# devel api
develapidir =                   $(topleveldir)/devel-api
develapibuilderdir =            $(develapidir)/builder
develapicontrolsdir =           $(develapidir)/controls
develapibloomviewdir =          $(develapicontrolsdir)/bloom-view
develapibubbleemitterdir =      $(develapicontrolsdir)/bubble-effect
develapibuttonsdir =            $(develapicontrolsdir)/buttons
develapieffectsviewdir =        $(develapicontrolsdir)/effects-view
develapigaussianblurviewdir =   $(develapicontrolsdir)/gaussian-blur-view
develapimagnifierdir =          $(develapicontrolsdir)/magnifier
develapinavigationviewdir =     $(develapicontrolsdir)/navigation-view
develapipageturnviewdir =       $(develapicontrolsdir)/page-turn-view
develapipopupdir =              $(develapicontrolsdir)/popup
develapiscene3dviewdir =        $(develapicontrolsdir)/scene3d-view
develapishadowviewdir =         $(develapicontrolsdir)/shadow-view
develapisuperblurviewdir =      $(develapicontrolsdir)/super-blur-view
develapiwebviewdir =            $(develapicontrolsdir)/web-view
develapifocusmanagerdir =       $(develapidir)/focus-manager
develapiimageloaderdir =        $(develapidir)/image-loader
develapilayoutingdir =          $(develapidir)/layouting
develapilayoutingcontrolsdir =  $(develapidir)/controls/layouting
develapiscriptingdir =          $(develapidir)/scripting
develapishadereffectsdir =      $(develapidir)/shader-effects
develapistylingdir =            $(develapidir)/styling
develapitransitioneffectsdir =  $(develapidir)/transition-effects
develapitoolbardir =            $(develapicontrolsdir)/tool-bar
develapitooltipdir =            $(develapicontrolsdir)/tooltip
develapitextselectionpopupdir = $(develapicontrolsdir)/text-controls
develapitextdir =               $(develapidir)/text
develapivisualfactorydir =      $(develapidir)/visual-factory
develapivisualsdir =            $(develapidir)/visuals
develapidragdropdir =           $(develapidir)/drag-drop-detector

# devel headers
develapi_HEADERS =                  $(devel_api_header_files)
develapicontrols_HEADERS =          $(devel_api_controls_header_files)
develapibloomview_HEADERS =         $(devel_api_bloom_view_header_files)
develapibubbleemitter_HEADERS =     $(devel_api_bubble_emitter_header_files)
develapibuttons_HEADERS =           $(devel_api_buttons_header_files)
develapibuilder_HEADERS =           $(devel_api_builder_header_files)
develapieffectsview_HEADERS =       $(devel_api_effects_view_header_files)
develapifocusmanager_HEADERS =      $(devel_api_focus_manager_header_files)
develapigaussianblurview_HEADERS =  $(devel_api_gaussian_blur_view_header_files)
develapiimageloader_HEADERS =       $(devel_api_image_loader_header_files)
develapilayoutingcontrols_HEADERS = $(devel_api_layouting_controls_header_files)
develapilayouting_HEADERS =         $(devel_api_layouting_header_files)
develapimagnifier_HEADERS =         $(devel_api_magnifier_header_files)
develapinavigationview_HEADERS =    $(devel_api_navigation_view_header_files)
develapipageturnview_HEADERS =      $(devel_api_page_turn_view_header_files)
develapipopup_HEADERS =             $(devel_api_popup_header_files)
develapivisualfactory_HEADERS =     $(devel_api_visual_factory_header_files)
develapivisuals_HEADERS =           $(devel_api_visuals_header_files)
develapiscripting_HEADERS =         $(devel_api_scripting_header_files)
develapiscene3dview_HEADERS =       $(devel_api_scene3d_view_header_files)
develapishadowview_HEADERS =        $(devel_api_shadow_view_header_files)
develapishadereffects_HEADERS =     $(devel_api_shader_effects_header_files)
develapistyling_HEADERS =           $(devel_api_styling_header_files)
develapisuperblurview_HEADERS =     $(devel_api_super_blur_view_header_files)
develapiwebview_HEADERS =           $(devel_api_web_view_header_files)
develapitoolbar_HEADERS =           $(devel_api_tool_bar_header_files)
develapitooltip_HEADERS =           $(devel_api_tooltip_header_files)
develapitransitioneffects_HEADERS = $(devel_api_transition_effects_header_files)
develapitextselectionpopup_HEADERS = $(devel_api_text_controls_header_files)
develapitext_HEADERS =              $(devel_api_text_header_files)
develapidragdrop_HEADERS =          $(devel_api_drag_and_drop_detector_header_files)

# public api source
publicapidir =                     $(topleveldir)/public-api
publicapicontrolsdir =             $(publicapidir)/controls
publicapiimageloaderdir =          $(publicapidir)/image-loader
publicapiaccessibilitymanagerdir = $(publicapidir)/accessibility-manager
publicapialignmentdir =            $(publicapicontrolsdir)/alignment
publicapibuttonsdir =              $(publicapicontrolsdir)/buttons
publicapidefaultcontrolsdir =      $(publicapicontrolsdir)/default-controls
publicapiflexcontainerdir =        $(publicapicontrolsdir)/flex-container
publicapiimageviewdir =            $(publicapicontrolsdir)/image-view
publicapivideoviewdir =            $(publicapicontrolsdir)/video-view
publicapimodel3dviewdir =          $(publicapicontrolsdir)/model3d-view
publicapiprogressbardir =          $(publicapicontrolsdir)/progress-bar
publicapiscrollbardir =            $(publicapicontrolsdir)/scroll-bar
publicapiscrollabledir =           $(publicapicontrolsdir)/scrollable
publicapiscrollviewdir =           $(publicapicontrolsdir)/scrollable/scroll-view
publicapiitemviewdir =             $(publicapicontrolsdir)/scrollable/item-view
publicapistylingdir =              $(publicapidir)/styling
publicapitableviewdir =            $(publicapicontrolsdir)/table-view
publicapitextcontrolsdir =         $(publicapicontrolsdir)/text-controls
publicapifocusmanagerdir =         $(publicapidir)/focus-manager
publicapitextdir =                 $(publicapidir)/text
publicapisliderdir =               $(publicapicontrolsdir)/slider
publicapivisualsdir =              $(publicapidir)/visuals

# public api headers
publicapi_HEADERS =                     $(public_api_header_files)
publicapicontrols_HEADERS =             $(public_api_controls_header_files)
publicapiimageloader_HEADERS =          $(public_api_image_loader_header_files)
publicapiaccessibilitymanager_HEADERS = $(public_api_accessibility_manager_header_files)
publicapialignment_HEADERS =            $(public_api_alignment_header_files)
publicapibuttons_HEADERS =              $(public_api_buttons_header_files)
publicapidefaultcontrols_HEADERS =      $(public_api_default_controls_header_files)
publicapiflexcontainer_HEADERS =        $(public_api_flex_container_header_files)
publicapiimageview_HEADERS =            $(public_api_image_view_header_files)
publicapivideoview_HEADERS =            $(public_api_video_view_header_files)
publicapiitemview_HEADERS =             $(public_api_item_view_header_files)
publicapimodel3dview_HEADERS =          $(public_api_model3d_view_header_files)
publicapiprogressbar_HEADERS =          $(public_api_progress_bar_header_files)
publicapiscrollbar_HEADERS =            $(public_api_scroll_bar_header_files)
publicapiscrollable_HEADERS =           $(public_api_scrollable_header_files)
publicapiscrollview_HEADERS =           $(public_api_scroll_view_header_files)
publicapistyling_HEADERS =              $(public_api_styling_header_files)
publicapitableview_HEADERS =            $(public_api_table_view_header_files)
publicapitextcontrols_HEADERS =         $(public_api_text_controls_header_files)
publicapifocusmanager_HEADERS =         $(public_api_focus_manager_header_files)
publicapitext_HEADERS =                 $(public_api_text_header_files)
publicapislider_HEADERS =               $(public_api_slider_header_files)
publicapivisuals_HEADERS =              $(public_api_visuals_header_files)

# package doxygen file (contains doxygen grouping information)
packagedoxydir = $(topleveldir)/doc
packagedoxy_HEADERS = $(package_doxy_files)
