<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ include file="/common/common_js.jsp"%>
<%@ include file="/common/bootstrap.jsp"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
  <head>
    <title>测试</title>
    
	<meta http-equiv="pragma" content="no-cache">
	<meta http-equiv="cache-control" content="no-cache">
	<meta http-equiv="expires" content="0">    
	<meta http-equiv="keywords" content="keyword1,keyword2,keyword3">
	<meta http-equiv="description" content="This is my page">

  </head>
  
  <body>
  	<div class="containar">
  		<div class="row">
  			<div class="col-md-2">姓名：</div><div class="col-md-2">${user.userName}</div>
  			<div class="col-md-2">密码：</div><div class="col-md-2">${user.password}</div>
  			<div class="col-md-2">年龄：</div><div class="col-md-2">${user.age}</div>
  		</div>
  	</div>
  </body>
</html>
