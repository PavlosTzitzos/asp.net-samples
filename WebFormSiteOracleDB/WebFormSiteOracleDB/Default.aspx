<asp:TemplateField</asp:BoundField>me Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormSiteOracleDB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        

        <div class="row">
            <asp:GridView runat="server" ID="ctl01" DataSourceID="myHR" DataKeyNames="COMPANY_NAME">
                <Columns>
                    <asp:BoundField  HeaderText="COMPANY_NAME"  SortExpression="COMPANY_NAME"></asp:BoundField>
                    <asp:BoundField DataField="HQ_ADDRESS" HeaderText="HQ_ADDRESS" SortExpression="HQ_ADDRESS"></asp:BoundField>
                    <asp:BoundField DataField="INCOME_OUTCOME" HeaderText="INCOME_OUTCOME" SortExpression="INCOME_OUTCOME"></asp:BoundField>
                    <asp:BoundField DataField="NUMBER_OF_SALESMEN" HeaderText="NUMBER_OF_SALESMEN" SortExpression="NUMBER_OF_SALESMEN"></asp:BoundField>
                    <asp:BoundField DataField="NUMBER_OF_FACTORIES" HeaderText="NUMBER_OF_FACTORIES" SortExpression="NUMBER_OF_FACTORIES"></asp:BoundField>
                    <asp:BoundField DataField="NEW_DRUG_RATE" HeaderText="NEW_DRUG_RATE" SortExpression="NEW_DRUG_RATE"></asp:BoundField>
                    <asp:BoundField DataField="company_name" HeaderText="1" SortExpression="company_name"></asp:BoundField>
                </Columns>
            </asp:GridView>
            
                       
            
        </div>
    </main>

</asp:Content>
