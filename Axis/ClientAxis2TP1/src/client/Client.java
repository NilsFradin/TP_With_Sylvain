package client;



public class Client {
	public static void main(java.lang.String args[]) {
		try {
			client.VersionStub stub = new VersionStub("http://localhost:8080/axis2/services/Version.VersionHttpSoap12Endpoint/");
			client.VersionStub.GetVersionResponse version = stub.getVersion(new client.VersionStub.GetVersion());
			System.out.println(version.get_return());
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
}
