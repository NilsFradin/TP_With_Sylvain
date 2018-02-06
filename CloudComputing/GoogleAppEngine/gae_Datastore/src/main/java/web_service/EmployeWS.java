package web_service;

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

@Path("/employeWS")
public class EmployeWS {

    @Context
    private UriInfo context;

    /**
     * Retrieves representation of an instance of web_service.GenericResource
     * @return an instance of java.lang.String
     */
    @GET
    @Path("listEmp")
    @Produces("text/html")
    public String getHtml() {
    	Datastore datastore = DatastoreOptions.newBuilder().setProjectId("inf63app9").build().getService();
    	Query<Entity> query = Query.newEntityQueryBuilder().setKind("Employe").setOrderBy(OrderBy.asc("name")).build();
    	Iterator<Entity> it = datastore.run(query);
    	String ret = "<html><body>";
    	while(it.hasNext()) {
    		Entity e = it.next();
    		ret += "iteration";
    		ret += e.getString("name")+"<br>";
    	}
    	ret += "</body></html>";
    	return ret;
    }
    
    @POST
    @Path("addEmp")
    @Produces("text/html")
    public String postHtml() {
    	Datastore datastore = DatastoreOptions.newBuilder().setProjectId("inf63app9").build().getService();
		String kind = "Employe";
		String name = "first";
		Key taskKey = datastore.newKeyFactory().setKind(kind).newKey(name);
		
		Entity employe = Entity.newBuilder(taskKey)
				.set("name", name)
				.build();
		
		datastore.put(employe);
		
		return getHtml();
    }
}
