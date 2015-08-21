<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Default.aspx.cs" Inherits="kentselDonusumPlatformu.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="topPan">
        <a href="#">
            <img src="images/logo.gif" alt="" width="245" height="39" border="0" /></a>
        <ul>
            <li><a href="#">AnaSayfa</a></li>
            <li><a href="#">Çözümler</a></li>
            <li><a href="#">Müteahhitler</a></li>
            <li><a href="#">Ev Sahipleri</a></li>
            <li><a href="#">Hakkımızda</a></li>
        </ul>
        <h1>Kentsel Dönüşüm Platformu<br />
            <br />
            <span>Müteahhitler ile ev sahiplerinin buluşma noktası</span> </h1>
    </div>
    <div id="mainmiddlePan">
        <div id="middlePan">
            <div id="middleleftPan">

                <% string s = Request.QueryString["k"];
                    string p = Request.QueryString["p"];
                    Response.Write(s); %><br />
                <% Response.Write(p); %>
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
</body>
</html>
