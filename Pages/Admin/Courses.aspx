<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="StudentPortal1._01.Pages.Admin.Courses" %>

<!DOCTYPE html>

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
    position: absolute;
    top: 0;
   margin-left:0;
    right:0;
    width: 77vw;
    height: 10vh;
    background: white;
    display: flex;
    align-items: center;
    justify-content: center;
    box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2)
    
}
 .container .box{
        margin-top: 10%;
        margin-left: 30%;
        margin-right: 30%;
        border: 2px solid black;
        box-sizing: content-box;
        width:700px;

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
.container .query{
    margin-top:20%;
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
        <div><strong>ID: </strong> <asp:Label runat="server" ID="ID"></asp:Label></div>
        <div class="nav">
            <div class="img-case"><img src="user.png" alt=""></div>
            <div class="LL"><asp:HyperLink runat="server" ID="profile" NavigateUrl="ChangePassword.aspx"><strong>Change Password</strong></asp:HyperLink>
                &nbsp;&nbsp;<asp:HyperLink runat="server" ID="logout" NavigateUrl="AdminLogin.aspx."><strong>Logout</strong></asp:HyperLink></div>
                        
            
        </div>
   
        
   
 </div>
     </div>
     </div>
     </form>
</body>
</html>
