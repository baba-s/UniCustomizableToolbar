﻿using System.IO;
using UnityEditor;
using UnityEngine;

namespace UniCustomizableToolbar
{
	[CustomPropertyDrawer( typeof( CustomizableToolbarSettingsData ) )]
	internal sealed class CustomizableToolbarSettingsDataDrawer : PropertyDrawer
	{
		//==============================================================================
		// 関数
		//==============================================================================
		public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
		{
			using ( new EditorGUI.PropertyScope( position, label, property ) )
			{
				position.height = EditorGUIUtility.singleLineHeight;

				var commandRect = new Rect( position )
				{
					width = position.width - 18,
				};
				var presetRect = new Rect( position )
				{
					x     = commandRect.xMax + 2,
					width = 16,
				};
				var buttonRect = new Rect( position )
				{
					y = commandRect.yMax + 2,
				};
				var imageRect = new Rect( position )
				{
					y = buttonRect.yMax + 2,
				};
				var widthRect = new Rect( position )
				{
					y = imageRect.yMax + 2,
				};

				var commandProperty = property.FindPropertyRelative( "m_commandName" );
				var buttonProperty  = property.FindPropertyRelative( "m_buttonName" );
				var imageProperty   = property.FindPropertyRelative( "m_image" );
				var widthProperty   = property.FindPropertyRelative( "m_width" );

				commandProperty.stringValue = EditorGUI.TextField
				(
					commandRect, commandProperty.displayName, commandProperty.stringValue
				);
				buttonProperty.stringValue = EditorGUI.TextField
				(
					buttonRect, buttonProperty.displayName, buttonProperty.stringValue
				);
				EditorGUI.ObjectField( imageRect, imageProperty );
				widthProperty.intValue = EditorGUI.IntField
				(
					widthRect, widthProperty.displayName, widthProperty.intValue
				);

				if ( GUI.Button( presetRect, GUIContent.none, "ShurikenDropdown" ) )
				{
					var menu = new GenericMenu();
					foreach ( var n in GetPresets() )
					{
						menu.AddItem
						(
							new GUIContent( n ), false, () =>
							{
								property.serializedObject.Update();
								commandProperty.stringValue = n;
								buttonProperty.stringValue  = Path.GetFileNameWithoutExtension( n );
								property.serializedObject.ApplyModifiedProperties();
							}
						);
					}

					menu.ShowAsContext();
				}
			}
		}

