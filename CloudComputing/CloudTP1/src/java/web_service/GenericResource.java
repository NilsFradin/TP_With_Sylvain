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
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.PathParam;
import javax.ws.rs.core.MediaType;

/**
 * REST Web Service
 *
 * @author syescassut1
 */
@Path("generic")
public class GenericResource {

    @Context
    private UriInfo context;
    
    public static ArrayList<String> livres = new ArrayList<String>() {{
      add("GoT");
      add("SdA");
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
    @Produces("text/html")
    public String getHtml() {
        String content ="<html><body>";
        for(String s : livres) {
            content += "<p>Livre "+s+"</p>";
        }
        content += "<a href=\"/CloudTP1/webresources/generic/post/livre\">/CloudTP1/webresources/generic/post/{livre}</a><br>";
        content += "<a href=\"/CloudTP1/webresources/generic/get/\">/CloudTP1/webresources/generic/get/</a><br>";
        content += "<a href=\"/CloudTP1/webresources/generic/delete/livre\">/CloudTP1/webresources/generic/delete/{livre}</a><br>";
        content += "<a href=\"/CloudTP1/webresources/generic/put/oldLivre/newLivre\">/CloudTP1/webresources/generic/put/{oldLivre}/{newLivre}</a><br>";
        content += "</body></html>";
        
        return content;
    }

    /**
     * POST method for updating or creating an instance of GenericResource
     * @param content representation for the resource
     */
    @POST
    @Path("post/{livre}")
    @Consumes("application/html")
    @Produces("text/html")
    public String postHtml(@PathParam("livre") String livre) {
        livres.add(livre);
        return getHtml();
    }
    
    @DELETE
    @Path("delete/{livre}")
    @Produces("text/html")
    public String deleteHtml(@PathParam("livre") String livre) {
        livres.remove(livre);
        return getHtml();
    }
    
     /**
     * PUT method for updating or creating an instance of GenericResource
     * @param content representation for the resource
     */
    @PUT
    @Path("put/{oldL}/{newL}")
    @Produces("text/html")
    public String putHtml(@PathParam("oldL") String oldL, @PathParam("newL") String newL) {
        if(livres.contains(oldL)) {
            livres.add(newL);
            livres.remove(oldL);
        }
        return getHtml();
    }
}
