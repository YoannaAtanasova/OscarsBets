﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAllDBMovies.aspx.cs" Inherits="MovieScrapper.CommonPages.ShowAllDBMovies" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <link href="MovieStyleSheet.css" rel="stylesheet" />    
    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="header"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <hr />
    <asp:Repeater ID="Repeater1" runat="server"
                        ItemType="MovieScrapper.Entities.Movie" DataSourceID="ObjectDataSource1" OnItemCommand="Repeater1_ItemCommand">
                        <HeaderTemplate>
                            <div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div id="movieItem">
                                <div id="title">
                                    <div ="items">                                      
                                       <a class="linkTitle" href="<%# BuildUrl(Item.Id) %>"><%# Item.Title %> (<%# DisplayYear(Item.ReleaseDate) %>)</a>
                                        <asp:Button ID="MarkAsWatchedButton" runat="server" CssClass="items checkButton" Text= "<%# ChangeTextIfUserWatchedThisMovie(Item.UsersWatchedThisMovie)%>" CommandName="MarkAsWatched" CommandArgument='<%# Item.Id %>' Enabled=<%# DoesUserWatchedThisMovie(Item.UsersWatchedThisMovie)%> />
                                    </div>
                                </div>
                                <img id="poster" src="<%# BuildPosterUrl(Item.PosterPath) %>" class="auto-style2" />
                            </div> 
                            
                            
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource 
                ID="ObjectDataSource1" 
                runat="server" 
                SelectMethod="GetAllMovies"
                TypeName="MovieScrapper.Business.CategoryService">
            </asp:ObjectDataSource>
    </asp:Content>