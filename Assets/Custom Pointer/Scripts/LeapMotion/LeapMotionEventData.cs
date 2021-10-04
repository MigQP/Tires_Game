#define CP_ORION
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;
using Leap;

#if CP_ORION
using Leap.Unity;
#endif

namespace seawisphunter.custompointer {
  /**
     Contains extra information about the event necessary for the Leap
     Motion, in this case the Hand Model.  Used within event system
     not necessary to instantiate or use yourself.
   */
  public class LeapMotionEventData : TransformEventData {
    #if CP_ORION
    // public IHandModel hand;
    // public Hand hand;
    public HandModelBase hand;
    #else
    public HandModel hand;
    #endif
    public bool hadFist = false;
    public LeapMotionEventData(EventSystem eventSystem) : base(eventSystem) {
    }
  }
}

