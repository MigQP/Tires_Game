// #define CP_ORION
using UnityEngine;
using System.Collections;
using UnityEditor;

namespace seawisphunter.custompointer {

  /*
    This editor shows which version of Leap Motion Support is enabled.  
  */
  [CustomEditor(typeof(LeapMotionPointerModule))]
  public class LeapMotionPointerEditor : Editor {
    
    public override void OnInspectorGUI() {
      #if CP_ORION
      GUILayout.Label("Custom Pointer Leap Motion Orion support enabled.");
      #else
      GUILayout.Label("Custom Pointer Leap Motion Core support enabled.");
      #endif
      DrawDefaultInspector();
    }
  }
}
