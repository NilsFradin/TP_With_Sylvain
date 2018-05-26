package project;

import static com.googlecode.objectify.ObjectifyService.ofy;

import java.rmi.server.UID;
import java.util.ArrayList;

import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;

import com.googlecode.objectify.ObjectifyService;

/**
 * REST Web Service
 *
 * @author syescassut1
 */
@Path("/account")
public class AccountWS {

	static {
		ObjectifyService.register(Account.class);
	}

    @GET
    @Path("list")
    @Produces("text/html")
    public String getHtml() {
    	ArrayList<Account> accounts = (ArrayList)ofy().load().type(Account.class).list();
    	String response = "<html><body>";
    	for(Account a : accounts) {
    		response += a.getId()+" "+a.getFirstName()+" "+a.getName()+" "+a.getAccount()+" "+a.getRisk()+"<br>";
    	}
    	response += "</body></html>";
    	
    	return response;
    }
    
    @POST
    @Path("add/{name}/{firstName}/{account}/{risk}")
    @Produces("text/html")
    public String postHtml(@PathParam("name") String name, @PathParam("firstName") String firstName, @PathParam("account") int account, @PathParam("risk") String risk) {
    	if(risk.equals("high")) {
    		ofy().save().entity(new Account(name, firstName, account, Risk.HIGH)).now();
    	} else {
    		ofy().save().entity(new Account(name, firstName, account, Risk.LOW)).now();
    	}
		
		return getHtml();
    }
    
    @DELETE
    @Path("delete/{id}")
    @Produces("text/html")
    public String deleteHtml(@PathParam("id") int id) {
    	Account a = ofy().load().type(Account.class).id(id).now();
    	ofy().delete().entity(a);
    	
    	return getHtml();
    }
}

