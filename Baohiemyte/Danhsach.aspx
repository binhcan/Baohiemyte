<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Danhsach.aspx.cs" Inherits="Baohiemyte.Danhsach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Danh sách theo dõi bảo hiểm </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Danh sách theo dõi bảo hiểm </li>
        </ol>
    </section>
    <section class="content container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="box">
                    <div class="box-header">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-4 control-label">Huyện/TP</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="Drophuyen" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="Drophuyen_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <br />

                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-4 control-label">Xã/Phường</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="Dropxa" CssClass="form-control input-sm" runat="server" OnSelectedIndexChanged="Dropxa_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <br />
                            <div class="form-group">
                                <asp:Button ID="btpublick" class="btn btn-primary" runat="server" Text="Load báo giảm" />
                                <asp:Button ID="btupdate" class="btn btn-success btn-md" runat="server" Text="Xuất excel" />
                                <asp:Button ID="btcancel" class="btn btn-default" runat="server" Text="Bỏ tìm kiếm" />

                            </div>
                        </div>
                    </div>

                    <div class="box-body">
                        <table id="tablebaohiem" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Họ tên</th>
                                    <th>Năm sinh</th>
                                    <th>Đối tượng</th>
                                    <th>Số thẻ</th>
                                    <th>QĐ của Sở LĐTBXH</th>
                                    <th>Ngày QĐ</th>
                                    <th>Thao tác</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptBaohiem" runat="server" OnItemCommand="rptBaohiem_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("ID") %></td>
                                            <td><%#Eval("Hoten") %></td>
                                            <td><%#Eval("Namsinh") %></td>
                                            <td><%#Eval("LoaiBH") %></td>
                                            <td><%#Eval("SoBHXH") %></td>
                                            <td><%#Eval("Quyetdinhso") %></td>
                                            <td><%#Eval("Soquyetdinhso") %></td>
                                            <td>
                                                <div class="btn-group">
                                                    <asp:LinkButton ID="lbtnview" runat="server" CommandName="check" CommandArgument='<%#Eval("ID") %>' OnClick="lbtnview_Click">[ Xem/Sửa ]</asp:LinkButton>
                                                    <%--<asp:LinkButton ID="lbtsua" runat="server" CommandName="editdd" CommandArgument='<%#Eval("ID") %>'> [ Sửa ] </asp:LinkButton>--%>
                                                    <asp:LinkButton ID="lbtnbaogiam" runat="server" CommandName="baogiamdd" CommandArgument='<%#Eval("ID") %>' OnClick="lbtnbaogiam_Click">[ Báo giảm ]</asp:LinkButton>
                                                    <asp:LinkButton ID="lbtxoa" runat="server" CommandName="xoa" CommandArgument='<%#Eval("ID") %>' OnClick="lbtxoa_Click">[ Xóa ]</asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>

        </div>
    </section>

</asp:Content>
