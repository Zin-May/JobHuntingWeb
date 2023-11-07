<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="JobHunting.login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta charset="utf-8">
    <meta name="keywords" content="Contact Us">
    <meta name="description" content="">
    <title>Login</title>
    
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
    <section class="u-align-center u-clearfix u-image u-block-control u-block-7b1c-35" custom-posts-hash="T" data-section-properties="{&quot;margin&quot;:&quot;both&quot;,&quot;stretch&quot;:true}" data-id="7b1c" data-style="login-form-1" id="carousel_fae8" data-image-width="1600" data-image-height="1066" data-source="functional_fix" style="background-image: url(&quot;Site3/Login/images/pexels-photo-1372971-Recovered.jpg&quot;); background-position: 50% 100%;" data-block="603" data-block-selected="true">
  <div class="u-clearfix u-sheet u-block-7b1c-2" style="min-height: 786px">
  <div class="u-align-center u-container-style u-expanded-width-xs u-group u-shape-rectangle u-block-control u-block-7b1c-46" style="width: 482px; min-height: 663px; height: auto; margin-top: 41px; margin-left: auto; margin-right: auto; margin-bottom: 60px" data-block="604">
    <div class="u-container-layout u-block-7b1c-47" style="padding-top: 20px; padding-left: 20px; padding-right: 20px; padding-bottom: 0" data-container-layout-dom="36"><span class="u-file-icon u-icon u-block-control u-block-7b1c-63" style="width: 64px; height: 64px; margin-top: 31px; margin-right: 60px; margin-bottom: 0; margin-left: auto" data-block="605"><img src="Site3/Login/images/8524294.png" alt="" data-original-src="Site3/Login/images/8524294.png" data-color="#e67a2c"></span><span class="u-file-icon u-icon u-block-control u-block-7b1c-64" style="width: 64px; height: 64px; margin-top: -64px; margin-right: auto; margin-bottom: 0; margin-left: 59px" data-block="606"><img src="Site3/Login/images/8524294.png" alt="" data-original-src="Site3/Login/images/8524294.png" data-color="#e67a2c"></span><span class="u-dnd-started u-file-icon u-icon u-res-move-started u-block-control u-block-7b1c-62" style="width: 64px; height: 64px; left: 215px; top: 51px; margin-top: -64px; margin-right: 179px; margin-bottom: 0; margin-left: auto" data-block="607"><img src="Site3/Login/images/4977163.png" alt="" data-original-src="Site3/Login/images/4977163.png" data-color=""></span><h3 class="u-custom-font u-font-montserrat u-text u-text-default u-block-control u-block-7b1c-48" style="font-weight: 700; font-size: 2.25rem; margin-top: 12px; margin-left: auto; margin-right: auto; margin-bottom: 0" data-block="608">Welcome Back</h3><div class="custom-expanded u-dnd-started u-form u-login-control u-res-move-started u-white u-block-control u-block-7b1c-49" style="height: 374px; background-image: none; width: 442px; left: 20px; top: 179px; margin-top: 9px; margin-left: 0; margin-right: 0; margin-bottom: 0" data-block="609" data-block-type="Form">
      <form runat="server" class="u-clearfix u-form-custom-backend u-form-spacing-20 u-form-vertical u-inner-form" style="padding: 30px;" data-services="">
        
        <div class="u-form-group u-form-name u-block-control ui-draggable ui-draggable-handle u-block-7b1c-50" style="" data-block="610">
          <label class="u-label u-block-7b1c-51" style="">Username *</label>
          <input type="text" placeholder="Enter your Username" id="txtUserName" runat="server" class="u-input u-input-rectangle u-grey-5 u-block-7b1c-52" required="" style="background-image: none">
        </div><div class="u-form-group u-form-password u-block-control ui-draggable ui-draggable-handle u-block-7b1c-53" style="" data-block="611">
          <label class="u-label u-block-7b1c-54" style="">Password *</label>
          <input type="password" placeholder="Enter your Password" id="txtPassword" runat="server" class="u-input u-input-rectangle u-grey-5 u-block-7b1c-55" required="" style="background-image: none">
        </div>
        <%--<div class="u-form-checkbox u-form-group u-block-control ui-draggable ui-draggable-handle u-block-7b1c-56" style="" data-block="612">
          <input type="checkbox" id="chkRememberme" value="On" class="u-field-input">
          <label class="u-block-7b1c-57 u-field-label" style="">Remember me</label>
        </div>--%>
        <div class="u-align-right u-form-group u-form-submit u-block-control u-block-7b1c-58" style="" data-block="613">
        <asp:Button ID="btnLogin" runat="server" CssClass="u-border-none u-btn u-btn-submit u-button-style u-palette-3-base u-block-control ui-draggable ui-draggable-handle u-block-7b1c-59" style="background-image: none; border-style: none; width: 100%; padding-top: 10px; padding-bottom: 10px; padding-left: 0; padding-right: 0" OnClick="btnLogin_Click" Text="Login" />
        <%--  <a href="#" class="u-border-none u-btn u-btn-submit u-button-style u-palette-3-base u-block-control ui-draggable ui-draggable-handle u-block-7b1c-59" style="background-image: none; border-style: none; width: 100%; padding-top: 10px; padding-bottom: 10px; padding-left: 0; padding-right: 0" data-block="614">Login</a>
          <input type="submit" value="submit" class="u-form-control-hidden">--%>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>        
          <div>              
        <a href="https://nicepage.cloud" class="u-border-active-palette-2-base u-border-hover-palette-1-base u-border-none u-btn u-button-style u-dnd-started u-login-control u-login-forgot-password u-none u-res-move-started u-text-grey-40 u-text-hover-palette-4-base u-block-control u-block-7b1c-60" style="align-self: center; border-style: none; left: 175px; top: 565px; margin-top: 13px; margin-left: auto; margin-right: auto; margin-bottom: 0; padding-top: 0; padding-bottom: 0; padding-left: 0; padding-right: 0" data-block="615">
            Forgot password?
        </a>
        <a href="https://nicepage.one" class="u-border-active-palette-2-base u-border-hover-palette-1-base u-border-none u-btn u-button-style u-dnd-started u-login-control u-login-create-account u-none u-res-move-started u-text-grey-40 u-text-hover-palette-4-base u-block-control u-block-7b1c-61" style="border-style: none; left: 154px; top: 610px; margin-top: 20px; margin-left: auto; margin-right: auto; margin-bottom: 0; padding-top: 0; padding-bottom: 0; padding-left: 0; padding-right: 0" data-block="616">
            Don't have an account?
        </a>
          </div>
      </form>
    </div>
    </div>
