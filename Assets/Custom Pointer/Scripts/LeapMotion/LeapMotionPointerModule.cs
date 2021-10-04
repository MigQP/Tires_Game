#define CP_ORION
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Text;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Leap;
#if CP_ORION
using Leap.Unity;
#endif

/**
   The LeapMotionPointerModule is added to the EventSystem.  It's
   handController must be set to the Hand Controller in the scene.
   Its two options allow for a screen tap or a key tap to effect UI
   clicks.
 */
namespace seawisphunter.custompointer {

  [System.Serializable]
  public class TapParams {
    public float minVelocity; // mm/s
    public float historySeconds; // s
    public float minDistance; // mm
  }

  [AddComponentMenu("Event/Leap Motion Pointer Module")]
  public class LeapMotionPointerModule : TransformPointerModule {

    public const int kIndexFingerId = 10;
    #if CP_ORION
    // public LeapHandController handController;
    public Controller handController;
    #else
    public HandController handController;
    #endif

    public bool enableScreenTap = false;
    public bool enableFistHover = false;
    #if !CP_ORION
    public TapParams screenTapParams
      = new TapParams() { minVelocity = 50f, // 50 mm/s
                          historySeconds = 0.1f, // 0.1 second
                          minDistance = 5f // 5 mm;
    };
    public bool enableKeyTap = false;
    public TapParams keyTapParams
      = new TapParams() { minVelocity = 50f, // 50 mm/s
                          historySeconds = 0.1f, // 0.1 second
                          minDistance = 3f // 3 mm;
    };
    private Dictionary<string, float> originalConfigFloats = new Dictionary<string,float>();
    #endif
    // Map of hand Ids to pointer Ids.
    private Dictionary<int, int> handIds = new Dictionary<int, int>();
     
    private Frame lastProcessedFrame;
    #if CP_ORION
    public LeapProvider leapProvider;
    #endif

    protected LeapMotionPointerModule() {}
  
    protected override void Start () {
      if (handController == null) {
        #if CP_ORION
        // handController = CPUtil.FindComponent<LeapHandController>("LeapHandController");
        // leapProvider = CPUtil.FindComponent<LeapProvider>("LeapHandController");
        var leapServiceProvider = CPUtil.FindComponent<LeapServiceProvider>("LeapHandController");
        leapProvider = (LeapProvider) leapServiceProvider;
        handController = leapServiceProvider.GetLeapController();
        #else
        handController = CPUtil.FindComponent<HandController>("HandController");
        #endif
      }
      #if CP_ORION
      if (leapProvider == null) {
        leapProvider = CPUtil.FindComponent<LeapProvider>("LeapHandController");
      }
      #endif
      if (handController == null
         // || !handController.enabled
          ) {
        Debug.Log("Disabling.");
        enabled = false; 
        return;
      }
      #if CP_ORION
      lastProcessedFrame = leapProvider.CurrentFrame;
      #else
      lastProcessedFrame = handController.GetFrame();
      #endif
      base.Start();
      
#if !CP_ORION
      /* Orion doesn't have gestures yet. */
      if (enableScreenTap) {
        handController.GetLeapController().EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
                
        SetFloat("Gesture.ScreenTap.MinForwardVelocity", screenTapParams.minVelocity);
        SetFloat("Gesture.ScreenTap.HistorySeconds", screenTapParams.historySeconds);
        SetFloat("Gesture.ScreenTap.MinDistance", screenTapParams.minDistance);
      }
      if (enableKeyTap) {
        handController.GetLeapController().EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
        SetFloat("Gesture.KeyTap.MinForwardVelocity", keyTapParams.minVelocity);
        SetFloat("Gesture.KeyTap.HistorySeconds", keyTapParams.historySeconds);
        SetFloat("Gesture.KeyTap.MinDistance", keyTapParams.minDistance);
      }
      if (! handController.GetLeapController().Config.Save()) {
        Debug.Log("Not able to save Leap Motion Controller config settings to service.");
      }
#endif // !CP_ORION
    }

    #if !CP_ORION
    private void SetFloat(string key, float value, bool resetOnUnload = true) {
      if (resetOnUnload) {
        if (! originalConfigFloats.ContainsKey(key)) {
          originalConfigFloats.Add(key, handController.GetLeapController().Config.GetFloat(key));
        }
      }
      handController.GetLeapController().Config.SetFloat(key, value);
     // leapProvider.GetLeapController().Config.SetFloat(key, value);
    }
    #endif

    public override void Process() {
      base.Process();
      PointerEventData eventData;
      GetPointerData(kIndexFingerId, out eventData, true);
#if !CP_ORION
      HandleGestures(eventData);
#endif
    }

