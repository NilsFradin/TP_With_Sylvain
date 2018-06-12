
/**
 * VersionExceptionException.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.7.2  Built on : May 02, 2016 (05:55:18 BST)
 */

package client;

public class VersionExceptionException extends java.lang.Exception{

    private static final long serialVersionUID = 1528113170285L;
    
    private client.VersionStub.VersionException faultMessage;

    
        public VersionExceptionException() {
            super("VersionExceptionException");
        }

        public VersionExceptionException(java.lang.String s) {
           super(s);
        }

        public VersionExceptionException(java.lang.String s, java.lang.Throwable ex) {
          super(s, ex);
        }

        public VersionExceptionException(java.lang.Throwable cause) {
            super(cause);
        }
    

    public void setFaultMessage(client.VersionStub.VersionException msg){
       faultMessage = msg;
    }
    
    public client.VersionStub.VersionException getFaultMessage(){
       return faultMessage;
    }
}
    
