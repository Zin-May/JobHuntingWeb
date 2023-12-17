<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="JobHunting.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <title>Login</title>
    <link href="Site3/nicepage.css" rel="stylesheet" />
    <link href="Site3/nicepage.css" rel="stylesheet" />
    <link href="Site3/Login.css" rel="stylesheet" />
    <script src="Site3/jquery.js"></script>
    <script src="Site3/nicepage.js"></script>
    <style>
        .u-block-0690-35 {
            background-image: url("Site3/Login/images/pexels-photo-1372971-Recovered.jpg?rand=f329");
            background-position: 50% 100%;
        }
    </style>
</head>
<body>
    <div>
        <section class="u-align-center u-clearfix u-image u-block-0690-35" custom-posts-hash="T" data-section-properties="{&quot;margin&quot;:&quot;both&quot;,&quot;stretch&quot;:true}" data-id="0690" data-style="login-form-1" id="sec-a286" data-image-width="1600" data-image-height="1066" data-source="functional_fix">
            <div class="u-clearfix u-sheet u-block-0690-2">
                <div class="u-align-center u-container-style u-expanded-width-xs u-group u-shape-rectangle u-block-0690-46">
                    <div class="u-container-layout u-block-0690-47">
                        <span class="u-file-icon u-icon u-block-0690-63">
                            <img src="Site3/Login/images/8524294.png" data-original-src="Site3/Login/images/8524294.png" data-color="#e67a2c" />
                        </span>
                        <span class="u-file-icon u-icon u-block-0690-64">
                            <img src="Site3/Login/images/8524294.png" data-original-src="Site3/Login/images/8524294.png" data-color="#e67a2c" />
                        </span>
                        <span class="u-file-icon u-icon u-block-0690-62">
                            <img src="Site3/Login/images/4977163.png" data-original-src="Site3/Login/images/4977163.png" />
                        </span>
                        <h3 class="u-custom-font u-font-montserrat u-text u-text-default u-block-0690-48">Welcome Back</h3>
                        <div class="custom-expanded u-form u-login-control u-white u-block-0690-49">
                            <form runat="server" class="u-clearfix u-form-custom-backend u-form-spacing-20 u-form-vertical u-inner-form" style="padding: 30px;">
                                <div class="u-form-group u-form-name u-block-control ui-draggable ui-draggable-handle u-block-7b1c-50" data-block="610">
                                    <label class="u-label u-block-7b1c-51">User Name *</label>
                                    <input type="text" placeholder="Enter your Username" id="txtUserName" runat="server" class="u-input u-input-rectangle u-grey-5 u-block-7b1c-52" required="" style="background-image: none" />
                                </div>
                                <div class="u-form-group u-form-password u-block-control ui-draggable ui-draggable-handle u-block-7b1c-53" style="" data-block="611">
                                    <label class="u-label u-block-7b1c-54" style="">Password *</label>
                                    <input type="password" placeholder="Enter your Password" id="txtPassword" runat="server" class="u-input u-input-rectangle u-grey-5 u-block-7b1c-55" required="" style="background-image: none" />
                                </div>
                                <div class="u-align-right u-form-group u-form-submit u-block-control u-block-7b1c-58" data-block="613">
                                    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" CssClass="u-border-none u-btn  u-button-style u-palette-3-base u-block-control ui-draggable ui-draggable-handle u-block-7b1c-59" Style="background-image: none; border-style: none; width: 100%; padding-top: 10px; padding-bottom: 10px; padding-left: 0; padding-right: 0" />
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <%--<a href="https://nicepage.cloud" class="u-border-active-palette-2-base u-border-hover-palette-1-base u-border-none u-btn u-button-style u-dnd-started u-login-control u-login-forgot-password u-none u-res-move-started u-text-grey-40 u-text-hover-palette-4-base u-block-control u-block-7b1c-60" style="align-self: center; border-style: none; left: 175px; top: 565px; margin-top: 13px; margin-left: auto; margin-right: auto; margin-bottom: 0; padding-top: 0; padding-bottom: 0; padding-left: 0; padding-right: 0" data-block="615">
                                    Forgot password?
                                </a>
                                <a href="https://nicepage.one" class="u-border-active-palette-2-base u-border-hover-palette-1-base u-border-none u-btn u-button-style u-dnd-started u-login-control u-login-create-account u-none u-res-move-started u-text-grey-40 u-text-hover-palette-4-base u-block-control u-block-7b1c-61" style="border-style: none; left: 154px; top: 610px; margin-top: 20px; margin-left: auto; margin-right: auto; margin-bottom: 0; padding-top: 0; padding-bottom: 0; padding-left: 0; padding-right: 0" data-block="616">
                                    Don't have an account?
                                </a>--%>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
                <img class="u-image u-image-contain u-image-round u-radius-10 u-block-0690-65" src="Site3/LoginSite/images/2601014749-0.png?rand=75c0" alt="" data-image-width="5000" data-image-height="3750">
            </div>
        </section>
    </div>
</body>
</html>
