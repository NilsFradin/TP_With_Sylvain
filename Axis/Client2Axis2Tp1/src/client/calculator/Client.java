package client.calculator;

public class Client {
	public static void main(java.lang.String args[]) {
			try {
				ServiceAxis2Tp1Stub stub = new ServiceAxis2Tp1Stub("http://localhost:8080/axis2/services/ServiceAxis2Tp1.ServiceAxis2Tp1HttpSoap12Endpoint/");
				client.calculator.ServiceAxis2Tp1Stub.Calcul calcul1 = new client.calculator.ServiceAxis2Tp1Stub.Calcul();
				calcul1.setArgs0(2);
				calcul1.setArgs1(0);
				client.calculator.ServiceAxis2Tp1Stub.CalculResponse response = stub.calcul(calcul1);
				System.out.println(response.get_return());
			} catch(java.rmi.RemoteException e) {
				e.printStackTrace();
			} catch(client.calculator.ServiceAxis2Tp1RemoteExceptionException sre) {
				sre.printStackTrace();
			}
	}
}
