/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cloudclienttp1;

import client.ClientRestFull;

/**
 *
 * @author syescassut1
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ClientRestFull client = new ClientRestFull();
        System.out.println(client.getHtml());
        System.out.println(client.postHtml("Got2"));
        System.out.println(client.deleteHtml("GoT"));
        System.out.println(client.putHtml("SdA", "HP"));
    }
    
}
