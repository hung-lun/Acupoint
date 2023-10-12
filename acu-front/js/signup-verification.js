function nextt() {
    var user = document.getElementById("user").value;
    var verification_num = document.getElementById("verification_num").value;

    if (user == "" || verification_num == "") {
        alert("欄位不可為空");
        return false;
    }else{
        alert("註冊成功，請登入");
        window.location.href = "./login.html"
    }
}

var resend = document.getElementById("resend");
resend.addEventListener("click", resend1);
function resend1() {
    alert("已發送驗證碼");
}
