using UnityEditor;
using Utility.Custom.Inspector;
using Utility.System.Save_System;

namespace Editor.Utility_Editor.System_Editor.Save_System_Editor
{
    [CustomEditor(typeof(SaveSystem))]
    public class SaveSystemEditor : ExtendedInspector<SaveSystem>
    {
        protected override void OnEnableAction()
        {
            GenericObject = (SaveSystem) target;
            GenericObjectType = typeof(SaveSystem);
        }
    }
}