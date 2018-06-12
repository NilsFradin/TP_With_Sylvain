/**
 * StringServiceRemoteExceptionException.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.7.2  Built on : May 02, 2016 (05:55:18 BST)
 */
package string.service.client;

public class StringServiceRemoteExceptionException extends java.lang.Exception {
    private static final long serialVersionUID = 1528290008939L;
    private string.service.client.StringServiceStub.StringServiceRemoteException faultMessage;

    public StringServiceRemoteExceptionException() {
        super("StringServiceRemoteExceptionException");
    }

    public StringServiceRemoteExceptionException(java.lang.String s) {
        super(s);
    }

    public StringServiceRemoteExceptionException(java.lang.String s,
        java.lang.Throwable ex) {
        super(s, ex);
    }

    public StringServiceRemoteExceptionException(java.lang.Throwable cause) {
        super(cause);
    }

    public void setFaultMessage(
        string.service.client.StringServiceStub.StringServiceRemoteException msg) {
        faultMessage = msg;
    }

    public string.service.client.StringServiceStub.StringServiceRemoteException getFaultMessage() {
        return faultMessage;
    }
}
