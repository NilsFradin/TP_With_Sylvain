package string.service.client;

import string.service.client.StringServiceStub;
import string.service.client.StringServiceStub.Add_chaine;
import string.service.client.StringServiceStub.Add_chaineResponse;
import string.service.client.StringServiceStub.Lit_chaine;
import string.service.client.StringServiceStub.Lit_chaineResponse;
import string.service.client.StringServiceRemoteExceptionException;

public class Client{
	public static void main(java.lang.String args[]){
		try{
			
		StringServiceStub stub = new StringServiceStub("http://localhost:8080/axis2/services/StringService.StringServiceHttpSoap12Endpoint/");
		Add_chaine addChaine = new Add_chaine();
		addChaine.setArgs0("Le bon Test : ");
		addChaine.setArgs1("a marcher !");
		Add_chaineResponse response =  stub.add_chaine(addChaine);
		System.out.println(response.get_return());
		
		Lit_chaineResponse litResponse = stub.lit_chaine(new Lit_chaine());
		System.out.println(litResponse.get_return());
	}catch(StringServiceRemoteExceptionException se){
		se.printStackTrace();
	}catch(java.rmi.RemoteException e){
		e.printStackTrace();
	}
	}
}