		private static string[] GetPresets() =>
			new[]
			{
				"File/New Scene",
				"File/Open Scene",
				"File/Save",
				"File/Save As...",
				"File/New Project...",
				"File/Open Project...",
				"File/Save Project",
				"File/Build Settings...",
				"File/Build And Run",
				"File/Exit",

				"Edit/Undo",
				"Edit/Redo",
				"Edit/Cut",
				"Edit/Copy",
				"Edit/Paste",
				"Edit/Duplicate",
				"Edit/Delete",
				"Edit/Frame Selected",
				"Edit/Lock View to Selected",
				"Edit/Find",
				"Edit/Select All",
				"Edit/Play",
				"Edit/Pause",
				"Edit/Step",
				"Edit/Sign in...",
				"Edit/Sign out",

				"Edit/Selection/Load Selection 1",
				"Edit/Selection/Load Selection 2",
				"Edit/Selection/Load Selection 3",
				"Edit/Selection/Load Selection 4",
				"Edit/Selection/Load Selection 5",
				"Edit/Selection/Load Selection 6",
				"Edit/Selection/Load Selection 7",
				"Edit/Selection/Load Selection 8",
				"Edit/Selection/Load Selection 9",
				"Edit/Selection/Load Selection 0",
				"Edit/Selection/Save Selection 1",
				"Edit/Selection/Save Selection 2",
				"Edit/Selection/Save Selection 3",
				"Edit/Selection/Save Selection 4",
				"Edit/Selection/Save Selection 5",
				"Edit/Selection/Save Selection 6",
				"Edit/Selection/Save Selection 7",
				"Edit/Selection/Save Selection 8",
				"Edit/Selection/Save Selection 9",
				"Edit/Selection/Save Selection 0",

				"Edit/Project Settings...",
				"Edit/Preferences...",
				"Edit/Modules...",
				"Edit/Clear All PlayerPrefs",

				"Edit/Graphics Emulation/No Emulation",
				"Edit/Graphics Emulation/Saher Mode 4",
				"Edit/Graphics Emulation/Saher Mode 3",
				"Edit/Graphics Emulation/Saher Hardware Tier 1",
				"Edit/Graphics Emulation/Saher Hardware Tier 2",
				"Edit/Graphics Emulation/Saher Hardware Tier 3",

				"Edit/Snap Settings...",

				"Assets/Create/Folder",
				"Assets/Create/C# Script",

				"Assets/Create/Shader/Standard Surface Shader",
				"Assets/Create/Shader/Unlit Shader",
				"Assets/Create/Shader/Image Effect Shader",
				"Assets/Create/Shader/Compute Shader",
				"Assets/Create/Shader/Shader Variant Collection",

				"Assets/Create/Testing/Test Assembly Folder",
				"Assets/Create/Testing/C# Test Script",

				"Assets/Create/Playables/Playable Behaviour C# Script",
				"Assets/Create/Playables/Playable Asset C# Script",

				"Assets/Create/Assembly Definition",

				"Assets/Create/TextMeshPro/Sprite Asset",
				"Assets/Create/TextMeshPro/Color Gradient",
				"Assets/Create/TextMeshPro/Style Sheet",

				"Assets/Create/Scene",
				"Assets/Create/Prefab Variant",
				"Assets/Create/Audio Mixer",
				"Assets/Create/Material",
				"Assets/Create/Lens Flare",
				"Assets/Create/Render Texture",
				"Assets/Create/Lightmap Parameters",
				"Assets/Create/Custom Render Texture",

				"Assets/Create/Sprite Atlas",

				"Assets/Create/Sprites/Square",
				"Assets/Create/Sprites/Triangle",
				"Assets/Create/Sprites/Diamond",
				"Assets/Create/Sprites/Hexagon",
				"Assets/Create/Sprites/Circle",
				"Assets/Create/Sprites/Polygon",

				"Assets/Create/Tile",

				"Assets/Create/Animator Controller",
				"Assets/Create/Animation",
				"Assets/Create/Animator Override Controller",
				"Assets/Create/Avatar Mask",
				"Assets/Create/Timeline",
				"Assets/Create/Physic Material",
				"Assets/Create/Physics Material 2D",
				"Assets/Create/GUI Skin",
				"Assets/Create/Custom Font",

				"Assets/Create/Legacy/Cubemap",
				"Assets/Create/Brush",

				"Assets/Show in Explorer",
				"Assets/Open",
				"Assets/Delete",
				"Assets/Rename",
				"Assets/Copy Path",

				"Assets/Open Scene Additive",

				"Assets/Import New Asset...",
				"Assets/Import Package/Custom Package...",
				"Assets/Export Package...",
				"Assets/Find References In Scene",
				"Assets/Select Dependencies",
				"Assets/Refresh",
				"Assets/Reimport",
				"Assets/Reimport All",
				"Assets/Extract From Prefab",
				"Assets/Run API Updater...",
				"Assets/Update UIElements Schema",
				"Assets/Open C# Project",

				"GameObject/Create Empty",
				"GameObject/Create Empty Child",

				"GameObject/3D Object/Cube",
				"GameObject/3D Object/Sphere",
				"GameObject/3D Object/Capsule",
				"GameObject/3D Object/Cylinder",
				"GameObject/3D Object/Plane",
				"GameObject/3D Object/Quad",
				"GameObject/3D Object/TextMeshPro - Text",
				"GameObject/3D Object/Ragdoll...",
				"GameObject/3D Object/Terrain",
				"GameObject/3D Object/Tree",
				"GameObject/3D Object/Wind Zone",
				"GameObject/3D Object/3D Text",

				"GameObject/2D Object/Sprite",
				"GameObject/2D Object/Sprite Mask",
				"GameObject/2D Object/Hexagonal Point Top Tilemap",
				"GameObject/2D Object/Hexagonal Flat Top Tilemap",
				"GameObject/2D Object/Isometric Tilemap",
				"GameObject/2D Object/Isometric Z As Y Tilemap",

				"GameObject/Effects/Particle System",
				"GameObject/Effects/Particle System Force Field",
				"GameObject/Effects/Trail",
				"GameObject/Effects/Line",

				"GameObject/Light/Directional Light",
				"GameObject/Light/Point Light",
				"GameObject/Light/Spotlight",
				"GameObject/Light/Area Light",
				"GameObject/Light/Reflection Probe",
				"GameObject/Light/Light Probe Group",

				"GameObject/Audio/Audio Source",
				"GameObject/Audio/Audio Reverb Zone",

				"GameObject/Video/Video Player",

				"GameObject/UI/Text",
				"GameObject/UI/TextMeshPro - Text",
				"GameObject/UI/Image",
				"GameObject/UI/Raw Image",
				"GameObject/UI/Button",
				"GameObject/UI/Toggle",
				"GameObject/UI/Slider",
				"GameObject/UI/Scrollbar",
				"GameObject/UI/Dropdown",
				"GameObject/UI/TextMeshPro - Dropdown",
				"GameObject/UI/Input Field",
				"GameObject/UI/TextMeshPro - Input Field",
				"GameObject/UI/Canvas",
				"GameObject/UI/Panel",
				"GameObject/UI/Scroll View",
				"GameObject/UI/Event System",

				"GameObject/Camera",
				"GameObject/Center On Children",
				"GameObject/Make Parent",
				"GameObject/Clear Parent",

				"GameObject/Set as first sibling",
				"GameObject/Set as last sibling",
				"GameObject/Move To View",
				"GameObject/Align With View",
				"GameObject/Align View to Selected",
				"GameObject/Toggle Active State",

				"Component/Mesh/TextMeshPro - Text",
				"Component/Mesh/Mesh Filter",
				"Component/Mesh/Text Mesh",
				"Component/Mesh/Mesh Renderer",
				"Component/Mesh/Skinned Mesh Renderer",

				"Component/Effects/Particle System",
				"Component/Effects/Trail Renderer",
				"Component/Effects/Line Renderer",
				"Component/Effects/Lens Flare",
				"Component/Effects/Halo",
				"Component/Effects/Projector",
				"Component/Effects/Visual Effect",

				"Component/Physics/Rigidbody",
				"Component/Physics/Character Controller",
				"Component/Physics/Box Collider",
				"Component/Physics/Sphere Collider",
				"Component/Physics/Capsule Collider",
				"Component/Physics/Mesh Collider",
				"Component/Physics/Wheel Collider",
				"Component/Physics/Terrain Collider",
				"Component/Physics/Cloth",
				"Component/Physics/Hinge Joint",
				"Component/Physics/Fixed Joint",
				"Component/Physics/Spring Joint",
				"Component/Physics/Character Joint",
				"Component/Physics/Configurable Joint",
				"Component/Physics/Constant Force",

				"Component/Physics 2D/Rigidbody 2D",
				"Component/Physics 2D/Box Collider 2D",
				"Component/Physics 2D/Circle Collider 2D",
				"Component/Physics 2D/Edge Collider 2D",
				"Component/Physics 2D/Polygon Collider 2D",
				"Component/Physics 2D/Capsule Collider 2D",
				"Component/Physics 2D/Composite Collider 2D",
				"Component/Physics 2D/Distance Joint 2D",
				"Component/Physics 2D/Fixed Joint 2D",
				"Component/Physics 2D/Friction Joint 2D",
				"Component/Physics 2D/Hinge Joint 2D",
				"Component/Physics 2D/Relative Joint 2D",
				"Component/Physics 2D/Slider Joint 2D",
				"Component/Physics 2D/Spring Joint 2D",
				"Component/Physics 2D/Target Joint 2D",
				"Component/Physics 2D/Wheel Joint 2D",
				"Component/Physics 2D/Area Effector 2D",
				"Component/Physics 2D/Buoyancy Effector 2D",
				"Component/Physics 2D/Point Effector 2D",
				"Component/Physics 2D/Platform Effector 2D",
				"Component/Physics 2D/Surface Effector 2D",
				"Component/Physics 2D/Constant Force 2D",

				"Component/Navigation/Nav Mesh Agent",
				"Component/Navigation/Off Mesh Link",
				"Component/Navigation/Nav Mesh Obstacle",

				"Component/Audio/Audio Listener",
				"Component/Audio/Audio Source",
				"Component/Audio/Audio Reverb Zone",
				"Component/Audio/Audio Low Pass Filter",
				"Component/Audio/Audio High Pass Filter",
				"Component/Audio/Audio Echo Filter",
				"Component/Audio/Audio Distorition Filter",
				"Component/Audio/Audio Reverb Filter",
				"Component/Audio/Audio Chorus Filter",

				"Component/Video/Video Player",

				"Component/Rendering/Camera",
				"Component/Rendering/Streaming Controller",
				"Component/Rendering/Skybox",
				"Component/Rendering/Flare Layer",
				"Component/Rendering/GUI Layer",
				"Component/Rendering/Light",
				"Component/Rendering/Light Probe Group",
				"Component/Rendering/Light Probe Proxy Volume",
				"Component/Rendering/Reflection Probe",
				"Component/Rendering/Occlusion Area",
				"Component/Rendering/Occlusion Portal",
				"Component/Rendering/LOD Group",
				"Component/Rendering/Sprite Renderer",
				"Component/Rendering/Sorting Group",
				"Component/Rendering/Canvas Renderer",
				"Component/Rendering/GUI Texture",
				"Component/Rendering/GUI Text",

				"Component/Tilemap/Tilemap",
				"Component/Tilemap/Tilemap Renderer",
				"Component/Tilemap/Tilemap Collider 2D",

				"Component/Layout/Text Container",
				"Component/Layout/Rect Transform",
				"Component/Layout/Canvas",
				"Component/Layout/Canvas Group",
				"Component/Layout/Canvas Scaler",
				"Component/Layout/Layout Element",
				"Component/Layout/Content Size Fitter",
				"Component/Layout/Aspect Ratio Fitter",
				"Component/Layout/Horizontal Layout Group",
				"Component/Layout/Vertical Layout Group",
				"Component/Layout/Grid Layout Group",

				"Component/Playables/Playable Director",

				"Component/AR/World Anchor",

				"Component/Miscellaneous/Animator",
				"Component/Miscellaneous/Position Constraint",
				"Component/Miscellaneous/Rotation Constraint",
				"Component/Miscellaneous/Scale Constraint",
				"Component/Miscellaneous/Parent Constraint",
				"Component/Miscellaneous/Aim Constraint",
				"Component/Miscellaneous/Look At Constraint",
				"Component/Miscellaneous/Terrain",
				"Component/Miscellaneous/Billboard Renderer",
				"Component/Miscellaneous/Grid",
				"Component/Miscellaneous/Animation",
				"Component/Miscellaneous/Wind Zone",
				"Component/Miscellaneous/Particle System Force Field",
				"Component/Miscellaneous/Sprite Mask",
				"Component/Miscellaneous/Sprite Shape Renderer",

				"Component/UI/Effects/Shadow",
				"Component/UI/Effects/Outline",
				"Component/UI/Effects/Position As UV1",

				"Component/UI/Text",
				"Component/UI/TextMeshPro - Text (UI)",
				"Component/UI/TextMeshPro - Input Field",
				"Component/UI/Image",
				"Component/UI/Raw Image",
				"Component/UI/Mask",
				"Component/UI/Rect Mask 2D",
				"Component/UI/Button",
				"Component/UI/Input Field",
				"Component/UI/Toggle",
				"Component/UI/Toggle Group",
				"Component/UI/Slider",
				"Component/UI/Scrollbar",
				"Component/UI/TMP Dropdown",
				"Component/UI/Dropdown",
				"Component/UI/Scroll Rect",
				"Component/UI/Selectable",

				"Component/Scripts/TMPro/TMP_Scrollbar Event Handler",
				"Component/Scripts/TMPro/TMP_Selection Caret",
				"Component/Scripts/TMPro/TMP_Sprite Animator",
				"Component/Scripts/TMPro/TMP_Sub Mesh",
				"Component/Scripts/TMPro/TMP_Sub Mesh UI",

				"Component/Scripts/UnityEngine.Analytics/Data Privacy Button",

				"Component/Scripts/UnityEngine.EventSystems/Base Input",

				"Component/Scripts/TestTools.TestRunner.Callbacks/Test Result Renderer Callback",

				"Component/Analytics/Analytics Event Tracker",

				"Component/Event/Event System",
				"Component/Event/Event Trigger",
				"Component/Event/Physics 2D Raycaster",
				"Component/Event/Physics Raycaster",
				"Component/Event/Standalone Input Module",
				"Component/Event/Touch Input Module",
				"Component/Event/Graphic Raycaster",

				"Component/Network/NetworkAnimator",
				"Component/Network/NetworkDiscovery",
				"Component/Network/NetworkIdentity",
				"Component/Network/NetworkLobbyManager",
				"Component/Network/NetworkLobbyPlayer",
				"Component/Network/NetworkManager",
				"Component/Network/NetworkManagerHUD",
				"Component/Network/NetworkMigrationManager",
				"Component/Network/NetworkProximityChecker",
				"Component/Network/NetworkStartPosition",
				"Component/Network/NetworkTransform",
				"Component/Network/NetworkTransformChild",
				"Component/Network/NetworkTransformVisualizer",

				"Component/XR/Tracked Pose Driver",

				"Window/Next Window",
				"Window/Previous Window",

				"Window/Layouts/2 by 3",
				"Window/Layouts/4 Split",
				"Window/Layouts/Default",
				"Window/Layouts/Tall",
				"Window/Layouts/Wide",
				"Window/Layouts/Save Layout...",
				"Window/Layouts/Delete Layout...",
				"Window/Layouts/Revert Factory Settings...",

				"Window/Asset Store",
				"Window/Package Manager",

				"Window/TextMeshPro/Font Asset Creator",
				"Window/TextMeshPro/Sprite Importer",
				"Window/TextMeshPro/Import TMP Essential Resources",
				"Window/TextMeshPro/Import TMP Examples and Extras",
				"Window/TextMeshPro/Project Files GUID Remapping Tool",

				"Window/General/Scene",
				"Window/General/Game",
				"Window/General/Inspector",
				"Window/General/Hierarchy",
				"Window/General/Project",
				"Window/General/Console",
				"Window/General/Test Runner",
				"Window/General/Services",

				"Window/Rendering/Lighting Settings",
				"Window/Rendering/Lighting Explorer",
				"Window/Rendering/Occlusion Culling",

				"Window/Animation/Animation",
				"Window/Animation/Animator",
				"Window/Animation/Animator Parameter",

				"Window/Audio/Audio Mixer",

				"Window/Sequencing/Timeline",

				"Window/Analysis/Profiler",
				"Window/Analysis/Frame Debugger",
				"Window/Analysis/Physics Debugger",
				"Window/Analysis/UIElements Debugger",

				"Window/Asset Management/Collab History",
				"Window/Asset Management/Version Control",

				"Window/2D/Sprite Editor",
				"Window/2D/Sprite Packer",
				"Window/2D/Tile Pallet",

				"Window/AI/Navigation",

				"Window/XR/Holographic Emulation",

				"Window/Experimental/Look Dev",

				"Help/About Unity",

				"Help/Unity Manual",
				"Help/Scripting Reference",

				"Help/Unity Services",
				"Help/Unity Forum",
				"Help/Unity Answers",
				"Help/Unity Feedback",

				"Help/Check for Updates",
				"Help/Download Beta...",

				"Help/Manage License",

				"Help/Release Notes",
				"Help/Software Licenses",
				"Help/Report a Bug...",

				"Help/Reset Packages to defaults",

				"Help/Troubleshoot Issue...",
			};
	}
}