    protected override bool DisableHoverClick(TransformEventData data) {
      if (! enableFistHover)
        return false;

      #if !CP_ORION
      LeapMotionEventData ldata = data as LeapMotionEventData;
      if (ldata == null)
        return false;
      float radius = ldata.hand.GetLeapHand().SphereRadius;
      //Debug.Log("fist radius " + radius);
      bool hasFist = radius < 40f;
      if (hasFist && !ldata.hadFist) {
        print("reseting time for fist");
        // Reset the time since entered.
        ldata.timeSinceEntered = Time.unscaledTime;
      }
      if (! hasFist && ldata.hadFist) {
        ldata.SetProgress(0f);
        ldata.timeSinceEntered = Time.unscaledTime;
      }
      ldata.hadFist = hasFist;
      return ! hasFist;
      #else
      return false;
      #endif
    }

    /* The open source code says this is protected but with Unity 4.6.1,
       it's not callable from an inherited. Returns true if created,
       false otherwise.*/
    protected new bool GetPointerData(int id, out PointerEventData data, bool create)
    {
      if (!m_PointerData.TryGetValue(id, out data) && create) {
        data = new LeapMotionEventData(eventSystem) {
          pointerId = id,
        };
        m_PointerData.Add(id, data);
        return true;
      }
      return false;
    }
#if !CP_ORION
    protected void HandleGestures(PointerEventData eventData) {
      var frame = handController.GetFrame();
      GestureList gestures = frame.Gestures(lastProcessedFrame);
      lastProcessedFrame = frame;
      for (int i = 0; i < gestures.Count; i++) {
        Gesture gesture = gestures[i];
        switch(gesture.Type){
          case Gesture.GestureType.TYPE_SCREEN_TAP:
            // Need to get pointer id from the pointable somehow.
            Click(PointerIdForGesture(gesture));
            Debug.Log("Screen Tap");
            break;
          case Gesture.GestureType.TYPE_KEY_TAP:
            Click(PointerIdForGesture(gesture));
            Debug.Log("Key Tap");
            break;
          case Gesture.GestureType.TYPE_SWIPE:
            break;
          case Gesture.GestureType.TYPE_CIRCLE:
            break;
          case Gesture.GestureType.TYPE_INVALID:
            break;
          default:
            Debug.Log("Unknown gesture type");
            break;
        }
      }
    }

    private int PointerIdForGesture(Gesture gesture) {
      if (gesture.Hands.Count == 0)
        return kIndexFingerId;
      int handId = gesture.Hands.Frontmost.Id;
      int pointerId;
      if (handIds.TryGetValue(handId, out pointerId)) {
        return pointerId;
      }
      return kIndexFingerId;
    }
#endif // !CP_ORION

    /*
      Register a pointer with a particular transform and pointer ID.
    */
    public void RegisterHandPointer(int id, Transform pointer,
                                    UnityEngine.UI.Image progressBar,
                                    #if CP_ORION
                                    // IHandModel hand
                                    // Hand hand
                                    HandModelBase hand
                                    #else
                                    HandModel hand
                                    #endif
                                    ) {
      //print("register id " + id);
      PointerEventData eventData;
      bool newData = GetPointerData(id, out eventData, true);
      int leapID = hand.GetLeapHand().Id;
      // int leapID = hand.Id;
      if (handIds.ContainsKey(leapID)) {
        Debug.Log("Warning: leap ID " + leapID + " already registered for pointer " + id);
        handIds.Remove(leapID);
      } 
      handIds[leapID] = id;

      newData |= true; // XXX avoid the warning that newData is never used.
      LeapMotionEventData eData = (LeapMotionEventData) eventData;
      //print("set pointer");
      eData.pointer = pointer;
      //print("set pointer " + eData.pointer);
      eData.progressBar = progressBar;
      eData.hand = hand;
      // pointer = t;
      // pointerId = id;
      // lastPosition = pointer.position;
    }

    public void UnregisterHandPointer(int id,
                                      #if CP_ORION
                                      // IHandModel hand
                                      // Hand hand
                                      HandModelBase hand
                                      #else
                                      HandModel hand
                                      #endif
                                      ) {

      if (hand == null
         // || hand.GetLeapHand() == null
          ) {
        // Remove by Pointer ID.
        var item = handIds.FirstOrDefault(kvp => kvp.Value == id);
        if (item.Value == id)
          handIds.Remove(item.Key);
        return;
      }
#if CP_ORION
      handIds.Remove(hand.GetLeapHand().Id);
      // handIds.Remove(hand.Id);
      //handIds.Remove(hand.LeapID());
#else
      handIds.Remove(hand.GetLeapHand().Id);
#endif
    }

    /* Reset the config. */
#if !CP_ORION
    void OnDestroy() {
#else
    protected override void OnDestroy() {
#endif
			base.OnDestroy ();
      #if !CP_ORION
      foreach(KeyValuePair<string, float> entry in originalConfigFloats) {
        // do something with entry.Value or entry.Key
        SetFloat(entry.Key, entry.Value, false);
      }
      #endif
    }
    
  }
}
