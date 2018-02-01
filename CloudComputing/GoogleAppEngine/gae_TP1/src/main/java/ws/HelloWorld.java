package ws;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;

/**
 * REST Web Service
 *
 * @author syescassut1
 */
@Path("/helloworld")
public class HelloWorld {

    @Context
    private UriInfo context;

    /**
     * Retrieves representation of an instance of web_service.GenericResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces("text/html")
    public String getHtml() {
        String content ="<html><body>";
        content += "<h1>Hello World !</h1>";
        content += "</body></html>";

        return content;
    }
}
