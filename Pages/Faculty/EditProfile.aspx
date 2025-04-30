<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="StudentPortal1._01.Pages.Faculty.EditProfile" %>

<!DOCTYPE html>

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>portal</title>
    <style>
   
        *{
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: 'poppins',sans-serif;
}

.side-menu .brand-name .img{

}
a{
    text-decoration: none;
}
li{
    list-style: none;
}
h1,h2{color:rgba(255, 255, 255, 0.788);}
.side-menu{
    position: fixed;
    background-color:rgb(26, 102, 107);
    width: 20vw;
    min-height: 100vh;
    display: flex;
    flex-direction: column;

}
.side-menu .img{
    display: flex;
            justify-content: center;
            align-items: center;
           
}
.side-menu .brand-name{
    height: 10vh;
    display: flex;
    align-items: center;
    justify-content: center;

}
.side-menu li{
    font-size: 24px;
    padding: 10px 40px;
    color: white;
    display: flex;
    align-items: center;

}
.side-menu li:hover{
    background: white;
    color: #216d8b;
    background-color:rgba(255, 255, 255, 0.5);
}
.container{
    position: absolute;
    right: 0;
    width: 80vw;
    height: 100vh;
    background: white;}
    
.container .box{
        margin-top: 10%;
        margin-left: 30%;
        margin-right: 30%;
        border: 2px solid black;
        box-sizing: content-box;

    }
.container .header{
    position: fixed;
    top: 0;
    right: 0;
    width: 80vw;
    height: 10vh;
    background: white;
    display: flex;
    align-items: center;
    justify-content: center;
    box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2)
}
.container .header .nav{
    width: 90%;
    display: flex;
    align-items: center;
    
    
}

.container .header .nav .LL{
    margin-left: 80%;
}



.container .header .nav .img-case{
    position: relative;
    width: 50px;
    height: 50px;
}
.container .header .nav .img-case .img{
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    margin-right: 0px;
}
.container .content{
    position: relative;
    margin-top: 10vh;
    min-height: 90vh;
}
.container .content .card{
    padding: 20px 15px;
    display: flex;
    align-items: center;
    justify-content: space-between;
    flex-wrap: wrap;

}
.container .content .card .card{
    width: 250px;
    height: 150px;
    background: rgb(75, 174, 212);
    margin: 20px 10px;

}

    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div class="side-menu">
                <asp:Image ImageUrl="~/Images/logo1.jpg" runat="server" ID="img1" />
        <div class="brand-name">
            <h2>FACULTY PORTAL</h2>
        </div>
        <ul>
            <li> <asp:HyperLink ID="Dashboardhl" runat="server" NavigateUrl="Dashboard.aspx" ForeColor="White">Dashboard</asp:HyperLink></li>
            <li> <asp:HyperLink ID="Markshl" runat="server" NavigateUrl="StudentSearch.aspx" ForeColor="White">Search Student</asp:HyperLink></li>
            <li> <asp:HyperLink ID="Courseshl" runat="server" NavigateUrl="Courses.aspx" ForeColor="White">Courses</asp:HyperLink></li>
        </ul>
    </div>

 <div class="container">
    <div class="box">
        <strong>ID: </strong><asp:Label runat="server" ID="ID2"></asp:Label>
      <strong>Name: </strong><asp:Textbox runat="server" ID="faculty_name2"></asp:Textbox>
      <br><br>
      <strong>Address: </strong><asp:Textbox runat="server" ID="address"></asp:Textbox><br><br>
      <strong>Phone: </strong> <asp:Textbox runat="server" ID="phone"></asp:Textbox><br><br>
        <asp:Label ID="error" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="error2" runat="server" ForeColor="Green"></asp:Label>
        <asp:button ID="Save" runat="server" OnClick="Save_Click" Text="Save Changes"/>
         </div>


    <div class="header">
        <div><strong>Name:</strong> <asp:Label runat="server" ID="faculty_name"></asp:Label></div>
        <div><strong>ID:</strong><asp:Label runat="server" ID="ID"></asp:Label></div>
        <div class="nav">
            <div class="img-case"><img src="user.png" alt=""></div>
    <div class="LL"><asp:HyperLink runat="server" ID="profile" NavigateUrl="Profile.aspx"><strong>Profile</strong></asp:HyperLink>
                &nbsp;&nbsp;<asp:HyperLink runat="server" ID="logout" NavigateUrl="FacultyLogin.aspx"><strong>Logout</strong></asp:HyperLink></div>
            
        </div>
   
        </div>
   
 </div>
    </form>
</body>
</html>
