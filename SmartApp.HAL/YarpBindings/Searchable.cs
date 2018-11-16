//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class Searchable : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Searchable(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Searchable obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Searchable() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_Searchable(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public new bool check(string key) {
    bool ret = yarpPINVOKE.Searchable_check__SWIG_0(swigCPtr, key);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new bool check(string key, string comment) {
    bool ret = yarpPINVOKE.Searchable_check__SWIG_1(swigCPtr, key, comment);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Value find(string key) {
    Value ret = new Value(yarpPINVOKE.Searchable_find(swigCPtr, key), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Bottle findGroup(string key) {
    Bottle ret = new Bottle(yarpPINVOKE.Searchable_findGroup__SWIG_0(swigCPtr, key), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Bottle findGroup(string key, string comment) {
    Bottle ret = new Bottle(yarpPINVOKE.Searchable_findGroup__SWIG_1(swigCPtr, key, comment), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Value check(string key, Value fallback, string comment) {
    Value ret = new Value(yarpPINVOKE.Searchable_check__SWIG_2(swigCPtr, key, Value.getCPtr(fallback), comment), true);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Value check(string key, Value fallback) {
    Value ret = new Value(yarpPINVOKE.Searchable_check__SWIG_3(swigCPtr, key, Value.getCPtr(fallback)), true);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool isNull() {
    bool ret = yarpPINVOKE.Searchable_isNull(swigCPtr);
    return ret;
  }

  public new string toString_c() {
    string ret = yarpPINVOKE.Searchable_toString_c(swigCPtr);
    return ret;
  }

  public virtual void setMonitor(SearchMonitor monitor, string context) {
    yarpPINVOKE.Searchable_setMonitor__SWIG_0(swigCPtr, SearchMonitor.getCPtr(monitor), context);
  }

  public virtual void setMonitor(SearchMonitor monitor) {
    yarpPINVOKE.Searchable_setMonitor__SWIG_1(swigCPtr, SearchMonitor.getCPtr(monitor));
  }

  public virtual SearchMonitor getMonitor() {
    global::System.IntPtr cPtr = yarpPINVOKE.Searchable_getMonitor(swigCPtr);
    SearchMonitor ret = (cPtr == global::System.IntPtr.Zero) ? null : new SearchMonitor(cPtr, false);
    return ret;
  }

  public virtual string getMonitorContext() {
    string ret = yarpPINVOKE.Searchable_getMonitorContext(swigCPtr);
    return ret;
  }

  public virtual void reportToMonitor(SearchReport report) {
    yarpPINVOKE.Searchable_reportToMonitor(swigCPtr, SearchReport.getCPtr(report));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

}