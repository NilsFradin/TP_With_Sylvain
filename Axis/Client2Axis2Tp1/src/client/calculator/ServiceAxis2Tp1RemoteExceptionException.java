/**
 * ServiceAxis2Tp1RemoteExceptionException.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.7.2  Built on : May 02, 2016 (05:55:18 BST)
 */
package client.calculator;

public class ServiceAxis2Tp1RemoteExceptionException extends java.lang.Exception {
    private static final long serialVersionUID = 1528286393095L;
    private client.calculator.ServiceAxis2Tp1Stub.ServiceAxis2Tp1RemoteException faultMessage;

    public ServiceAxis2Tp1RemoteExceptionException() {
        super("ServiceAxis2Tp1RemoteExceptionException");
    }

    public ServiceAxis2Tp1RemoteExceptionException(java.lang.String s) {
        super(s);
    }

    public ServiceAxis2Tp1RemoteExceptionException(java.lang.String s,
        java.lang.Throwable ex) {
        super(s, ex);
    }

    public ServiceAxis2Tp1RemoteExceptionException(java.lang.Throwable cause) {
        super(cause);
    }

    public void setFaultMessage(
        client.calculator.ServiceAxis2Tp1Stub.ServiceAxis2Tp1RemoteException msg) {
        faultMessage = msg;
    }

    public client.calculator.ServiceAxis2Tp1Stub.ServiceAxis2Tp1RemoteException getFaultMessage() {
        return faultMessage;
    }
}
