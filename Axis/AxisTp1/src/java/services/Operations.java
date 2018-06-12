/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package services;

import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.xml.soap.SOAPException;

/**
 *
 * @author syescassut1
 */
@WebService(serviceName = "Operations")
public class Operations {

    /**
     * Web service operation
     */
    @WebMethod(operationName = "intToString")
    public String intToString(@WebParam(name = "entier") int entier) {
        return Integer.toString(entier);
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "division")
    public int division(@WebParam(name = "entier1") int entier1, @WebParam(name = "entier2") int entier2) throws CheckVerifyFault {
        int result = 0;
        if(entier2 == 0){
                throw new CheckVerifyFault("Erreur dans la division", new CheckFaultBean("Division par 0 interdite !"));
        }
        try {
            result = entier1 / entier2;
        }catch (Exception e){
            
            System.out.println(e.getMessage());
        }
        
        return result;
    }
}