</div>
  </div>
        </section>

    <section class="u-align-center u-clearfix u-image u-block-0690-35" custom-posts-hash="T" data-section-properties="{&quot;margin&quot;:&quot;both&quot;,&quot;stretch&quot;:true}" data-id="0690" data-style="login-form-1" id="sec-a286" data-image-width="1600" data-image-height="1066" data-source="functional_fix">
  <div class="u-clearfix u-sheet u-block-0690-2">    
        
  <div class="u-align-center u-container-style u-expanded-width-xs u-group u-shape-rectangle u-block-0690-46">
    <div class="u-container-layout u-block-0690-47">
        <span class="u-file-icon u-icon u-block-0690-63">
            <img src="Site3/LoginSite/images/8524294.png" alt="" data-original-src="Site3/LoginSite/images/8524294.png" data-color="#e67a2c">

        </span>
        <span class="u-file-icon u-icon u-block-0690-64">
            <img src="Site3/LoginSite/images/8524294.png" alt="" data-original-src="Site3/LoginSite/images//8524294.png" data-color="#e67a2c">

        </span>
        <span class="u-file-icon u-icon u-block-0690-62"><img src="Site3/LoginSite/images/4977163.png" alt="" data-original-src="Site3/LoginSite/images/4977163.png" data-color="">

        </span>
        <h3 class="u-custom-font u-font-montserrat u-text u-text-default u-block-0690-48">Welcome Back</h3>
        <div class="custom-expanded u-form u-login-control u-white u-block-0690-49">
      <form action="#" method="POST" class="u-clearfix u-form-custom-backend u-form-spacing-20 u-form-vertical u-inner-form" source="custom" name="form" style="padding: 30px;" data-services="">
        
        <div class="u-form-group u-form-name u-block-0690-50">
          <label for="username-a30d" class="u-label u-block-0690-51">Username *</label>
          <input type="text" placeholder="Enter your Username" id="username-a30d" name="username" class="u-grey-5 u-input u-input-rectangle u-block-0690-52" required="">
        </div><div class="u-form-group u-form-password u-block-0690-53">
          <label for="password-a30d" class="u-label u-block-0690-54">Password *</label>
          <input type="text" placeholder="Enter your Password" id="password-a30d" name="password" class="u-grey-5 u-input u-input-rectangle u-block-0690-55" required="">
        </div>
        <div class="u-form-checkbox u-form-group u-block-0690-56">
          <input type="checkbox" id="checkbox-a30d" name="remember" value="On" class="u-field-input">
          <label for="checkbox-a30d" class="u-block-0690-57 u-field-label" style="">Remember me</label>
        </div>
        <div class="u-align-right u-form-group u-form-submit u-block-0690-58">
          <a href="#" class="u-border-none u-btn u-btn-submit u-button-style u-palette-3-base u-block-0690-59">Login</a>
          <input type="submit" value="submit" class="u-form-control-hidden">
        </div>
        <input type="hidden" value="" name="recaptchaResponse">
        
        
      </form>
    </div><a href="https://nicepage.cloud" class="u-border-active-palette-2-base u-border-hover-palette-1-base u-border-none u-btn u-button-style u-login-control u-login-forgot-password u-none u-text-grey-40 u-text-hover-palette-4-base u-block-0690-60">Forgot password?</a><a href="https://nicepage.one" class="u-border-active-palette-2-base u-border-hover-palette-1-base u-border-none u-btn u-button-style u-login-control u-login-create-account u-none u-text-grey-40 u-text-hover-palette-4-base u-block-0690-61">Don't have an account?</a></div>
</div><img class="u-image u-image-contain u-image-round u-radius-10 u-block-0690-65" src="Site3/LoginSite/images/2601014749-0.png?rand=75c0" alt="" data-image-width="5000" data-image-height="3750"></div>
  </section>

</body>
</html>
