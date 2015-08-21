<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uyeOl.aspx.cs" Inherits="kentselDonusumPlatformu.uyeOl" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />

    <script src="validateForm.js"></script>
   


</head>
<body>
    <div id="topPan">
        <a href="#">
            <img src="images/logo.gif" alt="" width="245" height="39" border="0" /></a>
        <ul>
            <li><a href="default.aspx">AnaSayfa</a></li>
            <li><a href="solutions.aspx">Çözümler</a></li>
            <li><a href="contractors.aspx">Müteahhitler</a></li>
            <li><a href="owner.aspx">Ev Sahipleri</a></li>
            <li><a href="about.aspx">Hakkımızda</a></li>
        </ul>
        <h1>Kentsel Dönüşüm Platformu<br />
            <br />
            <span>Müteahhitler ile ev sahiplerinin buluşma noktası</span> </h1>
    </div>
    <div id="mainmiddlePan">
        <div id="middlePan">
            <%--<div id="middleleftPan" style="width: 100%">--%>

                <div id="middlerightPan" style="width: 100%">
                    <form id="form1" runat="server" style="width: 100%">
                        <h2>Üye Ol</h2>
                        <label>Adınız:</label><br />
                        <%isim.Attributes.Add("onblur", "return validateIsim()");
                            soyisim.Attributes.Add("onblur", "return validateSoyisim()");
                            email.Attributes.Add("onblur", "return validateEposta()");
                            password.Attributes.Add("onblur", "return validatePassword()");
                            password1.Attributes.Add("onblur", "return validatePassEq()");


                                     %>
                        <asp:TextBox ID="isim" runat="server" Width="210px" ></asp:TextBox>
                        <asp:Label ID="isimLbl" runat="server" Text="*" ForeColor="Red" ></asp:Label>
                        <br />
                        <label>Soyadınız:</label><br />
                        <asp:TextBox ID="soyisim" runat="server" Width="211px" ></asp:TextBox>
                        <asp:Label ID="soyisimLbl" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        <br />
                        <label>E-posta adresiniz:</label><br />
                        <asp:TextBox ID="email" runat="server" Width="210px" ></asp:TextBox>
                        <asp:Label ID="emailLbl" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        <br />
                        <label>Şifre: </label>
                        <br />
                        <asp:TextBox ID="password" runat="server" Width="210px" TextMode="Password"  ></asp:TextBox>
                        <asp:Label ID="sifreLbl" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        <br />
                        <label>Şifre: </label>
                        <br />
                        <asp:TextBox ID="password1" runat="server" Width="210px" TextMode="Password"  ></asp:TextBox>
                        <asp:Label ID="sifreLbl2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                        <br />
                        <asp:Button name="login" type="submit" class="button" Text="Üye Ol" runat="server" style="float:left;margin-left:20px" OnClick="Unnamed1_Click1"   />
                        <asp:Button  name="clear"  class="button" Text="Formu Temizle" runat="server" style="float:left;margin-left:10px; Width:142px;background:url(/images/clear.jpg) 0 0 no-repeat #FEFEFE" OnClick="Unnamed2_Click"   />
                        


                    </form>
                    <%--</div>--%>
            </div>
        </div><br /><br /><br />
    </div>
    <div id="bottomPan">
        <div id="bottommiddlePan">
            <div id="bottomleftPan">
                <h2>Gerçekleşen projeler</h2>
                <h3>tarihinden itibaren.</h3>
                <p><span class="boldtext">Sitemiz üzerinden anlaşarak gerçekleştirilmiş projeleri bu sayfalarda bulabilirsiniz.</span> </p>
                <p>Güveniniz için teşekkür ederiz.</p>
                <h4>image</h4>
                <p class="more"><a href="#">daha fazla</a></p>
            </div>
            <div id="bottomrightPan">
                <h2><span class="boldtext">Üyelerimizin yorumları</span> </h2>
                <p><span class="boldtext">Kentsel dönüşüm öncelikle güven işidir.</span></p>
                <br />
                <p>Bu sayfalarda sitemizi kullanan üyelerimizin yorumlarını okuyabilirsiniz. </p>
                <h3>İyi düşünün
                    <br />
                    <span>Bunun telafisi yok</span></h3>
                <p class="more"><a href="#">daha fazla</a></p>
            </div>
        </div>
    </div>
    <div id="footermainPan">
        <div id="footerPan">
            <ul>
                <li><a href="#">AnaSayfa</a>|</li>
                <li><a href="#">Çözümler</a> |</li>
                <li><a href="#">Müteahhitler</a>|</li>
                <li><a href="#">Ev Sahipleri</a> |</li>
                <li><a href="#">Hakkımızda</a></li>
            </ul>
            <p class="copyright">©kdp 2015 - tüm hakları saklıdır</p>

            <div id="footerPanhtml"><a href="http://validator.w3.org/check?uri=referer">html</a></div>
            <div id="footerPancss"><a href="http://jigsaw.w3.org/css-validator/check/referer">css</a></div>
        </div>
    </div>
</body>
</html>
