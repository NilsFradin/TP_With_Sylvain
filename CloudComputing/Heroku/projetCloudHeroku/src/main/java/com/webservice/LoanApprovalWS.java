package com.webservice;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.ProtocolException;
import java.net.URL;

import javax.net.ssl.HttpsURLConnection;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

/**
 * Root resource (exposed at "myresource" path)
 */
@Path("loanapproval")
public class LoanApprovalWS {

    /**
     * Method handling HTTP GET requests. The returned object will be sent
     * to the client as "text/plain" media type.
     *
     * @return String that will be returned as a text/plain response.
     * @throws MalformedURLException 
     */
    @GET
    @Path("check/{name}/{firstName}/{amount}")
    @Produces("application/json")
    public String check(@PathParam("name") String name, @PathParam("firstName") String firstName, @PathParam("amount") int amount) {
    	try {
    		HttpURLConnection conn;
    		BufferedReader br;
    		String output;
	    	if(amount < 10000) {
	    		conn = callWebService("http://localhost:8080/webservices/check/account/"+name, "GET");
	        	br = new BufferedReader(new InputStreamReader(conn.getInputStream()));
	        	output = br.readLine();
	        	if(output.equals("HIGH")) {
	        		conn = callWebService("http://localhost:8080/webservices/approval/get/"+name, "GET");
		        	br = new BufferedReader(new InputStreamReader(conn.getInputStream()));
		        	output = br.readLine();
		        	if(output.equals("ACCEPTED")) {
		        		conn = callWebService("http://localhost:8080/webservices/account/put/"+name+amount, "PUT");
		        		conn.disconnect();
			        	return "ACCEPTED";
		        	} else {
		        		conn.disconnect();
		        		return "REFUSED";
		        	}
	        	} else { // LOW
	        		conn = callWebService("http://localhost:8080/webservices/account/put/"+name+amount, "PUT");
	        		conn.disconnect();
		        	return "ACCEPTED";
	        	}
	        } else { // amount >= 10000
	        	conn = callWebService("http://localhost:8080/webservices/approval/get/"+name, "GET");
	        	br = new BufferedReader(new InputStreamReader(conn.getInputStream()));
	        	output = br.readLine();
	        	if(output.equals("ACCEPTED")) {
	        		conn = callWebService("http://localhost:8080/webservices/account/put/"+name+amount, "PUT");
	        		conn.disconnect();
		        	return "ACCEPTED";
	        	} else {
	        		conn.disconnect();
	        		return "REFUSED";
	        	}
	        }
        }  catch (MalformedURLException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
    	
    	return "REFUSED";
    }
    
    private HttpURLConnection callWebService(String urlStr, String verb) {
    	try {
    		URL url = new URL(urlStr);			
	    	HttpURLConnection conn = (HttpURLConnection)url.openConnection();
	    	conn.setRequestMethod(verb);
	    	conn.setRequestProperty("Accept", "application/json");
	    	if(conn.getResponseCode() != 200) {
	    		throw new RuntimeException("Failed : HTTP error code : "+conn.getResponseCode());
	    	}
	    	
	    	return conn;
		} catch (MalformedURLException e) {
			e.printStackTrace();
		} catch (ProtocolException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
    	
    	return null;
    }
}
