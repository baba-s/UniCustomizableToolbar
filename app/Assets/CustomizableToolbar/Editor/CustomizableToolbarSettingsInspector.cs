using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace KoganeEditorLib
{
	[CustomEditor( typeof( CustomizableToolbarSettings ) )]
	public sealed class CustomizableToolbarSettingsInspector : Editor
	{
		//==============================================================================
		// 変数
		//==============================================================================
		private SerializedProperty m_property;
		private ReorderableList    m_reorderableList;

		//==============================================================================
		// 関数
		//==============================================================================
		private void OnEnable()
		{
			m_property = serializedObject.FindProperty( "m_list" );
			m_reorderableList = new ReorderableList( serializedObject, m_property )
			{
				elementHeight       = 80,
				drawElementCallback = OnDrawElement
			};
		}

		private void OnDrawElement( Rect rect, int index, bool isActive, bool isFocused )
		{
			var element = m_property.GetArrayElementAtIndex( index );
			rect.height -= 4;
			rect.y      += 2;
			EditorGUI.PropertyField( rect, element );
		}

		public override void OnInspectorGUI()
		{
			if ( GUILayout.Button( "Open" ) )
			{
				CustomizableToolbar.Open( target as CustomizableToolbarSettings );
			}

			serializedObject.Update();
			m_reorderableList.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}
	}
}