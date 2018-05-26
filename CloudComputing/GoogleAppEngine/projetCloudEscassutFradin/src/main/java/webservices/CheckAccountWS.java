package webservices;

import static com.googlecode.objectify.ObjectifyService.ofy;

import javax.ws.rs.GET;
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
@Path("/check")
public class CheckAccountWS {

	static {
		ObjectifyService.register(Account.class);
	}

    @GET
    @Path("account/{name}")
    @Produces("application/json")
    public Risk getJson(@PathParam("name") String name) {
    	Account a = ofy().load().type(Account.class).filter("name", name).first().now();
    	
    	return a.getRisk();
    }
}

