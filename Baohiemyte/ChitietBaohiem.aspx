<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChitietBaohiem.aspx.cs" Inherits="Baohiemyte.ChitietBaohiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h3>Thông tin bảo hiểm
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
                        <div class="box-header with-border" id="divedit" runat="server">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Họ tên </label>
                                        <asp:TextBox ID="txthoten" class="form-control pull-right" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Năm sinh </label>
                                        <asp:TextBox ID="txtngaysinh" class="form-control pull-right" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Giới tính </label>
                                        <asp:TextBox ID="txtgioitinh" class="form-control pull-right" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Số BHXH </label>
                                        <asp:TextBox ID="txtsoBH" class="form-control pull-right" runat="server"></asp:TextBox>
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
                                        <asp:DropDownList ID="DropHuyen" CssClass="form-control pull-right" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Đối tượng </label>
                                        <asp:TextBox ID="txtdoituong" class="form-control pull-right" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-body" id="divview" runat="server">
                            <div class="col-md-12">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Id: </label>
                                        <asp:Label ID="lblidbh" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Họ tên: </label>
                                        <asp:Label ID="lblhotenbh" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Năm sinh: </label>
                                        <asp:Label ID="lblnamsinhbh" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Giới tính: </label>
                                        <asp:Label ID="lblgioitinhbh" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Số BH: </label>
                                        <asp:Label ID="lblsoBH" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Đối tượng: </label>
                                        <asp:Label ID="lbldoituongbh" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Xã: </label>
                                        <asp:Label ID="lblxabh" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Huyện: </label>
                                        <asp:Label ID="lblHuyenbh" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Báo giảm: </label>
                                        <asp:Label ID="lblbaogiambh" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Thời gian báo giảm: </label>
                                        <asp:Label ID="lblthoigianbaogiam" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Lý do báo giảm: </label>
                                        <asp:Label ID="lbllydobaogiam" runat="server"></asp:Label>
                                    </div>
                                </div>

                            </div>

                        </div>
                        <div class="box-footer with-border">
                            <div class="col-md-12" id="divbutton" runat="server">
                                <asp:Button ID="btupdate" class="btn btn-primary" runat="server" Text="Sửa thông tin" OnClick="btupdate_Click" />
                                <asp:Button ID="btBaogiam" class="btn btn-danger" runat="server" Text="Báo giảm" OnClick="btBaogiam_Click" />
                                <asp:Button ID="btcancel" class="btn btn-default" runat="server" Text="Quay lại" OnClick="btcancel_Click" />
                            </div>
                            <div class="col-md-12" id="divbuttonedit" runat="server">
                                <asp:Button ID="btsaveedit" class="btn btn-primary" runat="server" Text="Lưu thông tin sửa" OnClick="btsaveedit_Click" />
                                <asp:Button ID="btcanceledit" class="btn btn-default" runat="server" Text="Hủy thao tác" OnClick="btcanceledit_Click" />
                            </div>

                        </div>
                    </div>
                    <div class="col-md-12" id="divbaogiam" runat="server">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Thời gian báo giảm: </label>
                                <div class="input-group date">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                    <input type="text" class="form-control pull-right" id="datepickerbh" runat="server">
                                </div>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="form-group">
                                <label>Lý do báo giảm: </label>
                                <asp:TextBox ID="txtlydobaogiambh" class="form-control pull-right" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btbaogiambh" class="btn btn-danger" runat="server" Text="Lưu báo giảm" OnClientClick="return confirmbaogiam();" OnClick="btbaogiambh_Click" />
                                <asp:Button ID="btcancelbaogiam" class="btn btn-default" runat="server" Text="Quay lại" OnClick="btcancelbaogiam_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript">

        function confirmbaogiam() {
            if (confirm('Hãy xác nhận bạn muốn báo giảm trường hợp này?')) {
                return true;
            } else {
                return false;
            }
        }
    </script>
</asp:Content>
