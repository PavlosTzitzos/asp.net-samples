<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubmitSuccessful.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Application Submited</h1>
            <p class="lead">Well done.</p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Form 1</h2>
                <p> Inline expression finally works: <%: DateTime.Now %> </p>

            </section>
            <script language="Javascript" type="text/javascript">
            </script>
        </div>
    </main>

</asp:Content>
