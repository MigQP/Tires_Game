#define CP_ORION
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Leap;
#if CP_ORION
using Leap.Unity;
#endif

namespace seawisphunter.custompointer {
  /*
    Register a pointer.  

    This is most useful when a pointer object may enter into a scene
    during runtime as happens with the Leap Motion hands.  Otherwise,
    it's probably best just to set the pointer and progress bar
    directly in the TransformPointerModule's editor window.
  */
  public class RegisterHandPointer : RegisterTransformPointer {

    #if CP_ORION
    // public IHandModel hand;
    // public Hand hand;
    public HandModelBase hand;
    #else
    public HandModel hand;
    #endif

    protected override void Register() {
      if (hand != null && module != null)
        ((LeapMotionPointerModule) module).RegisterHandPointer(pointerId,
                                                               this.transform,
                                                               progressBar,
                                                               hand);
    }

    public override void OnDestroy() {
      base.OnDestroy();
      if (module != null)
        ((LeapMotionPointerModule) module).UnregisterHandPointer(pointerId,
                                                                 hand);
    }
  }

}

