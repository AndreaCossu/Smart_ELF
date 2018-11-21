//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class Property : Searchable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal Property(global::System.IntPtr cPtr, bool cMemoryOwn) : base(yarpPINVOKE.Property_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Property() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_Property(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public new bool check(string key, string comment) {
    bool ret = yarpPINVOKE.Property_check__SWIG_0_0(swigCPtr, key, comment);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Value check(string key, Value fallback, string comment) {
    Value ret = new Value(yarpPINVOKE.Property_check__SWIG_0_1(swigCPtr, key, Value.getCPtr(fallback), comment), true);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Value check(string key, Value fallback) {
    Value ret = new Value(yarpPINVOKE.Property_check__SWIG_0_2(swigCPtr, key, Value.getCPtr(fallback)), true);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Bottle findGroup(string key, string comment) {
    Bottle ret = new Bottle(yarpPINVOKE.Property_findGroup__SWIG_0_0(swigCPtr, key, comment), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Property(int hash_size) : this(yarpPINVOKE.new_Property__SWIG_0(hash_size), true) {
  }

  public Property() : this(yarpPINVOKE.new_Property__SWIG_1(), true) {
  }

  public Property(string str) : this(yarpPINVOKE.new_Property__SWIG_2(str), true) {
  }

  public Property(Property prop) : this(yarpPINVOKE.new_Property__SWIG_3(Property.getCPtr(prop)), true) {
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public new bool check(string key) {
    bool ret = yarpPINVOKE.Property_check__SWIG_1(swigCPtr, key);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void put(string key, string value) {
    yarpPINVOKE.Property_put__SWIG_0(swigCPtr, key, value);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public void put(string key, Value value) {
    yarpPINVOKE.Property_put__SWIG_1(swigCPtr, key, Value.getCPtr(value));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public void put(string key, int value) {
    yarpPINVOKE.Property_put__SWIG_3(swigCPtr, key, value);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public void put(string key, double value) {
    yarpPINVOKE.Property_put__SWIG_4(swigCPtr, key, value);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public Property addGroup(string key) {
    Property ret = new Property(yarpPINVOKE.Property_addGroup(swigCPtr, key), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void unput(string key) {
    yarpPINVOKE.Property_unput(swigCPtr, key);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public new Value find(string key) {
    Value ret = new Value(yarpPINVOKE.Property_find(swigCPtr, key), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Bottle findGroup(string key) {
    Bottle ret = new Bottle(yarpPINVOKE.Property_findGroup__SWIG_1(swigCPtr, key), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void clear() {
    yarpPINVOKE.Property_clear(swigCPtr);
  }

  public void fromString(string txt, bool wipe) {
    yarpPINVOKE.Property_fromString__SWIG_0(swigCPtr, txt, wipe);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public void fromString(string txt) {
    yarpPINVOKE.Property_fromString__SWIG_1(swigCPtr, txt);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public void fromCommand(int argc, SWIGTYPE_p_p_char argv, bool skipFirst, bool wipe) {
    yarpPINVOKE.Property_fromCommand__SWIG_0(swigCPtr, argc, SWIGTYPE_p_p_char.getCPtr(argv), skipFirst, wipe);
  }

  public void fromCommand(int argc, SWIGTYPE_p_p_char argv, bool skipFirst) {
    yarpPINVOKE.Property_fromCommand__SWIG_1(swigCPtr, argc, SWIGTYPE_p_p_char.getCPtr(argv), skipFirst);
  }

  public void fromCommand(int argc, SWIGTYPE_p_p_char argv) {
    yarpPINVOKE.Property_fromCommand__SWIG_2(swigCPtr, argc, SWIGTYPE_p_p_char.getCPtr(argv));
  }

  public void fromArguments(string arguments, bool wipe) {
    yarpPINVOKE.Property_fromArguments__SWIG_0(swigCPtr, arguments, wipe);
  }

  public void fromArguments(string arguments) {
    yarpPINVOKE.Property_fromArguments__SWIG_1(swigCPtr, arguments);
  }

  public bool fromConfigFile(string fname, bool wipe) {
    bool ret = yarpPINVOKE.Property_fromConfigFile__SWIG_0(swigCPtr, fname, wipe);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool fromConfigFile(string fname) {
    bool ret = yarpPINVOKE.Property_fromConfigFile__SWIG_1(swigCPtr, fname);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool fromConfigFile(string fname, Searchable env, bool wipe) {
    bool ret = yarpPINVOKE.Property_fromConfigFile__SWIG_2(swigCPtr, fname, Searchable.getCPtr(env), wipe);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool fromConfigFile(string fname, Searchable env) {
    bool ret = yarpPINVOKE.Property_fromConfigFile__SWIG_3(swigCPtr, fname, Searchable.getCPtr(env));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool fromConfigDir(string dirname, string section, bool wipe) {
    bool ret = yarpPINVOKE.Property_fromConfigDir__SWIG_0(swigCPtr, dirname, section, wipe);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool fromConfigDir(string dirname, string section) {
    bool ret = yarpPINVOKE.Property_fromConfigDir__SWIG_1(swigCPtr, dirname, section);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool fromConfigDir(string dirname) {
    bool ret = yarpPINVOKE.Property_fromConfigDir__SWIG_2(swigCPtr, dirname);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void fromConfig(string txt, bool wipe) {
    yarpPINVOKE.Property_fromConfig__SWIG_0(swigCPtr, txt, wipe);
  }

  public void fromConfig(string txt) {
    yarpPINVOKE.Property_fromConfig__SWIG_1(swigCPtr, txt);
  }

  public void fromConfig(string txt, Searchable env, bool wipe) {
    yarpPINVOKE.Property_fromConfig__SWIG_2(swigCPtr, txt, Searchable.getCPtr(env), wipe);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public void fromConfig(string txt, Searchable env) {
    yarpPINVOKE.Property_fromConfig__SWIG_3(swigCPtr, txt, Searchable.getCPtr(env));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public void fromQuery(string url, bool wipe) {
    yarpPINVOKE.Property_fromQuery__SWIG_0(swigCPtr, url, wipe);
  }

  public void fromQuery(string url) {
    yarpPINVOKE.Property_fromQuery__SWIG_1(swigCPtr, url);
  }

  public new string toString_c() {
    string ret = yarpPINVOKE.Property_toString_c(swigCPtr);
    return ret;
  }

  public new bool read(ConnectionReader reader) {
    bool ret = yarpPINVOKE.Property_read(swigCPtr, ConnectionReader.getCPtr(reader));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new bool write(ConnectionWriter writer) {
    bool ret = yarpPINVOKE.Property_write(swigCPtr, ConnectionWriter.getCPtr(writer));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new string toString() {
    string ret = yarpPINVOKE.Property_toString(swigCPtr);
    return ret;
  }

}