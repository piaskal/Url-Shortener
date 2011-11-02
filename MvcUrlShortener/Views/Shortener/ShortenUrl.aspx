<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage< MvcUrlShortener.Models.ShortenUrlViewModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShortenUrl</title>
</head>
<body>
<% using(Html.BeginForm())  { %>
<div><%: Html.ValidationSummary() %></div>
    <div>
            <%: Html.TextBoxFor(x => x.Url) %>
            <input type="submit" />
    </div>
    <div>
        <% if (Model != null && !string.IsNullOrEmpty(Model.ShortenedUrl))
           { %>
            <a href="<%: Model.ShortenedUrl  %>"><%: Model.ShortenedUrl %></a>
        <% } %>
    </div>
    <% } %>
</body>
</html>
