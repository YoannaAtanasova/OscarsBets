﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BetsStatistics.aspx.cs" Inherits="MovieScrapper.CommonPages.BetsStatistics" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <link href="MovieStyleSheet.css" rel="stylesheet" /> 
    <br />
    <span>All users with the bets they made</span>
    <hr />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns = "false" OnRowDataBound = "OnRowDataBound"></asp:GridView>
    
</asp:Content>