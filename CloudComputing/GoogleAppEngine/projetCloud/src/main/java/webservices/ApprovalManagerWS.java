package webservices;

import static com.googlecode.objectify.ObjectifyService.ofy;

import java.util.List;

import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;

import com.googlecode.objectify.ObjectifyService;

import modeles.Approval;
import modeles.ManualResponse;

/**
 * REST Web Service
 *
 * @author syescassut1
 */
@Path("/approval")
public class ApprovalManagerWS {

	static {
		ObjectifyService.register(Approval.class);
	}

    @GET
    @Path("list")
    @Produces("application/json")
    public List<Approval> getAllJson() {
    	List<Approval> approvals = ofy().load().type(Approval.class).list();
    	
    	return approvals;
    }
    
    @GET
    @Path("get/{name}")
    @Produces("application/json")
    public ManualResponse getJson(@PathParam("name") String name) {
    	Approval a = ofy().load().type(Approval.class).filter("name", name).first().now();
    	
    	return a.getManualResponse();
    }
    
    @POST
    @Path("add/{name}/{manualResponse}")
    @Produces("application/json")
    public List<Approval> postJson(@PathParam("name") String name, @PathParam("manualResponse") String manualResponse) {
    	if(manualResponse.equals("accepted")) {
    		ofy().save().entity(new Approval(name, ManualResponse.ACCEPTED)).now();
    	} else {
    		ofy().save().entity(new Approval(name, ManualResponse.REFUSED)).now();
    	}
		
		return getAllJson();
    }
    
    @DELETE
    @Path("delete/{id}")
    @Produces("application/json")
    public List<Approval> deleteJson(@PathParam("id") String id) {
    	Approval a = ofy().load().type(Approval.class).id(id).now();
    	ofy().delete().entity(a);
    	
    	return getAllJson();
    }
}

