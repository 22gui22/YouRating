<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="YouRate.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2><%: Title %></h2>
    <p>YouRate is a project create by Guilherme Manteigas for the class "Programação e Integração de Serviços".</p>
    <p>Our Website aims to provide a platform where you can find the best videos on YouTube, while allowing you to see the rate and comments given by our community.</p>

    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
    <style>
    .team{
        padding:75px 0;
    }
    h6.description{
	    font-weight: bold;
	    letter-spacing: 2px;
	    color: #999;
	    border-bottom: 1px solid rgba(0, 0, 0,0.1);
	    padding-bottom: 5px;
    }
    .profile{
	    margin-top: 25px;
    }
    .profile h1{
	    font-weight: normal;
	    font-size: 20px;
	    margin:10px 0 0 0;
    }
    .profile h2{
	    font-size: 14px;
	    font-weight: lighter;
	    margin-top: 5px;
    }
    .profile .img-box{
	    opacity: 1;
	    display: block;
	    position: relative;
    }
    .profile .img-box:after{
	    content:"";
	    opacity: 0;
	    background-color: rgba(0, 0, 0, 0.75);
	    position: absolute;
	    right: 0;
	    left: 0;
	    top: 0;
	    bottom: 0;
    }
    .img-box ul{
	    position: absolute;
	    z-index: 2;
	    bottom: 50px;
	    text-align: center;
	    width: 100%;
	    padding-left: 0px;
	    height: 0px;
	    margin:0px;
	    opacity: 0;
    }
    .profile .img-box:after, .img-box ul, .img-box ul li{
	    -webkit-transition: all 0.5s ease-in-out 0s;
        -moz-transition: all 0.5s ease-in-out 0s;
        transition: all 0.5s ease-in-out 0s;
    }
    .img-box ul i{
	    font-size: 20px;
	    letter-spacing: 10px;
    }
    .img-box ul li{
	    width: 30px;
        height: 30px;
        text-align: center;
        border: 1px solid #88C425;
        margin: 2px;
        padding: 5px;
	    display: inline-block;
    }
    .img-box a{
	    color:#fff;
    }
    .img-box:hover:after{
	    opacity: 1;
    }
    .img-box:hover ul{
	    opacity: 1;
    }
    .img-box ul a{
	    -webkit-transition: all 0.3s ease-in-out 0s;
	    -moz-transition: all 0.3s ease-in-out 0s;
	    transition: all 0.3s ease-in-out 0s;
    }
    .img-box a:hover li{
	    border-color: #fff;
	    color: #88C425;
    }
    a{
        color:#88C425;
    }
    a:hover{
        text-decoration:none;
        color:#519548;
    }
    i.red{
        color:#BC0213;
    }
    </style>

    <div class="row pt-md">
            <div class="center">
              <div class="img-box">
                <img src="https://placeholder.com/750" class="img-responsive">
                <ul class="text-center">
                  <a href=""><li><i class="fa fa-facebook"></i></li></a>
                  <a href=""><li><i class="fa fa-twitter"></i></li></a>
                  <a href=""><li><i class="fa fa-linkedin"></i></li></a>
                </ul>
              </div>
              <h1>Guilherme Manteigas</h1>
              <h2>Co-founder/ Web Developer</h2>
              <p>Instituto Politécnico de Setúbal - CTeSP Tecnologias e Programação de Sistemas de Informação.</p>
            </div>
        </div>
</asp:Content>



