package bdd;

import java.sql.*;

public class BDD {

    static final String DB_URL = "jdbc:oracle:thin:@kirov:1521:kirov";

    static final String USER = "allefebvre1";
    static final String PASS = "allefebvre1";

    public static void main(String[] args) throws SQLException, ClassNotFoundException {
        //listeEleves();
        
        //insertGroupe();
        
        updateEleves();
    }

    public static void listeEleves() throws SQLException {
        Connection conn = null;
        Statement stmt = null;

        try {
            System.out.println("Connexion ...");
            conn = DriverManager.getConnection(DB_URL, USER, PASS);
            System.out.println("Statement ...");
            stmt = conn.createStatement();
            String sql;
            sql = "SELECT * FROM ELEVE";
            ResultSet rs = stmt.executeQuery(sql);
            System.out.println(rs);
            while (rs.next()) {
                int id = rs.getInt("ID");
                String nom = rs.getString("NOM");
                String prenom = rs.getString("PRENOM");
                String adresse = rs.getString("ADRESSE");
                String mail = rs.getString("MAIL");
                String tel = rs.getString("NUMERO_TEL");
                System.out.println("---");
                System.out.println(String.format("ID: %d, NOM: %s, PRENOM: %s, ADRESSE: %s, MAIL: %s, TEL: %s", id, nom, prenom, adresse, mail, tel));
            }

            rs.close();

            stmt.close();
            conn.close();

        } catch (SQLException e) {
            e.printStackTrace();
        } finally {
            if (stmt != null) {
                stmt.close();
            }
            if (conn != null) {
                conn.close();
            }
            System.out.println("FIN");
        }
    }

    public static void insertGroupe() throws SQLException {
        Connection conn = null;
        Statement stmt = null;

        try {
            System.out.println("Connexion ...");
            conn = DriverManager.getConnection(DB_URL, USER, PASS);
            System.out.println("Statement ...");
            stmt = conn.createStatement();

            stmt.executeUpdate("INSERT INTO GROUPE (NOM) VALUES('PM2')");

            stmt.close();
            conn.close();

        } catch (SQLException e) {
            e.printStackTrace();
        } finally {
            if (stmt != null) {
                stmt.close();
            }
            if (conn != null) {
                conn.close();
            }
            System.out.println("FIN");
        }
    }
    
    public static void updateEleves() throws SQLException{
                Connection conn = null;
        Statement stmt = null;

        try {
            System.out.println("Connexion ...");
            conn = DriverManager.getConnection(DB_URL, USER, PASS);
            System.out.println("Statement ...");
            stmt = conn.createStatement();

            stmt.executeUpdate("UPDATE ELEVE SET ID_GROUPE = 2 WHERE PRENOM = 'Alexandre'");

            stmt.close();
            conn.close();

        } catch (SQLException e) {
            e.printStackTrace();
        } finally {
            if (stmt != null) {
                stmt.close();
            }
            if (conn != null) {
                conn.close();
            }
            System.out.println("FIN");
        }
    }

}
