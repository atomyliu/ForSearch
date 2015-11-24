<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pager.ascx.cs" Inherits="WebApp.pager" %>
<script src="js/jquery-1.11.3.min.js"></script>
<script type="text/javascript">
    $(function () {
        $(".inputfy").click(function () {
            var strurl = window.location.href;
            var kg1 = strurl.indexOf("=");
            var url = strurl.substring(0, kg1 + 1);
            var myString = $(".pagination").html();
            var kg1 = myString.indexOf("共计");
            var kg2 = myString.indexOf("页/");
            var num = myString.substring(kg1+2, kg2);
            var kk = $("#pagenum").val();
            if (kk > parseInt(num) || kk < 0) {
                alert("请输入正确的跳转数!");
                return false;
            }
            else {
                window.location.href = url + $("#pagenum").val();
            }
        })
    })
</script>

<style type="text/css"> 

.pagination{
  overflow:hidden;  margin:0; vertical-align:middle; height:20px; line-height:20px;  _zoom:1; }
 .pagination *{  display:inline;  float:left;  margin:0;  padding:0;  font-size:14px;  color:#616161;}
 .currentPage b{  float:none;  color:#f00;}
 .pagination li{  list-style:none; }
 .pagination li li{  position:relative;    font-family: Arial, Helvetica, sans-serif }
 .pagination li li a{  margin:0; padding:0 4px;  color:#616161;  text-decoration:none; }

 .pagination li.firstPage{ margin:0 auto;  border-left:3px solid #06f; }
 
 .pagination li li.currentState a{ color:Red;font-size:13px; }
  .pagination li li.currentState1 a{ font-size:13px; }
 .pageinputfy{ height:18px; margin-left:3px; font-size:12px; border:0px; padding:0 2px 0 2px; background:#EAEAEA;cursor:pointer;}
 .colorno{ color:#AEADA8;margin:0; padding:0 4px; }

</style>
 <div class="pagination">
    <ul>
         <li>
            <%=paginationStr%>
         </li>
     </ul>
 </div>

