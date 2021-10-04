#define CP_ORION
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;
using Leap;
#if CP_ORION
using Leap.Unity;
#endif

namespace seawisphunter.custompointer {

  public class RegisterHandTransition
  #if ! CP_ORION
    : MonoBehaviour { 
  #else
    : HandTransitionBehavior {
      public RegisterHandPointer handPointer;
      // private IHandModel handModel = null;
      // private Hand handModel = null;
      private HandModelBase handModel = null;

      void OnEnable() {
        // handModel = GetComponent<IHandModel>();
        handModel = GetComponent<HandModelBase>();
        Assert.IsNotNull(handModel);
        Assert.IsNotNull(handPointer);
      }

      void Update() {
        if (handPointer == null
            || handModel == null
           // || handModel.GetLeapHand() == null
            )
          return;
        List<Finger> fingers = handModel.GetLeapHand().Fingers;
        for (int i = 0; i < fingers.Count; i++) {
          if (fingers[i] != null && fingers[i].Type == Finger.FingerType.TYPE_INDEX) {
            handPointer.transform.position = fingers[i].TipPosition.ToVector3();
            break;
          }
        }
      }
      
      protected override void HandReset() {
        print("hand reset");
        handPointer.hand = handModel;
        Assert.IsNotNull(handModel);
        Assert.IsNotNull(handPointer.hand);
        handPointer.gameObject.SetActive(true);
        print("hand reset end");
      }

      // Use this for initialization
      protected override void HandFinish () {
        print("hand finish");
        handPointer.gameObject.SetActive(false);
        handPointer.hand = null;
      }
   #endif
    }
  }

