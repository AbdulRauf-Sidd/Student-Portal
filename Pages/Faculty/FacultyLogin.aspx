<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacultyLogin.aspx.cs" Inherits="StudentPortal1._01.Pages.Faculty.FacultyLogin" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        panel{
            align-items: end;
        }
        *{
            margin: 0px;
            padding: 0px;
            box-sizing: border-box;
            font-family: sans-serif;

        }
        body{
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            background: url(back1.jpg) no-repeat;
            background-size: cover;
             background-position: center;
        }
        header{
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            padding: 20px 100px;
            display: flex;
            justify-content: space-between;
            align-items: center;
            z-index: 99;
        }
      .navigation a{
        margin: 20px;
        font-size: 1em;
        text-decoration: none;
        color: white;
        position: relative;
        font-weight:500;
      }
      .navigation a::after{
        content: '';
        position: absolute;
        left: 1px;
        bottom: -5px;
        width: 100px;
        height: 3px;
        background: white;
        border-radius: 5px;
        transform: scaleX(0);
       transition: 0.5s;;
      } 
      .navigation a:hover::after{
        transform: scaleX(.7);
        transform-origin: left;

      }  
      .wrapper{
        position: relative;
        width: 400px;
        height: 440px;
        background: transparent;
        border: 2px solid rgba(255,255,255,.5);
        border-radius: 20px;
        backdrop-filter: blur(20px);
        box-shadow: 0 0 30px rgba(0,0,0,.5);
       padding-left: 80px;
       padding-top: 50px;
    

      }
      .form-boxlogin{
        font-weight:bolder;
      }

      .login1{
        padding-left: 175px;

      }
     
     
      </style>
</head>
<body>
    <header>
       <img src="logo1.jpg" alt="">
&nbsp;<nav class="navigation">
            <a href="https://www.uit.edu/">Home</a>
            <a href="https://r.search.yahoo.com/_ylt=AwrhdlzyFX5kE649.CZXNyoA;_ylu=Y29sbwNiZjEEcG9zAzEEdnRpZANBRFNFTkdDXzEEc2VjA3Ny/RV=2/RE=1686013555/RO=10/RU=http%3a%2f%2fuitu.edu.pk%2fWhoWeAre.php/RK=2/RS=yOVSlqdHJoHc5VQmv5W0wjfHHBA-">About us</a>
            <a href="https://r.search.yahoo.com/_ylt=AwrhdlzyFX5kE649.iZXNyoA;_ylu=Y29sbwNiZjEEcG9zAzEEdnRpZANBRFNFTkdDXzEEc2VjA3Ny/RV=2/RE=1686013555/RO=10/RU=http%3a%2f%2fuitu.edu.pk%2ffe.php/RK=2/RS=sz3c1Q9YcFvrg0F3p8l7fsKRoEo-">Faculty</a>
            <a href="https://r.search.yahoo.com/_ylt=AwrhdlzyFX5kE649.SZXNyoA;_ylu=Y29sbwNiZjEEcG9zAzEEdnRpZANBRFNFTkdDXzEEc2VjA3Ny/RV=2/RE=1686013555/RO=10/RU=http%3a%2f%2fuitu.edu.pk%2fcsprograms.php/RK=2/RS=DNSgnilFfwWR59juM_lBVSmSCJo-">Acadamics</a>
        </nav>

    </header>
    <div class="wrapper">
      <div class="form-boxlogin">
        <h2>Faculty Login portal</h2>
        <br> <br> <br>
          <form id="form1" runat="server">
              <div id="panel">
                  <asp:HyperLink NavigateUrl="/Pages/Student/StudentLogin.aspx" runat="server">Student Portal</asp:HyperLink>
                  <asp:HyperLink NavigateUrl="/Pages/Admin/AdminLogin.aspx" runat="server">Admin Portal</asp:HyperLink>
              </div>
          <div class="input-box">
            <span class="icon"><ion-icon name="mail-outline">
              </ion-icon></span>
            <asp:TextBox TextMode="Email" runat="server" ID="email"></asp:TextBox>
            <label>email</label></div>

          <br>

          <div class="input-box">
          <span class="icon"><ion-icon name="lock-closed-outline"></ion-icon></span>
          <asp:TextBox TextMode="Password" runat="server" ID="password2"></asp:TextBox>
          <label>password</label>
              </div>

              <asp:Label ID="Label" runat="server"></asp:Label>

        <br>
         
        <div>

            <div class="remember-forgot">
              <label><input type="checkbox">remember me</label>
              <a href="#">forgot password?</a>
            </div>
          
          <br>

            <div class="login1">
            <asp:button type="submit" class="btn" runat="server" Text="Login" OnClick="Login"></asp:button>
            </div>

          <br>

            <div class="login-register">
              <p>Dont have an account?<a href="#" class="register-link">register
                  </a></p>
            </div>

        </div>
          </form>
      </div>
    </div>
    <script type="module" src="https://unpkg.com/ionicons@7.1.0/dist/ionicons/ionicons.esm.js"></script>
<script nomodule src="https://unpkg.com/ionicons@7.1.0/dist/ionicons/ionicons.js"></script>
</body>
</html>
