using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class UI_InteractionController : MonoBehaviour
{
    [SerializeField]
    GameObject UIController;

    [SerializeField]
    GameObject BaseController;

    [SerializeField]
    InputActionReference inputActionReference_UISwitcher;

    bool isUICanvasActive = false;

    [SerializeField]
<<<<<<< HEAD
    GameObject UIGameObjets;


=======
    GameObject UICanvasGameobject;

  
>>>>>>> 5be909e4ff33c30cca1ed4eff100ded4c235ad98
    private void OnEnable()
    {
        inputActionReference_UISwitcher.action.performed += ActivateUIMode;
    }
    private void OnDisable()
    {
        inputActionReference_UISwitcher.action.performed -= ActivateUIMode;

    }

    private void Start()
    {
        //Deactivating UI Canvas Gameobject by default
<<<<<<< HEAD
        if (UIGameObjets !=null)
        {
            UIGameObjets.SetActive(false);
=======
        if (UICanvasGameobject !=null)
        {
            UICanvasGameobject.SetActive(false);
>>>>>>> 5be909e4ff33c30cca1ed4eff100ded4c235ad98

        }

        //Deactivating UI Controller by default
        UIController.GetComponent<XRRayInteractor>().enabled = false;
        UIController.GetComponent<XRInteractorLineVisual>().enabled = false;
    }

    /// <summary>
    /// This method is called when the player presses UI Switcher Button which is the input action defined in Default Input Actions.
    /// When it is called, UI interaction mode is switched on and off according to the previous state of the UI Canvas.
    /// </summary>
    /// <param name="obj"></param>
    private void ActivateUIMode(InputAction.CallbackContext obj)
    {
        if (!isUICanvasActive)
        {
            isUICanvasActive = true;

            //Activating UI Controller by enabling its XR Ray Interactor and XR Interactor Line Visual
            UIController.GetComponent<XRRayInteractor>().enabled = true;
            UIController.GetComponent<XRInteractorLineVisual>().enabled = true;

            //Deactivating Base Controller by disabling its XR Direct Interactor
            BaseController.GetComponent<XRDirectInteractor>().enabled = false;

<<<<<<< HEAD


            //Activating the UI Canvas Gameobject
            UIGameObjets.SetActive(true);
=======
          

            //Activating the UI Canvas Gameobject
            UICanvasGameobject.SetActive(true);
>>>>>>> 5be909e4ff33c30cca1ed4eff100ded4c235ad98
        }
        else
        {
            isUICanvasActive = false;

            //De-Activating UI Controller by enabling its XR Ray Interactor and XR Interactor Line Visual
            UIController.GetComponent<XRRayInteractor>().enabled = false;
            UIController.GetComponent<XRInteractorLineVisual>().enabled = false;

            //Activating Base Controller by disabling its XR Direct Interactor
            BaseController.GetComponent<XRDirectInteractor>().enabled = true;

            //De-Activating the UI Canvas Gameobject
<<<<<<< HEAD
            UIGameObjets.SetActive(false);
=======
            UICanvasGameobject.SetActive(false);
>>>>>>> 5be909e4ff33c30cca1ed4eff100ded4c235ad98
        }

    }
}
