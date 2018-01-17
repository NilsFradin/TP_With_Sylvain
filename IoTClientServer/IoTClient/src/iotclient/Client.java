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
public class Client {

    private static int port;

    public static void main(String[] args) throws Exception {
        String adresse, line, lineReversed, nombre;
        Reader readSoc;
        PrintStream sortie = null;

        if (args.length != 2) {
            System.out.println("usage : java client nom_serveur port");
            System.exit(0);
        }
        adresse = args[0];
        port = new Integer(args[1]).intValue();

        Socket socket = new Socket(adresse, port);

        Reader reader = new InputStreamReader(System.in);
        BufferedReader keyboard = new BufferedReader(reader);

        sortie = new PrintStream(socket.getOutputStream());
        readSoc = new InputStreamReader(socket.getInputStream());
        BufferedReader keyboardSoc = new BufferedReader(readSoc);

        while (true) {
            System.out.println("Entrez une ligne de texte : ");
            line = keyboard.readLine();

            if (line.equals("FIN")) {
                break;
            }            

            System.out.println("Tapez 1 pour le nombre de mots");
            System.out.println("Tapez 2 pour le nombre de lettres");
            nombre = keyboard.readLine();
            if (nombre.equals("1")) {
                line = "1: " + line;
                sortie.println(line); 
            }
            else if (nombre.equals("2")) {
                line = "2: " + line;
                sortie.println(line);                 
            } else {
                System.out.println("Tapez 1 pour le nombre de mots");
                System.out.println("Tapez 2 pour le nombre de lettres");
                nombre = keyboard.readLine();
            }
            
            line = keyboardSoc.readLine();
            System.out.println("Recu : " + line);
        }
        // fermeture de la socket
        socket.close();
    }
}
