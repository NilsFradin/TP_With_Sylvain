/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servlet;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import model.Product;
import model.ListProduct;

/**
 *
 * @author syescassut1
 */
public class AddProductServlet extends HttpServlet {
    
    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet AddProductServlet</title>");            
            out.println("</head>");
            out.println("<body>");
            out.println("<a href=\"LogoutServlet\">Logout</a>");
            out.println("<form method=\"post\" action=\"AddProductServlet\">");
            out.println("<fieldset>");
            out.println("<legend>Add Product</legend>");
            out.println("<label for=\"ID\">ID </label>");
            out.println("<input type=\"text\" id=\"ID\" name=\"ID\" value=\"\" size=\"20\" maxlength=\"60\" />");
            out.println("<br />");
            out.println("<label for=\"name\">Name </label>");
            out.println("<input type=\"text\" id=\"name\" name=\"name\" value=\"\" size=\"20\" maxlength=\"20\" />");
            out.println("<br />");
            out.println("<label for=\"price\">Price </label>");
            out.println("<input type=\"text\" id=\"price\" name=\"price\" value=\"\" size=\"20\" maxlength=\"20\" />");
            out.println("<br />");
            out.println("<input type=\"submit\" value=\"ADD\"/>");
            out.println("<br />");
            out.println("</fieldset>");
            out.println("</form>");
            out.println("<a href=\"ListProductServlet\">List Products</a>");
            out.println("</body>");
            out.println("</html>");
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        int id = Integer.parseInt(request.getParameter("ID"));
        String name = request.getParameter("name");
        double price = Double.parseDouble(request.getParameter("price"));
        
        ListProduct.products.add(new Product(id, name, price));

        response.sendRedirect(request.getContextPath()+"/ListProductServlet");
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
