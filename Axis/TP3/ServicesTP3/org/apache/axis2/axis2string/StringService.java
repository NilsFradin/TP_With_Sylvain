package org.apache.axis2.axis2string;

import java.lang.String;
import java.rmi.RemoteException;

public class StringService{
	
	private String chaine = ""; 
	
	public String add_chaine(String string1, String string2 ) throws RemoteException{
		
		if(string1 == null || string2 == null){
			throw new RemoteException("Attention un des arguments est NULL !");
		}
		
		this.chaine = String.format("%s%s", string1, string2);
		return this.chaine;
	}
	
	public String lit_chaine(){
		return this.chaine;
	}
		
}
