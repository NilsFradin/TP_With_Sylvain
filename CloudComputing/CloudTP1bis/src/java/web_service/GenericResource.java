/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package web_service;

import java.util.ArrayList;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;
import model.Book;

/**
 * REST Web Service
 *
 * @author syescassut1
 */
@Path("generic")
public class GenericResource {

    @Context
    private UriInfo context;

    public static ArrayList<Book> books = new ArrayList<Book>() {{
      add(new Book() {{ setTitle("GoT"); }});
      add(new Book() {{ setTitle("SdA"); }});
    }};
    
    /**
     * Creates a new instance of GenericResource
     */
    public GenericResource() {
    }

    /**
     * Retrieves representation of an instance of web_service.GenericResource
     * @return an instance of java.lang.String
     */
    @GET
    @Path("get")
    @Produces("application/xml")
    public ArrayList<Book> getXml() {
        return books;
    }

    /**
     * POST method for updating or creating an instance of GenericResource
     * @param content representation for the resource
     */
    @POST
    @Path("post/{title}")
    @Produces("application/xml")
    public ArrayList<Book> postXml(@PathParam("title") String title) {
        books.add(new Book(title));
        return getXml();
    }
}
