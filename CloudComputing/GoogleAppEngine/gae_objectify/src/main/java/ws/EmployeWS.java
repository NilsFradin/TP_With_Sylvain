package ws;

import static com.googlecode.objectify.ObjectifyService.ofy;

import java.util.ArrayList;
import java.util.Iterator;

import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;

import com.google.cloud.datastore.Datastore;
import com.google.cloud.datastore.DatastoreOptions;
import com.google.cloud.datastore.Entity;
import com.google.cloud.datastore.Key;
import com.google.cloud.datastore.Query;
import com.google.cloud.datastore.StructuredQuery.OrderBy;
import com.googlecode.objectify.ObjectifyService;

/**
 * REST Web Service
 *
 * @author syescassut1
 */
@Path("/employeWS")
public class EmployeWS {

	static {
		ObjectifyService.register(Employe.class);
	}
	
	/**
     * Retrieves representation of an instance of web_service.GenericResource
     * @return an instance of java.lang.String
     */
    @GET
    @Path("listEmp")
    @Produces("text/html")
    public String getHtml() {
    	ArrayList<Employe> employes = (ArrayList)ofy().load().type(Employe.class).list();
    	String ret = "<html><body>";
    	for(Employe e : employes) {
    		ret += e.getFirstName()+" "+e.getName()+"<br>";
    	}
    	ret += "</body></html>";
    	return ret;
    }
    
    @POST
    @Path("addEmp")
    @Produces("text/html")
    public String postHtml() {
    	ofy().save().entity(new Employe("Chrsit", "Cosmique")).now();
		
		return getHtml();
    }
}
