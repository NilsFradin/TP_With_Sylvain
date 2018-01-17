/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package client;

import javax.ws.rs.ClientErrorException;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.Entity;
import javax.ws.rs.client.WebTarget;

/**
 * Jersey REST client generated for REST resource:GenericResource [generic]<br>
 * USAGE:
 * <pre>
 *        ClientRestFull client = new ClientRestFull();
 *        Object response = client.XXX(...);
 *        // do whatever with response
 *        client.close();
 * </pre>
 *
 * @author syescassut1
 */
public class ClientRestFull {

    private WebTarget webTarget;
    private Client client;
    private static final String BASE_URI = "http://localhost:8080/CloudTP1/webresources";

    public ClientRestFull() {
        client = javax.ws.rs.client.ClientBuilder.newClient();
        webTarget = client.target(BASE_URI).path("generic");
    }

    public String getHtml() throws ClientErrorException {
        WebTarget resource = webTarget;
        resource = resource.path("get");
        return resource.request(javax.ws.rs.core.MediaType.TEXT_HTML).get(String.class);
    }

    public String postHtml(String livre) throws ClientErrorException {
        return webTarget.path(java.text.MessageFormat.format("post/{0}", new Object[]{livre})).request().post(null, String.class);
    }

    public String putHtml(String oldL, String newL) throws ClientErrorException {
        Entity<?> empty = Entity.text("");
        return webTarget.path(java.text.MessageFormat.format("put/{0}/{1}", new Object[]{oldL, newL})).request().put(empty, String.class);
    }

    public String deleteHtml(String livre) throws ClientErrorException {
        return webTarget.path(java.text.MessageFormat.format("delete/{0}", new Object[]{livre})).request().delete(String.class);
    }
    
    public void close() {
        client.close();
    }
    
}
