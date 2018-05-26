package webservices;

import static com.googlecode.objectify.ObjectifyService.ofy;

import java.util.List;

import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;

import com.googlecode.objectify.ObjectifyService;

import modeles.Account;
import modeles.Risk;

/**
 * REST Web Service
 *
 * @author syescassut1
 */
@Path("/account")
public class AccountManagerWS {

	static {
		ObjectifyService.register(Account.class);
	}

    @GET
    @Path("list")
    @Produces("application/json")
    public List<Account> getAllJson() {
    	List<Account> accounts = ofy().load().type(Account.class).list();
    	
    	return accounts;
    }
    
    @GET
    @Path("get/{name}")
    @Produces("application/json")
    public Account getJson(@PathParam("name") String name) {
    	Account a = ofy().load().type(Account.class).filter("name", name).first().now();
    	
    	return a;
    }
    
    
    @POST
    @Path("add/{name}/{firstName}/{account}/{risk}")
    @Produces("application/json")
    public List<Account> postJson(@PathParam("name") String name, @PathParam("firstName") String firstName, @PathParam("account") int account, @PathParam("risk") String risk) {
    	if(risk.equals("high")) {
    		ofy().save().entity(new Account(name, firstName, account, Risk.HIGH)).now();
    	} else {
    		ofy().save().entity(new Account(name, firstName, account, Risk.LOW)).now();
    	}
		
		return getAllJson();
    }
    
    @DELETE
    @Path("delete/{id}")
    @Produces("application/json")
    public List<Account> deleteJson(@PathParam("id") String id) {
    	Account a = ofy().load().type(Account.class).id(id).now();
    	ofy().delete().entity(a);
    	
    	return getAllJson();
    }
    
    @PUT
    @Path("put/{name}/{account}")
    @Produces("application/json")
    public int putJson(@PathParam("name") String name, @PathParam("account") int account) {
    	Account a = ofy().load().type(Account.class).filter("name", name).first().now();
    	a.setAccount(a.getAccount()+account);
    	
    	return a.getAccount();
    }
}

