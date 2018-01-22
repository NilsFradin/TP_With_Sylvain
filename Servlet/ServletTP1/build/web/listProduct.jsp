<%-- 
    Document   : listProduct
    Created on : 17 janv. 2018, 18:16:37
    Author     : syescassut1
--%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html" pageEncoding="UTF-8"%>
<jsp:useBean id="ListProduct"
             scope="page" 
             class="model.ListProduct"/>


<c:import url="header.jsp"/>
<c:if test="${sessionScope.pseudo != null}">
    <a href="${pageContext.request.contextPath}/logout"><c:out value="Logout"/></a>
</c:if>
<c:if test="${sessionScope.pseudo == null}">
    <a href="${pageContext.request.contextPath}/login"><c:out value="Login"/></a>
</c:if>
<h1><c:out value="My products :"/></h1>
<table>       
    <tr>
        <label><c:out value="Display with JSTL Core :" /></label>
    </tr>
    <c:forEach items="${ListProduct.products}" var="product">
        <tr>
            <td><c:out value="${product}" /></td>
            <td>
                <c:if test="${sessionScope.pseudo != null}">
                    <a href="${pageContext.request.contextPath}/auth/removeProduct?id=${product.id}"><c:out value="Delete"/></a>
                </c:if>
            </td>
        </tr>
    </c:forEach>
</table>       
<c:if test="${sessionScope.pseudo != null}">
    <a href="${pageContext.request.contextPath}/auth/addProduct"><c:out value="Add Product"/></a>
</c:if>
<c:import url="footer.jsp"/>