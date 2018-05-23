package heroku;

import java.net.URI;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

/**
 * Root resource (exposed at "myresource" path)
 */
@Path("myresource")
public class MyResource {

    /**
     * Method handling HTTP GET requests. The returned object will be sent
     * to the client as "text/plain" media type.
     *
     * @return String that will be returned as a text/plain response.
     */
    @GET
    @Path("/{name}")
    @Produces("text/html")
    public String getIt(@PathParam("name") String name) {
        return "<html><body><h1>Hello "+name+"</h1></body></html>";
    }
    
    private Connection getConnection() throws Exception {
	   // Class.forName("org.postgresql.Driver");
	    URI dbUri = new URI(System.getenv("DATABASE_URL"));

	    String username = dbUri.getUserInfo().split(":")[0];
	    String password = dbUri.getUserInfo().split(":")[1];
	    String dbUrl = "jdbc:postgresql://" + dbUri.getHost() + dbUri.getPath();

	    return DriverManager.getConnection(dbUrl, username, password);
    }
    
    @GET
    @Path("/addTick")
    public String addTickGet() {
    	return addTick();
    }
    
    private String addTick() {
    	try {
  	      Connection connection = getConnection();

  	      Statement stmt = connection.createStatement();
  	      stmt.executeUpdate("CREATE TABLE IF NOT EXISTS ticks (tick timestamp)");
  	      stmt.executeUpdate("INSERT INTO ticks VALUES (now())");
  	      ResultSet rs = stmt.executeQuery("SELECT tick FROM ticks");

  	      String out = "Hello!\n";
  	      while (rs.next()) {
  	          out += "Read from DB: " + rs.getTimestamp("tick") + "\n";
  	      }

  	      return out;
  	    } catch (Exception e) {
  	      return "There was an error: " + e.getCause();
  	    }
    }
}
