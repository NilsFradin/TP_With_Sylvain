<%-- 
    Document   : login
    Created on : 20 janv. 2018, 09:09:56
    Author     : syescassut1
--%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html" pageEncoding="UTF-8"%>

<c:import url="header.jsp"/>
<a href="${pageContext.request.contextPath}/listProduct"><c:out value="List Products"/></a>
<form method="post" action="${pageContext.request.contextPath}/login">
    <fieldset>
        <legend><c:out value="Login"/></legend>
        <label for="pseudo"><c:out value="Pseudo : "/></label>
        <input type="text" id="pseudo" name="pseudo" value="" size="20" maxlength="60" />
        <br />
        <label for="password"><c:out value="Password : "/></label>
        <input type="password" id="password" name="password" value="" size="20" maxlength="20" />
        <br />
        <input type="submit" value="Login"/>
        <br />
    </fieldset>
</form>
<c:import url="footer.jsp"/>
