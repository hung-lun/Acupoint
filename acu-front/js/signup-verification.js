const urlParams = new URLSearchParams(window.location.search);
const userid = urlParams.get('Account');
var user = document.getElementById("user");
user.value = userid;

function nextt() {
    var user = document.getElementById("user").value;
    var verification_num = document.getElementById("verification_num").value;

    if (user == "" || verification_num == "") {
        alert("欄位不可為空");
        return false;
    }else{
        const urlParams = new URLSearchParams(window.location.search);
        const userid = urlParams.get('Account');
        user = userid ;
        axios.post('https://localhost:7105/api/User/email/validate?Account=' + userid + "&AuthCode=" + verification_num)
            .then(response => {
                console.log(response);
                alert("註冊成功，將帶您前往登入頁🥳");
                window.location.href = "./login.html";
            })
            .catch(error => {
                console.error(error);
            });
    }
}

// var resend = document.getElementById("resend");
// resend.addEventListener("click", resend1);
// function resend1() {
//     alert("已發送驗證碼");
// }
