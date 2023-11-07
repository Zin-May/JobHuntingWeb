<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="JobHunting.signup" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta charset="utf-8">
    <title>Sign Up</title> 
    <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="Site3/nicepage.css" media="screen">
<link rel="stylesheet" href="Site3/Home.css" media="screen">
    <script class="u-script" type="text/javascript" src="Site3/jquery.js" defer=""></script>
    <script class="u-script" type="text/javascript" src="Site3/nicepage.js" defer=""></script>
    <meta name="generator" content="Nicepage 5.21.3, nicepage.com">
    <meta name="referrer" content="origin">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,500,500i,600,600i,700,700i,800,800i">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Oswald:200,300,400,500,600,700">
    
        
    <script type="application/ld+json">{
		"@context": "http://schema.org",
		"@type": "Organization",
		"name": "",
		"logo": "Site3/images/default-logo.png"
}</script>
    <meta name="theme-color" content="#478ac9">
    <meta property="og:title" content="Home">
    <meta property="og:type" content="website">
  <meta data-intl-tel-input-cdn-path="intlTelInput/">
</head>
<body>
    <section class="u-clearfix u-container-align-center-sm u-container-align-center-xs u-image u-section-5" id="carousel_359f" data-image-width="2000" data-image-height="1125">
  <div class="u-clearfix u-sheet u-sheet-1">
      <h3>MoMiji</h3>
    <h3 class="u-text u-text-default u-text-1">Sign Up</h3>
    <div class="u-form u-white u-form-1">
      <form runat="server" class="u-clearfix u-form-spacing-19 u-form-vertical u-inner-form" style="padding: 19px;">
                  <div class="u-form-user u-form-group">
  <label class="u-label">User Name</label>
  <input type="text" placeholder="Enter your User Name" id="txtUserName" runat="server" class="u-border-none u-input u-input-rectangle u-palette-3-light-3 u-radius-10" required="">
</div>
          <div class="u-form-email u-form-group">
          <label class="u-label">Email</label>
          <input type="email" placeholder="Enter your Email Address" id="txtEmail" runat="server" class="u-border-none u-input u-input-rectangle u-palette-3-light-3 u-radius-10" required="">
        </div>          
          <div class="u-form-password u-form-group">
  <label class="u-label">Password</label>
  <input type="password" placeholder="Enter Password" id="txtPassword"  runat="server" class="u-border-none u-input u-input-rectangle u-palette-3-light-3 u-radius-10" required="">
</div>         
          <div class="u-form-password u-form-group">
  <label class="u-label">Re-Password</label>
  <input type="password" placeholder="Enter Re Password" id="txtRePassword"  runat="server" class="u-border-none u-input u-input-rectangle u-palette-3-light-3 u-radius-10" required="">
</div>
          <div class="u-form-group">
        <div class="u-align-left">
             <input type="checkbox" runat="server" id="chkAdmin" value="On" class="u-field-input">
                <label class="u-label">Is Admin</label>
        </div>
        <div class="u-align-right">
           <%-- <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" onclick="btnSignUp_Click"/>--%>
              <a href="#" class="u-border-none u-btn u-btn-round u-btn-submit u-button-style u-palette-3-base u-radius-20 u-btn-1">Sign Up</a>
              <input type="submit" runat="server" name="signup" id="btnSignUp" onserverclick="btnSignUp_ServerClick" value="submit" class="u-form-control-hidden">
			<p>Already Have account? <a href="login.aspx">Login</a></p>
        </div>                       
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div> 
      </form>
    </div>
  </div>
</section>
</body>
</html>
