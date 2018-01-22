<%-- 
    Document   : addProduct
    Created on : 17 janv. 2018, 18:51:34
    Author     : syescassut1
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ include file="header.jsp" %>
        <a href="<%= path + "/logout"%>">Logout</a>
        <form method="post" action="<%= path+"/auth/addProduct"%>">
            <fieldset>
                <legend>Add Product</legend>
                <label for="ID">ID </label>
                <input type="text" id="ID" name="ID" value="" size="20" maxlength="60"/>
                <br />
                <label for="name">Name </label>
                <input type="text" id="name" name="name" value="" size="20" maxlength="20" />
                <br />
                <label for="price">Price </label>
                <input type="text" id="price" name="price" value="" size="20" maxlength="20" />
                <br />
                <input type="submit" value="ADD"/>
                <br />
            </fieldset>
        </form>
        <a href="<%= path+"/listProduct"%>">List Products</a>
<%@ include file="footer.jsp" %>
