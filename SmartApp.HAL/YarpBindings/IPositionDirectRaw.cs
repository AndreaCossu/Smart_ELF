//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class IPositionDirectRaw : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal IPositionDirectRaw(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(IPositionDirectRaw obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~IPositionDirectRaw() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_IPositionDirectRaw(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public virtual bool getAxes(SWIGTYPE_p_int axes) {
    bool ret = yarpPINVOKE.IPositionDirectRaw_getAxes(swigCPtr, SWIGTYPE_p_int.getCPtr(axes));
    return ret;
  }

  public virtual bool setPositionRaw(int j, double arg1) {
    bool ret = yarpPINVOKE.IPositionDirectRaw_setPositionRaw(swigCPtr, j, arg1);
    return ret;
  }

  public virtual bool setPositionsRaw(int n_joint, SWIGTYPE_p_int joints, SWIGTYPE_p_double refs) {
    bool ret = yarpPINVOKE.IPositionDirectRaw_setPositionsRaw__SWIG_0(swigCPtr, n_joint, SWIGTYPE_p_int.getCPtr(joints), SWIGTYPE_p_double.getCPtr(refs));
    return ret;
  }

  public virtual bool setPositionsRaw(SWIGTYPE_p_double refs) {
    bool ret = yarpPINVOKE.IPositionDirectRaw_setPositionsRaw__SWIG_1(swigCPtr, SWIGTYPE_p_double.getCPtr(refs));
    return ret;
  }

  public virtual bool getRefPositionRaw(int joint, SWIGTYPE_p_double arg1) {
    bool ret = yarpPINVOKE.IPositionDirectRaw_getRefPositionRaw(swigCPtr, joint, SWIGTYPE_p_double.getCPtr(arg1));
    return ret;
  }

  public virtual bool getRefPositionsRaw(SWIGTYPE_p_double refs) {
    bool ret = yarpPINVOKE.IPositionDirectRaw_getRefPositionsRaw__SWIG_0(swigCPtr, SWIGTYPE_p_double.getCPtr(refs));
    return ret;
  }

  public virtual bool getRefPositionsRaw(int n_joint, SWIGTYPE_p_int joints, SWIGTYPE_p_double refs) {
    bool ret = yarpPINVOKE.IPositionDirectRaw_getRefPositionsRaw__SWIG_1(swigCPtr, n_joint, SWIGTYPE_p_int.getCPtr(joints), SWIGTYPE_p_double.getCPtr(refs));
    return ret;
  }

}