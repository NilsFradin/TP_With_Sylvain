package ws;


import java.io.IOException;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;

import com.google.appengine.api.blobstore.BlobKey;
import com.google.appengine.api.blobstore.BlobstoreService;
import com.google.appengine.api.blobstore.BlobstoreServiceFactory;



/**
 * REST Web Service
 *
 * @author syescassut1
 */
@Path("/uploadWS")
public class UploadWS {

	private BlobstoreService blobstoreService = BlobstoreServiceFactory.getBlobstoreService();
	
	/**
     * Retrieves representation of an instance of web_service.GenericResource
     * @return an instance of java.lang.String
	 * @throws IOException 
     */

	@GET
	@Path("/upload")
    public void upload(@Context HttpServletRequest req, @Context HttpServletResponse res) throws IOException {
		Map<String, List<BlobKey>> blobs = blobstoreService.getUploads(req);
		List<BlobKey> blobKeys = blobs.get("Fichier");

		if (blobKeys == null || blobKeys.isEmpty()) {
		    res.sendRedirect("/");
		} else {
		    res.sendRedirect("/lecture/" + blobKeys.get(0).getKeyString());
		}

    }
    
	@Path("/lecture/{key}")
	@Produces("image/png")
	public void doGet(@Context HttpServletRequest req, @Context HttpServletResponse res) throws IOException {
		BlobKey blobKey = new BlobKey(req.getParameter("key"));
		blobstoreService.serve(blobKey, res);
	}
}
