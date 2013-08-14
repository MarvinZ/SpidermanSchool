<%@ Page Title="Spiderman School" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Primer_parser._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2></h2>
            </hgroup>
            <p>
               With great power comes great responsibilty
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>I could say something..:</h3>
<p>
    <asp:Label ID="Label1" runat="server" Text="Enter the URL you want to parse: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <telerik:RadTextBox ID="RadTextBox1" Runat="server" EmptyMessage="enter a valid url!! with http!" LabelWidth="64px" Width="413px" Text="http://www.brisnet.com/cgi-bin/instant.cgi?type=inr&amp;country=USA&amp;track=PRX&amp;date=2013-08-13" Skin="Silk">
    </telerik:RadTextBox>
&nbsp;
</p>
            &nbsp;<telerik:RadButton ID="RadButton1" runat="server" Height="32px" Text="Do it!" Width="144px" OnClick="RadButton1Click" Skin="Silk">
    </telerik:RadButton>
    
    <br />
    
    <br />
    <asp:Label ID="Label2" runat="server" Text="Link total: " Visible="False"></asp:Label>
<telerik:RadTextBox ID="RadTextBox3" Runat="server" Skin="Silk" Visible="False">
</telerik:RadTextBox>
    <br />
    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Silk">
</telerik:RadGrid>
    <telerik:RadTextBox ID="RadTextBox2" Runat="server" Height="36px" Width="296px" Skin="Silk" Visible="False">
    </telerik:RadTextBox>
    <br />
    <br />
    
</asp:Content>
