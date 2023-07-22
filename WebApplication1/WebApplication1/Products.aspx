<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Products Page</h1>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="Products">Product 1</h2>
                <p>
                    My product
                list<asp:GridView runat="server" OnSelectedIndexChanged="Unnamed3_SelectedIndexChanged" DataSourceID="SqlDataSource_tutorial" ID="ctl05"></asp:GridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource_tutorial"></asp:SqlDataSource>
                    <asp:GridView runat="server"></asp:GridView>
                    <br class="Apple-interchange-newline">
                    <br class="Apple-interchange-newline">
                </p>
                <p>
                    <a class="btn btn-default" href="">Learn more &raquo;</a><asp:GridView runat="server"></asp:GridView>
                </p>
                <asp:GridView runat="server"></asp:GridView>
                <asp:GridView runat="server"></asp:GridView>
            </section>
        </div>
    </main>

</asp:Content>
