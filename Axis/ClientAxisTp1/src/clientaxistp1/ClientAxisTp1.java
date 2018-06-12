/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clientaxistp1;

import client.CheckVerifyFault;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author syescassut1
 */
public class ClientAxisTp1 {
    
    private static String intToString(int entier) {
        client.Operations_Service service = new client.Operations_Service();
        client.Operations port = service.getOperationsPort();
        return port.intToString(entier);
    }

    private static int division(int entier1, int entier2) throws CheckVerifyFault {
        client.Operations_Service service = new client.Operations_Service();
        client.Operations port = service.getOperationsPort();
        return port.division(entier1, entier2);
    }
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        System.out.println(intToString(12346));
        try {
            System.out.println(division(1455432123, 1231456));
        } catch (CheckVerifyFault ex) {
            System.out.println(ex.getMessage());
        }
                
    }
}
