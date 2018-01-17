/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.io.*;
import java.net.*;
/**
 *
 * @author syescassut1
 */
public class Server {

    private static int port;

    public static void main(String[] args) throws Exception {
        boolean boucle = true;
        Reader reader;
        PrintStream sortie = null;
        Socket soc;
        String line;

        if (args.length != 1) {
            System.out.println("usage : java serveur port");
            System.exit(0);
        }
        port = new Integer(args[0]).intValue();

        ServerSocket s = new ServerSocket(port);
        System.out.println("La socket serveur est cree");

        while (true) {
            String aRetourner = "";
            boucle = true;
            soc = s.accept();
            System.out.println("Connexion realise a " + soc.toString());

            reader = new InputStreamReader(soc.getInputStream());
            sortie = new PrintStream(soc.getOutputStream());
            BufferedReader keyboard = new BufferedReader(reader);

            while (boucle) {
                line = keyboard.readLine();
                
                if(line.startsWith("1:")) {
                    String[] mots = line.split(" ");
                    int nbMot = 0;
                    for(String mot : mots) {
                        nbMot++;
                    }
                    aRetourner = String.format("Il y a : %d mots ", nbMot - 1);
                    System.out.println(aRetourner);
                }
                
                if(line.startsWith("2:")) {
                    line = line.replace(" ", "");
                    aRetourner = String.format("Il y a : %d lettres ", line.length()-2);
                    System.out.println(aRetourner);
                }

                if (line.equals("FINSERVER")) {
                    boucle = false;
                    line = null;
                    soc.close();
                } else {
                    sortie.println(aRetourner);
                }
            }
        }
    }
}
