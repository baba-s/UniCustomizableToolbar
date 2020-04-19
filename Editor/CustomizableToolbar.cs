using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UniCustomizableToolbar
{
	internal sealed class CustomizableToolbar : EditorWindow
	{
		//==============================================================================
		// 定数(const)
		//==============================================================================
		private const string TITLE         = "Toolbar";
		private const float  WINDOW_HEIGHT = 24;
		private const float  BUTTON_HEIGHT = 20;

		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField] private CustomizableToolbarSettings m_settings = null;

		//==============================================================================
		// 関数
		//==============================================================================
		public static void Open( CustomizableToolbarSettings settings )
		{
			//var win = GetWindow<CustomizableToolbar>( TITLE );

			var win = CreateInstance<CustomizableToolbar>();
			win.titleContent = new GUIContent( TITLE );
			win.m_settings   = settings;
			win.Show();

			var pos = win.position;
			pos.height   = WINDOW_HEIGHT;
			win.position = pos;

			var minSize = win.minSize;
			minSize.y   = WINDOW_HEIGHT;
			win.minSize = minSize;

			var maxSize = win.maxSize;
			maxSize.y   = WINDOW_HEIGHT;
			win.maxSize = maxSize;
		}

		private void OnGUI()
		{
			EditorGUILayout.BeginHorizontal();

			if ( m_settings == null || m_settings.List == null ) return;

			var list = m_settings.List.Where( c => c.IsValid );

			foreach ( var n in list )
			{
				var commandName = n.CommandName;
				var buttonName  = n.ButtonName;
				var image       = n.Image;
				var width       = n.Width;
				var content     = image != null ? new GUIContent( image ) : new GUIContent( buttonName );
				var options = 0 < width
						? new[] { GUILayout.Width( width ), GUILayout.Height( BUTTON_HEIGHT ) }
						: new[]
						{
							GUILayout.Width( EditorStyles.label.CalcSize( new GUIContent( buttonName ) ).x + 14 ),
							GUILayout.Height( BUTTON_HEIGHT )
						}
					;
				if ( GUILayout.Button( content, options ) )
				{
					EditorApplication.ExecuteMenuItem( commandName );
				}
			}

			EditorGUILayout.EndHorizontal();
		}
	}
}