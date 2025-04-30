<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditInstructorCourse.aspx.cs" Inherits="StudentPortal1._01.Pages.Admin.EditInstructorCourse" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">
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
    
.container .box{
        margin-top: 10%;
        margin-left: 10%;
        margin-right: 30%;
        margin-bottom:50%;
        border: 2px solid black;
        box-sizing: content-box;
        background: transparent;
    border: 2px solid rgba(5, 5, 5, 0.5);
    border-radius: 5px;
    backdrop-filter: blur(20px);
    box-shadow: 0 0 10px rgba(0,0,0,.5);
    padding-left: 80px;
    padding-top:8%;
    padding-bottom:5%;
    width:80%;
    height:20%;
  
}

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
        <div class="brand-name">
            <h2>STUDENT PORTAL</h2>
        </div>
        <ul>
            <li> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Dashboard.aspx" ForeColor="White">Dashboard</asp:HyperLink></li>
            <li> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Students.aspx" ForeColor="White">Students</asp:HyperLink></li>
            <li> <asp:HyperLink ID="Instructorshl" runat="server" NavigateUrl="Instructors.aspx" ForeColor="White">Instructors</asp:HyperLink></li>
            <li> <asp:HyperLink ID="Coursesshl" runat="server" NavigateUrl="Courses.aspx" ForeColor="White">Courses</asp:HyperLink></li>
            <li> <asp:HyperLink ID="AddCoursehl" runat="server" NavigateUrl="AddCourse.aspx" ForeColor="White">Add Course</asp:HyperLink></li>
            <li> <asp:HyperLink ID="AddStudenthl" runat="server" NavigateUrl="AddStudent.aspx" ForeColor="White">Add Student</asp:HyperLink></li>
            <li> <asp:HyperLink ID="AddInstructorhl" runat="server" NavigateUrl="AddInstructor.aspx" ForeColor="White">Add Instructor</asp:HyperLink></li>
        </ul>
    </div>
 <div class="container">
    <div class="box">
     <div class="query">
         <asp:DropDownList ID="secdrop" runat="server"></asp:DropDownList> &nbsp <asp:Button ID="add" runat="server" Text="Add Course" OnClick="Add_Click"/>
        <br /> <br />
         <asp:Label ID="label3" runat="server" ForeColor="Red"></asp:Label>
     </div>

    <div class="header">
        <div><strong>ID: </strong> <asp:Label runat="server" ID="ID"></asp:Label></div>
        <div class="nav">
            <div class="img-case"><img src="user.png" alt=""/></div>
            <div class="LL"><asp:HyperLink runat="server" ID="profile" NavigateUrl="ChangePassword.aspx"><strong>Change Password</strong></asp:HyperLink>
                &nbsp;&nbsp;<asp:HyperLink runat="server" ID="logout" NavigateUrl="AdminLogin.aspx."><strong>Logout</strong></asp:HyperLink></div>
        </div>
 </div>
     </div>
     </form>
</body>
</html>


