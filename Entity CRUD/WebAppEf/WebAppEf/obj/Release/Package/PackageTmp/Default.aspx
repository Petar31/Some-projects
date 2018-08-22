<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppEf._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
     <style>
        #cont{
            margin-top: 30px;
        }
        #divForm1{
            margin-top:30px;
            margin-bottom: 30px;
            visibility:hidden;
        }
        #divForm2{
             visibility:hidden;
        }
        

    </style>
   

    <div class="row" id="cont">
        <div class="col-sm-7">
            <div class="row">
                 <div class="col-sm-6">
                     <asp:Label ID="LabelInfo" runat="server" Text="" Font-Size="Large" ForeColor="#cc0000"></asp:Label>
                     
                 </div>
            </div>
            <asp:Table ID="Table1" runat="server" CssClass="table">
                <asp:TableHeaderRow BackColor="Tomato">
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>First Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Last Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Date of Birth</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Delete</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Edit</asp:TableHeaderCell>
                </asp:TableHeaderRow>
               
            </asp:Table>
        </div>


        <div class="col-sm-5">
            <div class="row">
                <div class="col-sm-4">
                    <asp:Button ID="Button3" CssClass="btn btn-warning"  runat="server" Text="New Employee" OnClientClick="return Hide();" />
                   
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12" id="divForm1">
                    <fieldset>
                          <legend>Add new employee</legend>
                        
                        <div class="row" style="margin-top:10px; margin-bottom:10px">
                             <div class="col-sm-4">
                                 <asp:Label ID="Label1" runat="server" Text="Label">Insert First Name</asp:Label>
                             </div>
                            <div class="col-sm-8">
                                 <asp:TextBox AutoPostBack="false" ID="TextBox1" runat="server"></asp:TextBox><br />
                            </div>
                        </div>
                      
                         <div class="row" style="margin-bottom:10px">
                              <div class="col-sm-4">
                                   <asp:Label ID="Label2" runat="server" Text="Label">Insert Last Name</asp:Label>
                              </div>
                              <div class="col-sm-8">
                                  <asp:TextBox AutoPostBack="false" ID="TextBox2" runat="server"></asp:TextBox><br />
                              </div>
                         </div>

                         <div class="row" style="margin-bottom:10px">
                             <div class="col-sm-4">
                                 <asp:Label ID="Label5" runat="server" Text="Date of Birth"></asp:Label>
                             </div>
                             <div class="col-sm-4">
                                 <input type="date" runat="server" ID="calendar" />
                             </div>
                         </div>
        
       
                    

        <asp:Button CssClass="btn btn-info" ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click" OnClientClick="alertMy()" />

                    </fieldset>
                   
        

                </div>
            </div>

            <div class="row">
                <div class="col-sm-12" id="divForm2" runat="server" visible="false">

                     <fieldset>
                          <legend>Update employee</legend>
                          <div class="row" style="margin-top:10px; margin-bottom:10px">
                               <asp:Label ID="LabelHide" runat="server" Text="Label" Visible="false"></asp:Label>
                               <div class="col-sm-4">
                                   <asp:Label ID="Label3" runat="server" Text="Label">Update First Name</asp:Label>
                               </div>
                              <div class="col-sm-8">
                                   <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
                              </div>

                              </div>

                         <div class="row" style="margin-bottom:10px">
                             <div class="col-sm-4">
                                 <asp:Label ID="Label4" runat="server" Text="Label">Update Last Name</asp:Label>
                             </div>
                             <div class="col-sm-8">
                                  <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
                             </div>
                         </div>

                         <div class="row" style="margin-bottom:10px">
                             <div class="col-sm-4">
                                 <asp:Label ID="Label6" runat="server" Text="Date of Birth"></asp:Label>
                             </div>
                             <div class="col-sm-4">
                                 <input type="date" runat="server" ID="Date1" value="2012-02-02" />
                             </div>
                         </div>

                    <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Update"  OnClick="Button2_Click" />
                         </fieldset>
                </div>
            </div>
            
            
        </div>
        
    </div>


    <script type="text/javascript">
        function Hide() {
            document.getElementById('divForm1').style.visibility = 'visible';
           
            return false;
        }
     
    </script>




</asp:Content>
