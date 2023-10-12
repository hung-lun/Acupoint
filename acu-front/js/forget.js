function nextt() {
    var user = document.getElementById("user").value;
    var verification_num = document.getElementById("verification_num").value;
    var newpwd = document.getElementById("newpwd").value;


    if (user == "" || verification_num == "" || newpwd == "") {
        alert("欄位不可為空");
        return false;
    }else{
        alert("密碼已變更，請重新登入");
        window.location.href = "./login.html"
    }
}

var resend = document.getElementById("resend");
resend.addEventListener("click", resend1);
function resend1() {
    alert("已重新發送驗證碼");
}
