package org.apache.axis2.axis2services;

import java.rmi.RemoteException;

public class CalculatorService {

	public int calcul(int i, int j) throws RemoteException {
		int result = 0;
        if(j == 0){
			throw new RemoteException("Division par 0 interdite !");
        }
        try {
            result = i / j;
        }catch (Exception e){
            System.out.println(e.getMessage());
        }
        
        return result;
	}
	
	public java.lang.String version() {
		return "1.0";
	}
}
