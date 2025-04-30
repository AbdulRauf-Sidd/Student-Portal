<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="StudentPortal1._01.Pages.Faculty.Courses" %>



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
    
.container .header{ 
    position: fixed;
    top: -100px;
   margin-right:0%;
    right: 0;
    width: 77vw;
    height: 10vh;
    background: white;
    display: flex;
    align-items: center;
    justify-content: center;
    box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2)
    
}
 .container .box {
            margin-top: 10%;
            margin-left: 10%;
            margin-right: 30%;
            margin-bottom: 50%;
            border: 2px solid black;
            box-sizing: content-box;
            background: transparent;
            border: 2px solid rgba(5, 5, 5, 0.5);
            border-radius: 5px;
            backdrop-filter: blur(20px);
            box-shadow: 0 0 10px rgba(0,0,0,.5);
            padding-left: 80px;
            padding-top: 8%;
            padding-bottom: 5%;
            width: 80%;
            height: 20%;
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
        <div id="listviewcourse">
            <asp:ListView ID="lvcourse" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("course_id")%></td>
                            <td style="padding-left:50px"><%# Eval("course_name")%></td>
                            <td style="padding-left:50px"><%# Eval("no_students")%></td>
                            <td><td><asp:LinkButton runat="server" CommandName="Details" OnCommand="ListStudents_Click" CommandArgument='<%# Eval("course_id")%>'>List Students</asp:LinkButton></td></td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table id="tbl1" runat="server" cellspacing="5">
                            <tr id="tr1" runat="server">
                                <td id="td1" runat="server">Course ID</td>
                                <td id="td2" runat="server" style="padding-left:50px">Course Name</td>
                                <td id="td3" runat="server" style="padding-left:50px">Number Of Students</td>
                            </tr>
                            <tr id="ItemPlaceholder" runat="server" style="padding-left:50px">  
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:ListView>
         </div>


    <div class="header">
        <div><strong>Name: </strong> <asp:Label runat="server" ID="faculty_name"></asp:Label></div>
        <div><strong>ID: </strong> <asp:Label runat="server" ID="ID"></asp:Label></div>
        <div class="nav">
            <div class="img-case"><img src="user.png" alt=""></div>
            <div class="LL"><asp:HyperLink runat="server" ID="profile" NavigateUrl="Profile.aspx"><strong>Profile</strong></asp:HyperLink>
                &nbsp;&nbsp;<asp:HyperLink runat="server" ID="logout" NavigateUrl="FacultyLogin.aspx"><strong>Logout</strong></asp:HyperLink></div>
                        
            
        </div>
   
        
   
 </div>
     </div>
     </div>
     </form>
</body>
</html>
