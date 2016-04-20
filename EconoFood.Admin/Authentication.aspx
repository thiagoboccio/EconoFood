<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authentication.aspx.cs" Inherits="EconoFood.Admin.Authentication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
  window.fbAsyncInit = function() {
    FB.init({
        appId: '1577802389198193',
      xfbml      : true,
      version    : 'v2.6'
    });
  };

  (function(d, s, id){
     var js, fjs = d.getElementsByTagName(s)[0];
     if (d.getElementById(id)) {return;}
     js = d.createElement(s); js.id = id;
     js.src = "//connect.facebook.net/en_US/sdk.js";
     fjs.parentNode.insertBefore(js, fjs);
  }(document, 'script', 'facebook-jssdk'));

  function statusChangeCallback(response) {
      console.log('statusChangeCallback');
      console.log(response);
      if (response.status === 'connected') {
          testAPI();
      } else if (response.status === 'not_authorized') {
          document.getElementById('status').innerHTML = 'Please log ' +
            'into this app.';
      } else {
          document.getElementById('status').innerHTML = 'Please log ' +
            'into Facebook.';
      }
  }

  function checkLoginState() {
      alert('teste');
      FB.getLoginStatus(function (response) {
          statusChangeCallback(response);
      });

  (function (d, s, id) {
          var js, fjs = d.getElementsByTagName(s)[0];
          if (d.getElementById(id)) return;
          js = d.createElement(s); js.id = id;
          js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.6&appId=451210098327550";
          fjs.parentNode.insertBefore(js, fjs);
      }(document, 'script', 'facebook-jssdk'));
  }

  function testAPI() {
      console.log('Welcome!  Fetching your information.... ');
      FB.api('/me', function (response) {
          console.log('Successful login for: ' + response.name);
          document.getElementById('status').innerHTML =
            'Thanks for logging in, ' + response.name + '!';
      });
  }
</script>
    <asp:Label runat="server" Text="Login" Width="150px" /><asp:TextBox ID="txtLogin" runat="server" Width="200" MaxLength="50" /><br />
    <asp:Label runat="server" Text="Senha" Width="150px" /><asp:TextBox ID="txtSenha" runat="server" Width="200" MaxLength="50" />
    <div id="fb-root"></div>

    <div class="fb-login-button" data-size="large" data-show-faces="false" data-auto-logout-link="false"  onclick='javascript:checkLoginState();'></div><br />    
</asp:Content>
