<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Title - Header
            </h1>
        </section>
        
        <div>
            <asp:GridView runat="server" ID="ctl01" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="COMPANY_NAME">
                <Columns>
                    <asp:BoundField DataField="COMPANY_NAME" HeaderText="COMPANY_NAME" ReadOnly="True" SortExpression="COMPANY_NAME"></asp:BoundField>
                    <asp:BoundField DataField="HQ_ADDRESS" HeaderText="HQ_ADDRESS" SortExpression="HQ_ADDRESS"></asp:BoundField>
                    <asp:BoundField DataField="INCOME_OUTCOME" HeaderText="INCOME_OUTCOME" SortExpression="INCOME_OUTCOME"></asp:BoundField>
                    <asp:BoundField DataField="NUMBER_OF_SALESMEN" HeaderText="NUMBER_OF_SALESMEN" SortExpression="NUMBER_OF_SALESMEN"></asp:BoundField>
                    <asp:BoundField DataField="NUMBER_OF_FACTORIES" HeaderText="NUMBER_OF_FACTORIES" SortExpression="NUMBER_OF_FACTORIES"></asp:BoundField>
                    <asp:BoundField DataField="NEW_DRUG_RATE" HeaderText="NEW_DRUG_RATE" SortExpression="NEW_DRUG_RATE"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" ProviderName="<%$ ConnectionStrings:ConnectionString1.ProviderName %>" SelectCommand="SELECT * FROM ""user_test"".COMPANY"></asp:SqlDataSource>
        </div>
        
    </main>

</asp:Content>
