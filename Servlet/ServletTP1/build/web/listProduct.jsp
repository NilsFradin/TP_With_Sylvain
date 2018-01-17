<%-- 
    Document   : listProduct
    Created on : 17 janv. 2018, 18:16:37
    Author     : syescassut1
--%>

<%@page import="java.util.ArrayList"%>
<%@page import="model.Product"%>
<%@ page contentType="text/html" pageEncoding="UTF-8"%>
<% ArrayList<Product> products = (ArrayList<Product>) request.getAttribute("products");  %>
<% String path = request.getContextPath();%>
<!DOCTYPE html>
<html>
    <head>
        <title>List Product</title>          
    </head>
    <body>  
        <a href="<%= path + "/logout"%>">Logout</a>
        <h1>My products :</h1>
        <table>       
            <% for (Product p : products) {%>
            <tr>      
                <td><%= p%></td>
            </tr>
            <% }%>
        </table>
        <a href="<%= path + "/addProduct"%>">Add Product</a>
    </body>
</html>
