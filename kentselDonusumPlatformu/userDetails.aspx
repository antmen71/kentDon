<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userDetails.aspx.cs" Inherits="kentselDonusumPlatformu.userDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 105%;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>


<body>
    <form id="form1" runat="server">
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
                <div id="middleleftPan">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2">Adınız:
                        </td>
                            <td class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Soyadınız:
                        </td>
                            <td>
                        <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Eposta adresiniz:
                        </td>
                            <td>
                        <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Cep Telefonunuz:</td>
                            <td>
                      
                        <asp:TextBox ID="TextBox4" runat="server" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Ev Telefonunuz:</td>
                            <td>
                        <asp:TextBox ID="TextBox5" runat="server" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>İş Telefonunuz:</td>
                            <td>
                        <asp:TextBox ID="TextBox6" runat="server" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Kullanıcı Tipi:</td>
                            <td>
                        <asp:CheckBox ID="evsahibi" runat="server" Text="Ev sahibi" ></asp:CheckBox>     
                        <asp:CheckBox ID="muteahhit" runat="server" Text="Müteahhit" ></asp:CheckBox>     
                            </td>
                        </tr>
                        <tr>
                            <td>İl:</td>
                            <td>     
                        <asp:DropDownList ID="illerDrpDwn" runat="server" AutoPostBack="True" OnSelectedIndexChanged="illerDrpDwn_SelectedIndexChanged" Height="16px" Width="128px">
                        </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>İlçe:</td>
                            <td>
                        <asp:DropDownList ID="ilcelerDrpDwn" runat="server" Height="18px" Width="128px">
                        </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Güncelle" Width="126px" />
                    <br /><br />
                </div>
                <div id="middlerightPan">
                </div>
            </div>
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
    </form>
</body>
</html>
