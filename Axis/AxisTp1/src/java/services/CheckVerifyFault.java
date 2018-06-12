/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package services;

import javax.xml.ws.WebFault;

/**
 *
 * @author syescassut1
 */
@WebFault(name="CheckVerifyFault")
public class CheckVerifyFault extends Exception{
    private  CheckFaultBean faultInfo;
    
    public CheckVerifyFault(String message, CheckFaultBean faultInfo){
        super(message);
        this.faultInfo = faultInfo;
    }
    
    public CheckVerifyFault(String message, CheckFaultBean faultInfo, Throwable cause){
        super(message, cause);
        this.faultInfo = faultInfo;
    }
    
    public CheckFaultBean getFaultInfo(){
        return faultInfo;
    }
}
