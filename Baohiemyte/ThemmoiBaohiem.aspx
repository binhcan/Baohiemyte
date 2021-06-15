<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThemmoiBaohiem.aspx.cs" Inherits="Baohiemyte.ThemmoiBaohiem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h3>Thêm mới thông tin bảo hiểm
            <asp:Label ID="lbltenxa" runat="server" Text=""></asp:Label>
            <small></small>
        </h3>
        <ol class="breadcrumb">
        </ol>
    </section>
    <section class="content container-fluid">
        <div class="row">
            <div class="form-group">
                <div class="col-md-12">
                    <div class="box box-warning">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <div class="box-header with-border">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Họ tên </label>
                                        <asp:TextBox ID="txthoten" class="form-control pull-right" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Năm sinh </label>
                                        <asp:TextBox ID="txtngaysinh" class="form-control pull-right" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Giới tính </label>
                                        <asp:TextBox ID="txtgioitinh" class="form-control pull-right" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Số BHXH </label>
                                        <asp:TextBox ID="txtsoBH" class="form-control pull-right" runat="server" OnTextChanged="txtsoBH_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Đối tượng </label>
                                        <asp:TextBox ID="txtdoituong" Enabled="false" Cssclass="form-control pull-right" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Xã </label>
                                        <asp:DropDownList ID="Dropxa" CssClass="form-control pull-right" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Huyện </label>
                                        <asp:DropDownList ID="DropHuyen" CssClass="form-control pull-right" runat="server" OnSelectedIndexChanged="DropHuyen_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <br />
                                <asp:Button ID="btsave" class="btn btn-primary" runat="server" Text="Lưu thông tin" OnClick="btsave_Click" />
                                <asp:Button ID="btedit" class="btn btn-primary" runat="server" Text="Lưu thông tin sửa" OnClick="btedit_Click" />
                                <asp:Button ID="bthuythaotac" class="btn btn-default" runat="server" Text="Hủy thao tác" OnClick="bthuythaotac_Click" />
                                <asp:Button ID="btThoat" class="btn btn-default" runat="server" Text="Thoát" OnClick="btThoat_Click" />
                            </div>
                        </div>

                        <div class="box-body">
                            <table id="tablebaohiem" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Id</th>                                        
                                        <th>Họ tên</th>
                                        <th>Số BHXH</th>
                                        <th>Giới tính</th>
                                        <th>Năm sinh</th>
                                        <th>Xã</th>
                                        <th>Chức năng</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptbaohiem" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("ID") %></td>                                                
                                                <td><%#Eval("Hoten") %></td>
                                                <td><%#Eval("SoBHXH") %></td>
                                                <td><%#Eval("Gioitinh") %></td>
                                                <td><%#Eval("Namsinh") %></td>
                                                <td><%#Eval("xa") %></td>
                                                <td>
                                                    <div class="btn-group">
                                                        <asp:LinkButton ID="lbteditbh" runat="server" CommandName="editbh" CommandArgument='<%#Eval("ID") %>' ToolTip="Sửa dữ liệu" OnClick="lbteditbh_Click">Sửa thông tin |  </asp:LinkButton>
                                                        <asp:LinkButton ID="lblxoabh" runat="server" CommandName="cancelbh" CommandArgument='<%#Eval("ID") %>' OnClick="lblxoabh_Click" OnClientClick="return confirmcancel();" ToolTip="Xóa dữ liệu">Xóa </asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <div class="box-footer with-border">
                            

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        function confirmcancel() {
            if (confirm('Bạn có muốn tiếp tục xóa dữ liệu ?')) {
                return true;
            } else {
                return false;
            }
        }
    </script>
</asp:Content>
